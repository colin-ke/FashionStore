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
            this.lview = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxCategories = new System.Windows.Forms.ComboBox();
            this.cBoxCatalogue = new System.Windows.Forms.ComboBox();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.tControl.Size = new System.Drawing.Size(822, 545);
            this.tControl.TabIndex = 0;
            // 
            // tPage1
            // 
            this.tPage1.Location = new System.Drawing.Point(4, 22);
            this.tPage1.Name = "tPage1";
            this.tPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tPage1.Size = new System.Drawing.Size(814, 519);
            this.tPage1.TabIndex = 0;
            this.tPage1.Text = "商品类别设置";
            this.tPage1.UseVisualStyleBackColor = true;
            // 
            // tPage2
            // 
            this.tPage2.Controls.Add(this.layoutPanel);
            this.tPage2.Controls.Add(this.lview);
            this.tPage2.Controls.Add(this.panel1);
            this.tPage2.Location = new System.Drawing.Point(4, 22);
            this.tPage2.Name = "tPage2";
            this.tPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tPage2.Size = new System.Drawing.Size(814, 519);
            this.tPage2.TabIndex = 1;
            this.tPage2.Text = "商品设置";
            this.tPage2.UseVisualStyleBackColor = true;
            // 
            // lview
            // 
            this.lview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lview.FullRowSelect = true;
            this.lview.Location = new System.Drawing.Point(3, 53);
            this.lview.Name = "lview";
            this.lview.Size = new System.Drawing.Size(808, 180);
            this.lview.TabIndex = 1;
            this.lview.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cBoxCategories);
            this.panel1.Controls.Add(this.cBoxCatalogue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 50);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catalogue";
            // 
            // cBoxCategories
            // 
            this.cBoxCategories.FormattingEnabled = true;
            this.cBoxCategories.Location = new System.Drawing.Point(360, 17);
            this.cBoxCategories.Name = "cBoxCategories";
            this.cBoxCategories.Size = new System.Drawing.Size(121, 21);
            this.cBoxCategories.TabIndex = 0;
            this.cBoxCategories.SelectedIndexChanged += new System.EventHandler(this.cBoxCategories_SelectedIndexChanged);
            // 
            // cBoxCatalogue
            // 
            this.cBoxCatalogue.FormattingEnabled = true;
            this.cBoxCatalogue.Location = new System.Drawing.Point(89, 17);
            this.cBoxCatalogue.Name = "cBoxCatalogue";
            this.cBoxCatalogue.Size = new System.Drawing.Size(121, 21);
            this.cBoxCatalogue.TabIndex = 0;
            this.cBoxCatalogue.SelectedIndexChanged += new System.EventHandler(this.cBoxCatalogue_SelectedIndexChanged);
            // 
            // layoutPanel
            // 
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutPanel.Location = new System.Drawing.Point(3, 281);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(808, 235);
            this.layoutPanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 545);
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
    }
}

