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
            webHome = Application.StartupPath.Replace("ProductsMgr\\bin\\Debug", "Web");
            InitializeComponent();
            cBoxCatalogue.Items.AddRange(context.FiltCatagories.Where(cate => cate.ParentID == null).ToArray());
            cBoxCatalogue.ValueMember = "Name";

            ImageList images = new ImageList();
            images.ImageSize = new Size(150, 150);
            lview.LargeImageList = images;
            lview.View = View.LargeIcon;

            Brand[] brands = context.Brand.ToArray();
            selectBrand.Items.AddRange(brands);
            selectBrand.ValueMember = "Name";


        }

        private void cBoxCatalogue_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cBoxCatalogue.SelectedIndex;
            FiltCatagories selected = (FiltCatagories)cBoxCatalogue.Items[index];
            cBoxCategories.Items.Clear();
            cBoxCategories.Items.AddRange(context.FiltCatagories.Where(cate => cate.ParentID.Value == selected.ID).ToArray());
            cBoxCategories.ValueMember = "Name";
        }

        List<Products> pdts;
        Products selectedPdt = null;
        private void cBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!check.Checked)
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

        int lv_selectedIndex = 0;
        private void lview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lview.SelectedIndices.Count > 0)
            {
                if (check.Checked)
                {
                    selectedPdt = pdts[lview.SelectedIndices[0]];
                    lv_selectedIndex = lview.SelectedIndices[0];
                    return;
                }
                try
                {
                    int index = lview.SelectedIndices[0];
                    selectedPdt = pdts[index];
                    foreach (Attr attrCtr in layoutPanel.Controls)
                    {
                        AttrContents content = selectedPdt.AttrContents.Where(x => x.AttrTitles.Title == attrCtr.TitleName).FirstOrDefault();
                        if (null != content)
                            attrCtr.AttrContent = content;
                    }
                    //show the list of Pictures
                    listPic.Items.Clear();
                    listPic.LargeImageList = new ImageList();
                    listPic.LargeImageList.ImageSize = new Size(50, 50);
                    int i = 0;
                    foreach (Pictures pic in selectedPdt.Pictures)
                    {
                        listPic.LargeImageList.Images.Add(Image.FromFile(webHome + pic.GetPicFullPath()));
                        listPic.Items.Add(new ListViewItem(pic.PicName, i++));
                    }
                    //listPic.Items.AddRange(selectedPdt.Pictures.ToArray());
                    //listPic.ValueMember = "PicName";

                    //show the list of Sizes
                    listSizes.Items.Clear();
                    listSizes.Items.AddRange(selectedPdt.Sizes.ToArray());
                    listSizes.ValueMember = "Name";

                    //show the list of Colors
                    listColors.Items.Clear();
                    listColors.Items.AddRange(selectedPdt.Colors.ToArray());
                    listColors.ValueMember = "Name";

                    labelBrand.Text = selectedPdt.Brand.Name;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("exception:"+ex.Message);
                }

            }
            else
            {
                listColors.Items.Clear();
                listSizes.Items.Clear();
                listPic.Items.Clear();
                labelBrand.Text = "";
                labelBrand.Visible = true;
                selectBrand.Visible = false;
                selectedPdt = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (null == selectedPdt)
                return;
            if (check.Checked)
            {
                selectedPdt.FiltCatagories.Add((FiltCatagories)cBoxCategories.SelectedItem);
            }
            else
            {
                
                List<AttrContents> newAttrs = new List<AttrContents>();
                foreach (Attr attrCtr in layoutPanel.Controls)
                {
                    newAttrs.Add(attrCtr.AttrContent);
                }
                selectedPdt.AttrContents = newAttrs;

                labelBrand.Visible = true;
                selectBrand.Visible = false;
            }
            if (context.SaveChanges() > 0)
            {
                if (check.Checked)
                {
                    lview.Items.RemoveAt(lv_selectedIndex);
                    lview.LargeImageList.Images.RemoveAt(lv_selectedIndex);
                }
                MessageBox.Show("更改成功");
            }
            else
                MessageBox.Show("没有需要更改的");
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            if(null == selectedPdt)
                return;
            foreach (string str in rtxt.Text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                Sizes newSize = new Sizes()
                {
                    ProductID = selectedPdt.ID,
                    Name = str.Trim()
                };
                selectedPdt.Sizes.Add(newSize);
                listSizes.Items.Add(newSize);
            }
            rtxt.Text = "";
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            foreach (string str in rtxt.Text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                Colors newColor = new Colors()
                {
                    ProductID = selectedPdt.ID,
                    Name = str.Trim()
                };
                selectedPdt.Colors.Add(newColor);
                listColors.Items.Add(newColor);
            }
            context.SaveChanges();
            rtxt.Text = "";
        }

        private void btnAddPic_Click(object sender, EventArgs e)
        {
            int count = listPic.LargeImageList.Images.Count;
            string errPic = "";
            foreach (string str in rtxt.Text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                Pictures newPic = new Pictures()
                {
                    ProductID = selectedPdt.ID,
                    PicName = str
                };

                try
                {
                    listPic.LargeImageList.Images.Add(Image.FromFile(webHome + newPic.GetPicFullPath()));
                    listPic.Items.Add(new ListViewItem(newPic.PicName, count++));
                    selectedPdt.Pictures.Add(newPic);
                }
                catch
                {
                    errPic += str + " ";
                }
                //listPic.Items.Add(new ListViewItem(new);
            }
            rtxt.Text = "";
            if ("" != errPic)
                MessageBox.Show(string.Format("{0}有误",errPic));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int clrIndex, picIndex;
            clrIndex = listColors.SelectedIndex;
            picIndex = listPic.SelectedIndices[0];

            Colors clr = (Colors)listColors.Items[clrIndex];
            Pictures pic = selectedPdt.Pictures.ToList()[picIndex];

            Colors tem = context.Colors.Where(x => x.ID == clr.ID).First();
            tem.PicID = pic.ID;
            clr.PicID = pic.ID;
            MessageBox.Show(string.Format("{0} 已绑定图片 {1}",clr.Name,pic.PicName));
            //tem.Pictures = pic;

        }

        private void listColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listColors.SelectedIndex < 0 || selectedPdt == null)
            {
                listPic.SelectedItems.Clear();
                listPic.Select();
                return;
            }
            Colors clr = ((Colors)listColors.Items[listColors.SelectedIndex]);
            if (clr.PicID == null)
                return;
            int index = selectedPdt.Pictures.ToList().IndexOf(clr.Pictures);
            listPic.SelectedItems.Clear();
            listPic.Items[index].Selected = true;
            listPic.Select();
        }

        private void listPic_DoubleClick(object sender, EventArgs e)
        {
            if (listPic.SelectedIndices.Count < 0)
                return;
            int index = listPic.SelectedIndices[0];
            Pictures pic = selectedPdt.Pictures.ToList()[index];
            new PicEditor(ref pic).Show();
        }

        private void btnBrandOk_Click(object sender, EventArgs e)
        {
            if (null == selectedPdt)
                return;
            if (labelBrand.Visible)
            {
                selectBrand.SelectedIndex = selectBrand.Items.IndexOf(selectedPdt.Brand);
                selectBrand.Select();
            }
            else
            {
                labelBrand.Text = ((Brand)selectBrand.SelectedItem).Name;
            }

            labelBrand.Visible = !labelBrand.Visible;
            selectBrand.Visible = !selectBrand.Visible;
        }

        private void selectBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPdt.Brand = ((Brand)selectBrand.SelectedItem);
            selectedPdt.BrandId = ((Brand)selectBrand.SelectedItem).ID;
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (check.Checked)
            {
                pdts = context.Products.Where(pdt => pdt.FiltCatagories.Count == 0).ToList();
                lview.Items.Clear();
                lview.LargeImageList.Images.Clear();
                for (int i = 0; i < pdts.Count; i++)
                {
                    ListViewItem item = new ListViewItem("", i);
                    lview.LargeImageList.Images.Add(Image.FromFile(webHome + pdts[i].Pictures.First().GetPicFullPath()));
                    lview.Items.Add(item);
                }
                layoutPanel.Controls.Clear();
            }
            else
            {
                if (cBoxCategories.Items.Count > 0 && cBoxCategories.SelectedIndex >= 0)
                    cBoxCategories_SelectedIndexChanged(null, null);
                else
                    check.Checked = true;
            }
        }

        #region The First Tab Page
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            listStatus.Items.Clear();


        }

        #endregion
    }
}
