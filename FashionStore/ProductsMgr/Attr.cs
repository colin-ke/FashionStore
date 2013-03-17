using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace ProductsMgr
{

    public partial class Attr : UserControl
    {
        public string TitleName { get; set; }
        public List<AttrContents> AttrContents { get; set; }

        private AttrContents _attr;
        public AttrContents Attr { get { return _attr; } set { _attr = value; if (null != value) SetAttr(value.ID); } }

        public Attr(string name, List<AttrContents> list)
        {
            InitializeComponent();

            TitleName = name;
            AttrContents = list;
            comboBox1.Items.AddRange(AttrContents.ToArray());
            comboBox1.ValueMember = "Content";
            label1.Text = TitleName + ":";
        }

        private void SetAttr(int id)
        {
            for (int i = 0; i < AttrContents.Count; i++)
            {
                if (AttrContents[i].ID == id)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }
            comboBox1.Select();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Attr = (AttrContents)comboBox1.Items[comboBox1.SelectedIndex];
        }

    }
}
