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
    public partial class PicEditor : Form
    {
        private Pictures picture;
        public PicEditor(ref Pictures pic)
        {
            InitializeComponent();
            picture = pic;
            txtName.Text = pic.PicName;
            checkShow.Checked = pic.IsShow;
            picBox.Image = Image.FromFile(Application.StartupPath.Replace("ProductsMgr\\bin\\Debug", "Web") + pic.GetPicFullPath());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            picture.PicName = txtName.Text;
            picture.IsShow = checkShow.Checked;
            this.Close();
        }
    }
}
