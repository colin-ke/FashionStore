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
            images.Images.Add(Image.FromFile(@"C:\Users\cke\Documents\GitHub\FashionStore\FashionStore\Web\Content\pic\pdt\3\1062432721-1_h.jpg"));
            images.Images.Add(Image.FromFile(@"C:\Users\cke\Documents\GitHub\FashionStore\FashionStore\Web\Content\pic\pdt\3\1062432721-2_h.jpg"));
            images.Images.Add(Image.FromFile(@"C:\Users\cke\Documents\GitHub\FashionStore\FashionStore\Web\Content\pic\pdt\3\T2Ed2vXfdaXXXXXXXX_!!748172324.jpg"));
            images.Images.Add(Image.FromFile(@"C:\Users\cke\Documents\GitHub\FashionStore\FashionStore\Web\Content\pic\pdt\3\T2Rz5UXbNbXXXXXXXX_!!748172324.jpg"));

            ListViewItem item1 = new ListViewItem("item1", 0);
            ListViewItem item2 = new ListViewItem("item2", 1);
            ListViewItem item3 = new ListViewItem("item3", 2);
            ListViewItem item4 = new ListViewItem("item4", 3);
            lview.Items.AddRange(new ListViewItem[] {item1,item2,item3,item4});
            lview.LargeImageList = images;
            lview.View = View.LargeIcon;
            lview.Alignment = ListViewAlignment.Left;


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


    }
}
