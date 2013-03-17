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
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lview = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCategories = new System.Windows.Forms.ComboBox();
            this.cBoxCatalogue = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxBrand = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.tControl.Size = new System.Drawing.Size(815, 594);
            this.tControl.TabIndex = 0;
            // 
            // tPage1
            // 
            this.tPage1.Location = new System.Drawing.Point(4, 22);
            this.tPage1.Name = "tPage1";
            this.tPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tPage1.Size = new System.Drawing.Size(814, 477);
            this.tPage1.TabIndex = 0;
            this.tPage1.Text = "商品类别设置";
            this.tPage1.UseVisualStyleBackColor = true;
            // 
            // tPage2
            // 
            this.tPage2.Controls.Add(this.button2);
            this.tPage2.Controls.Add(this.listBox1);
            this.tPage2.Controls.Add(this.cBoxBrand);
            this.tPage2.Controls.Add(this.label3);
            this.tPage2.Controls.Add(this.layoutPanel);
            this.tPage2.Controls.Add(this.lview);
            this.tPage2.Controls.Add(this.panel1);
            this.tPage2.Location = new System.Drawing.Point(4, 22);
            this.tPage2.Name = "tPage2";
            this.tPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tPage2.Size = new System.Drawing.Size(807, 568);
            this.tPage2.TabIndex = 1;
            this.tPage2.Text = "商品设置";
            this.tPage2.UseVisualStyleBackColor = true;
            // 
            // layoutPanel
            // 
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutPanel.Location = new System.Drawing.Point(3, 428);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(801, 66);
            this.layoutPanel.TabIndex = 2;
            // 
            // lview
            // 
            this.lview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lview.FullRowSelect = true;
            this.lview.Location = new System.Drawing.Point(3, 49);
            this.lview.Name = "lview";
            this.lview.Size = new System.Drawing.Size(801, 379);
            this.lview.TabIndex = 1;
            this.lview.UseCompatibleStateImageBehavior = false;
            this.lview.SelectedIndexChanged += new System.EventHandler(this.lview_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cBoxCategories);
            this.panel1.Controls.Add(this.cBoxCatalogue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 46);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 19);
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
            this.cBoxCategories.Location = new System.Drawing.Point(360, 16);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "品牌";
            // 
            // cBoxBrand
            // 
            this.cBoxBrand.FormattingEnabled = true;
            this.cBoxBrand.Location = new System.Drawing.Point(52, 503);
            this.cBoxBrand.Name = "cBoxBrand";
            this.cBoxBrand.Size = new System.Drawing.Size(121, 20);
            this.cBoxBrand.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(436, 494);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(368, 71);
            this.listBox1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "addPic";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 594);
            this.Controls.Add(this.tControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tControl.ResumeLayout(false);
            this.tPage2.ResumeLayout(false);
            this.tPage2.PerformLayout();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cBoxBrand;
        private System.Windows.Forms.Label label3;
    }
}

