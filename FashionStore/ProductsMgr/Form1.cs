using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace ProductsMgr
{
    public partial class Form1 : Form
    {
        EFDBContext context = new EFDBContext();
        string webHome;
        public Form1()
        {
            webHome = Application.StartupPath;
            webHome = webHome.Replace("ProductsMgr\\bin\\Debug", "Web");
            InitializeComponent();
            cBoxCatalogue.Items.AddRange(context.FiltCatagories.Where(cate=>cate.ParentID == null).ToArray());
            cBoxCatalogue.ValueMember = "Name";

            ImageList images = new ImageList();
            images.ImageSize = new Size(150, 150);
            lview.LargeImageList = images;
            lview.View = View.LargeIcon;


        }

        private void cBoxCatalogue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cBoxCatalogue.SelectedIndex;
            FiltCatagories selected = (FiltCatagories)cBoxCatalogue.Items[index];
            cBoxCategories.Items.Clear();
            cBoxCategories.Items.AddRange(context.FiltCatagories.Where(cate=>cate.ParentID.Value == selected.ID).ToArray());
            cBoxCategories.ValueMember = "Name";
        }

        List<Products> pdts;
        Products selectedPdt = null;
        private void cBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cBoxCategories.SelectedIndex;
            FiltCatagories selected = (FiltCatagories)cBoxCategories.Items[index];
            lview.Items.Clear();
            lview.LargeImageList.Images.Clear();
            pdts = selected.Products.ToList();
            for (int i = 0; i < pdts.Count; i++)
            {
                ListViewItem item = new ListViewItem("", i);
                lview.LargeImageList.Images.Add(Image.FromFile(webHome + pdts[i].Pictures.First().GetPicFullPath()));
                lview.Items.Add(item);

            }

            layoutPanel.Controls.Clear();
            foreach (AttrTitles title in selected.AttrTitles)
            {
                Attr attrCtr = new Attr(title.Title, title.AttrContents.ToList());
                layoutPanel.Controls.Add(attrCtr);
            }

        }

        
        private void lview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lview.SelectedIndices.Count > 0)
            {
                int index = lview.SelectedIndices[0];
                selectedPdt = pdts[index];
                foreach (Attr attrCtr in layoutPanel.Controls)
                {
                    AttrContents content = selectedPdt.AttrContents.Where(x => x.AttrTitles.Title == attrCtr.TitleName).FirstOrDefault();
                    if (null != content)
                        attrCtr.AttrContent = content;
                }
                listBox1.Items.AddRange(selectedPdt.Pictures.ToArray());
                listBox1.ValueMember = "PicName";
            }
            else
                selectedPdt = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<AttrContents> newAttrs = new List<AttrContents>();
            foreach (Attr attrCtr in layoutPanel.Controls)
            {
                newAttrs.Add(attrCtr.AttrContent);
            }
            selectedPdt.AttrContents = newAttrs;

            if (context.SaveChanges() > 0)
                MessageBox.Show("更改成功");
            else
                MessageBox.Show("没有需要更改的");
        }
    }
}
