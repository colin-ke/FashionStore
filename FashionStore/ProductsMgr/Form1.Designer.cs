namespace ProductsMgr
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tControl = new System.Windows.Forms.TabControl();
            this.tPage1 = new System.Windows.Forms.TabPage();
            this.tPage2 = new System.Windows.Forms.TabPage();
            this.rtxt = new System.Windows.Forms.RichTextBox();
            this.listSizes = new System.Windows.Forms.ListBox();
            this.listColors = new System.Windows.Forms.ListBox();
            this.btnAddPic = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.btnAddSize = new System.Windows.Forms.Button();
            this.listPic = new System.Windows.Forms.ListView();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lview = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBoxBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCategories = new System.Windows.Forms.ComboBox();
            this.cBoxCatalogue = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.tControl.SuspendLayout();
            this.tPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tControl
            // 
            this.tControl.Controls.Add(this.tPage1);
            this.tControl.Controls.Add(this.tPage2);
            this.tControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tControl.Location = new System.Drawing.Point(0, 0);
            this.tControl.Name = "tControl";
            this.tControl.SelectedIndex = 0;
            this.tControl.Size = new System.Drawing.Size(811, 634);
            this.tControl.TabIndex = 0;
            // 
            // tPage1
            // 
            this.tPage1.Location = new System.Drawing.Point(4, 22);
            this.tPage1.Name = "tPage1";
            this.tPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tPage1.Size = new System.Drawing.Size(807, 568);
            this.tPage1.TabIndex = 0;
            this.tPage1.Text = "商品类别设置";
            this.tPage1.UseVisualStyleBackColor = true;
            // 
            // tPage2
            // 
            this.tPage2.Controls.Add(this.button2);
            this.tPage2.Controls.Add(this.rtxt);
            this.tPage2.Controls.Add(this.listSizes);
            this.tPage2.Controls.Add(this.listColors);
            this.tPage2.Controls.Add(this.btnAddPic);
            this.tPage2.Controls.Add(this.btnAddColor);
            this.tPage2.Controls.Add(this.btnAddSize);
            this.tPage2.Controls.Add(this.listPic);
            this.tPage2.Controls.Add(this.layoutPanel);
            this.tPage2.Controls.Add(this.lview);
            this.tPage2.Controls.Add(this.panel1);
            this.tPage2.Location = new System.Drawing.Point(4, 22);
            this.tPage2.Name = "tPage2";
            this.tPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tPage2.Size = new System.Drawing.Size(803, 608);
            this.tPage2.TabIndex = 1;
            this.tPage2.Text = "商品设置";
            this.tPage2.UseVisualStyleBackColor = true;
            // 
            // rtxt
            // 
            this.rtxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxt.Location = new System.Drawing.Point(3, 494);
            this.rtxt.Name = "rtxt";
            this.rtxt.Size = new System.Drawing.Size(236, 111);
            this.rtxt.TabIndex = 9;
            this.rtxt.Text = "";
            // 
            // listSizes
            // 
            this.listSizes.Dock = System.Windows.Forms.DockStyle.Right;
            this.listSizes.FormattingEnabled = true;
            this.listSizes.ItemHeight = 12;
            this.listSizes.Location = new System.Drawing.Point(320, 494);
            this.listSizes.Name = "listSizes";
            this.listSizes.Size = new System.Drawing.Size(135, 111);
            this.listSizes.TabIndex = 8;
            // 
            // listColors
            // 
            this.listColors.Dock = System.Windows.Forms.DockStyle.Right;
            this.listColors.FormattingEnabled = true;
            this.listColors.ItemHeight = 12;
            this.listColors.Location = new System.Drawing.Point(455, 494);
            this.listColors.Name = "listColors";
            this.listColors.Size = new System.Drawing.Size(135, 111);
            this.listColors.TabIndex = 7;
            this.listColors.SelectedIndexChanged += new System.EventHandler(this.listColors_SelectedIndexChanged);
            // 
            // btnAddPic
            // 
            this.btnAddPic.Location = new System.Drawing.Point(245, 546);
            this.btnAddPic.Name = "btnAddPic";
            this.btnAddPic.Size = new System.Drawing.Size(73, 23);
            this.btnAddPic.TabIndex = 6;
            this.btnAddPic.Text = "AddPic";
            this.btnAddPic.UseVisualStyleBackColor = true;
            this.btnAddPic.Click += new System.EventHandler(this.btnAddPic_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new System.Drawing.Point(245, 521);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(73, 23);
            this.btnAddColor.TabIndex = 6;
            this.btnAddColor.Text = "AddColor";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // btnAddSize
            // 
            this.btnAddSize.Location = new System.Drawing.Point(245, 496);
            this.btnAddSize.Name = "btnAddSize";
            this.btnAddSize.Size = new System.Drawing.Size(73, 23);
            this.btnAddSize.TabIndex = 6;
            this.btnAddSize.Text = "AddSize";
            this.btnAddSize.UseVisualStyleBackColor = true;
            this.btnAddSize.Click += new System.EventHandler(this.btnAddSize_Click);
            // 
            // listPic
            // 
            this.listPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.listPic.Location = new System.Drawing.Point(590, 494);
            this.listPic.Name = "listPic";
            this.listPic.Size = new System.Drawing.Size(210, 111);
            this.listPic.TabIndex = 5;
            this.listPic.UseCompatibleStateImageBehavior = false;
            this.listPic.DoubleClick += new System.EventHandler(this.listPic_DoubleClick);
            // 
            // layoutPanel
            // 
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutPanel.Location = new System.Drawing.Point(3, 428);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(797, 66);
            this.layoutPanel.TabIndex = 2;
            // 
            // lview
            // 
            this.lview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lview.FullRowSelect = true;
            this.lview.Location = new System.Drawing.Point(3, 49);
            this.lview.Name = "lview";
            this.lview.Size = new System.Drawing.Size(797, 379);
            this.lview.TabIndex = 1;
            this.lview.UseCompatibleStateImageBehavior = false;
            this.lview.SelectedIndexChanged += new System.EventHandler(this.lview_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cBoxBrand);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cBoxCategories);
            this.panel1.Controls.Add(this.cBoxCatalogue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 46);
            this.panel1.TabIndex = 0;
            // 
            // cBoxBrand
            // 
            this.cBoxBrand.FormattingEnabled = true;
            this.cBoxBrand.Location = new System.Drawing.Point(567, 16);
            this.cBoxBrand.Name = "cBoxBrand";
            this.cBoxBrand.Size = new System.Drawing.Size(121, 20);
            this.cBoxBrand.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "品牌";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catalogue";
            // 
            // cBoxCategories
            // 
            this.cBoxCategories.FormattingEnabled = true;
            this.cBoxCategories.Location = new System.Drawing.Point(293, 16);
            this.cBoxCategories.Name = "cBoxCategories";
            this.cBoxCategories.Size = new System.Drawing.Size(121, 20);
            this.cBoxCategories.TabIndex = 0;
            this.cBoxCategories.SelectedIndexChanged += new System.EventHandler(this.cBoxCategories_SelectedIndexChanged);
            // 
            // cBoxCatalogue
            // 
            this.cBoxCatalogue.FormattingEnabled = true;
            this.cBoxCatalogue.Location = new System.Drawing.Point(89, 16);
            this.cBoxCatalogue.Name = "cBoxCatalogue";
            this.cBoxCatalogue.Size = new System.Drawing.Size(121, 20);
            this.cBoxCatalogue.TabIndex = 0;
            this.cBoxCatalogue.SelectedIndexChanged += new System.EventHandler(this.cBoxCatalogue_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(821, 578);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 7F);
            this.button2.Location = new System.Drawing.Point(245, 571);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "BindPictoClr";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 634);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tControl.ResumeLayout(false);
            this.tPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tControl;
        private System.Windows.Forms.TabPage tPage1;
        private System.Windows.Forms.TabPage tPage2;
        private System.Windows.Forms.ListView lview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxCategories;
        private System.Windows.Forms.ComboBox cBoxCatalogue;
        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddSize;
        private System.Windows.Forms.ListView listPic;
        private System.Windows.Forms.RichTextBox rtxt;
        private System.Windows.Forms.ListBox listSizes;
        private System.Windows.Forms.ListBox listColors;
        private System.Windows.Forms.Button btnAddPic;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.ComboBox cBoxBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

