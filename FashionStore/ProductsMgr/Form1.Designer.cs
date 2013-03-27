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
            this.button2 = new System.Windows.Forms.Button();
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
            this.check = new System.Windows.Forms.CheckBox();
            this.btnBrandOk = new System.Windows.Forms.Button();
            this.labelBrand = new System.Windows.Forms.Label();
            this.selectBrand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCategories = new System.Windows.Forms.ComboBox();
            this.cBoxCatalogue = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rtxtIds = new System.Windows.Forms.RichTextBox();
            this.listStatus = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tControl.SuspendLayout();
            this.tPage1.SuspendLayout();
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
            this.tPage1.Controls.Add(this.btnStart);
            this.tPage1.Controls.Add(this.listStatus);
            this.tPage1.Controls.Add(this.rtxtIds);
            this.tPage1.Location = new System.Drawing.Point(4, 22);
            this.tPage1.Name = "tPage1";
            this.tPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tPage1.Size = new System.Drawing.Size(803, 608);
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
            this.panel1.Controls.Add(this.check);
            this.panel1.Controls.Add(this.btnBrandOk);
            this.panel1.Controls.Add(this.labelBrand);
            this.panel1.Controls.Add(this.selectBrand);
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
            // check
            // 
            this.check.AutoSize = true;
            this.check.Location = new System.Drawing.Point(418, 17);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(84, 16);
            this.check.TabIndex = 9;
            this.check.Text = "显示未归类";
            this.check.UseVisualStyleBackColor = true;
            this.check.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // btnBrandOk
            // 
            this.btnBrandOk.Location = new System.Drawing.Point(653, 15);
            this.btnBrandOk.Name = "btnBrandOk";
            this.btnBrandOk.Size = new System.Drawing.Size(44, 23);
            this.btnBrandOk.TabIndex = 8;
            this.btnBrandOk.Text = "brand";
            this.btnBrandOk.UseVisualStyleBackColor = true;
            this.btnBrandOk.Click += new System.EventHandler(this.btnBrandOk_Click);
            // 
            // labelBrand
            // 
            this.labelBrand.AutoSize = true;
            this.labelBrand.Location = new System.Drawing.Point(571, 20);
            this.labelBrand.Name = "labelBrand";
            this.labelBrand.Size = new System.Drawing.Size(11, 12);
            this.labelBrand.TabIndex = 7;
            this.labelBrand.Text = " ";
            // 
            // selectBrand
            // 
            this.selectBrand.FormattingEnabled = true;
            this.selectBrand.Location = new System.Drawing.Point(567, 16);
            this.selectBrand.Name = "selectBrand";
            this.selectBrand.Size = new System.Drawing.Size(79, 20);
            this.selectBrand.TabIndex = 6;
            this.selectBrand.Visible = false;
            this.selectBrand.SelectedIndexChanged += new System.EventHandler(this.selectBrand_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "品牌";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "save-all";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 19);
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
            this.cBoxCategories.Location = new System.Drawing.Point(278, 16);
            this.cBoxCategories.Name = "cBoxCategories";
            this.cBoxCategories.Size = new System.Drawing.Size(98, 20);
            this.cBoxCategories.TabIndex = 0;
            this.cBoxCategories.SelectedIndexChanged += new System.EventHandler(this.cBoxCategories_SelectedIndexChanged);
            // 
            // cBoxCatalogue
            // 
            this.cBoxCatalogue.FormattingEnabled = true;
            this.cBoxCatalogue.Location = new System.Drawing.Point(89, 16);
            this.cBoxCatalogue.Name = "cBoxCatalogue";
            this.cBoxCatalogue.Size = new System.Drawing.Size(105, 20);
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
            // rtxtIds
            // 
            this.rtxtIds.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtxtIds.Location = new System.Drawing.Point(3, 3);
            this.rtxtIds.Name = "rtxtIds";
            this.rtxtIds.Size = new System.Drawing.Size(166, 602);
            this.rtxtIds.TabIndex = 0;
            this.rtxtIds.Text = "";
            // 
            // listStatus
            // 
            this.listStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.listStatus.FormattingEnabled = true;
            this.listStatus.ItemHeight = 12;
            this.listStatus.Location = new System.Drawing.Point(306, 3);
            this.listStatus.Name = "listStatus";
            this.listStatus.Size = new System.Drawing.Size(494, 602);
            this.listStatus.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(204, 204);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 66);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
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
            this.tPage1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox selectBrand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelBrand;
        private System.Windows.Forms.Button btnBrandOk;
        private System.Windows.Forms.CheckBox check;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox listStatus;
        private System.Windows.Forms.RichTextBox rtxtIds;
    }
}

