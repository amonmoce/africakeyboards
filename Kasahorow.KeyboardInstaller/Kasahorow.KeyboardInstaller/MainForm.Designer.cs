namespace Kasahorow.KeyboardInstaller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imgArrow = new System.Windows.Forms.PictureBox();
            this.lnkReview = new System.Windows.Forms.LinkLabel();
            this.lnkFonts = new System.Windows.Forms.LinkLabel();
            this.lnkKeyboard = new System.Windows.Forms.LinkLabel();
            this.lnkWelcome = new System.Windows.Forms.LinkLabel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lineControl2 = new Kasahorow.KeyboardInstaller.LineControl();
            this.lineControl3 = new Kasahorow.KeyboardInstaller.LineControl();
            this.lineControl1 = new Kasahorow.KeyboardInstaller.LineControl();
            this.lnkFinish = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lineControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 37);
            this.panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(262, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(340, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(417, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.lineControl3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 49);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::Kasahorow.KeyboardInstaller.Properties.Resources.kasahorow;
            this.pictureBox1.Location = new System.Drawing.Point(298, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(199, 47);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkFinish);
            this.panel2.Controls.Add(this.imgArrow);
            this.panel2.Controls.Add(this.lnkReview);
            this.panel2.Controls.Add(this.lnkFonts);
            this.panel2.Controls.Add(this.lnkKeyboard);
            this.panel2.Controls.Add(this.lnkWelcome);
            this.panel2.Controls.Add(this.lineControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(123, 241);
            this.panel2.TabIndex = 3;
            // 
            // imgArrow
            // 
            this.imgArrow.Image = global::Kasahorow.KeyboardInstaller.Properties.Resources.arrow;
            this.imgArrow.Location = new System.Drawing.Point(4, 12);
            this.imgArrow.Name = "imgArrow";
            this.imgArrow.Size = new System.Drawing.Size(10, 10);
            this.imgArrow.TabIndex = 7;
            this.imgArrow.TabStop = false;
            // 
            // lnkReview
            // 
            this.lnkReview.AutoSize = true;
            this.lnkReview.Location = new System.Drawing.Point(12, 77);
            this.lnkReview.Name = "lnkReview";
            this.lnkReview.Size = new System.Drawing.Size(43, 13);
            this.lnkReview.TabIndex = 6;
            this.lnkReview.TabStop = true;
            this.lnkReview.Text = "Review";
            this.lnkReview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReview_LinkClicked);
            // 
            // lnkFonts
            // 
            this.lnkFonts.AutoSize = true;
            this.lnkFonts.Location = new System.Drawing.Point(12, 55);
            this.lnkFonts.Name = "lnkFonts";
            this.lnkFonts.Size = new System.Drawing.Size(33, 13);
            this.lnkFonts.TabIndex = 5;
            this.lnkFonts.TabStop = true;
            this.lnkFonts.Text = "Fonts";
            this.lnkFonts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFonts_LinkClicked);
            // 
            // lnkKeyboard
            // 
            this.lnkKeyboard.AutoSize = true;
            this.lnkKeyboard.Location = new System.Drawing.Point(12, 33);
            this.lnkKeyboard.Name = "lnkKeyboard";
            this.lnkKeyboard.Size = new System.Drawing.Size(57, 13);
            this.lnkKeyboard.TabIndex = 4;
            this.lnkKeyboard.TabStop = true;
            this.lnkKeyboard.Text = "Keyboards";
            this.lnkKeyboard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkKeyboard_LinkClicked);
            // 
            // lnkWelcome
            // 
            this.lnkWelcome.AutoSize = true;
            this.lnkWelcome.Location = new System.Drawing.Point(12, 10);
            this.lnkWelcome.Name = "lnkWelcome";
            this.lnkWelcome.Size = new System.Drawing.Size(52, 13);
            this.lnkWelcome.TabIndex = 3;
            this.lnkWelcome.TabStop = true;
            this.lnkWelcome.Text = "Welcome";
            this.lnkWelcome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWelcome_LinkClicked);
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(123, 49);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(374, 241);
            this.pnlContent.TabIndex = 4;
            // 
            // lineControl2
            // 
            this.lineControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.lineControl2.IsHorizontal = false;
            this.lineControl2.Location = new System.Drawing.Point(117, 0);
            this.lineControl2.Name = "lineControl2";
            this.lineControl2.Size = new System.Drawing.Size(6, 241);
            this.lineControl2.TabIndex = 2;
            // 
            // lineControl3
            // 
            this.lineControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineControl3.IsHorizontal = true;
            this.lineControl3.Location = new System.Drawing.Point(0, 47);
            this.lineControl3.Name = "lineControl3";
            this.lineControl3.Size = new System.Drawing.Size(497, 2);
            this.lineControl3.TabIndex = 2;
            // 
            // lineControl1
            // 
            this.lineControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineControl1.IsHorizontal = true;
            this.lineControl1.Location = new System.Drawing.Point(0, 0);
            this.lineControl1.Name = "lineControl1";
            this.lineControl1.Size = new System.Drawing.Size(497, 6);
            this.lineControl1.TabIndex = 0;
            // 
            // lnkFinish
            // 
            this.lnkFinish.AutoSize = true;
            this.lnkFinish.Location = new System.Drawing.Point(11, 99);
            this.lnkFinish.Name = "lnkFinish";
            this.lnkFinish.Size = new System.Drawing.Size(34, 13);
            this.lnkFinish.TabIndex = 8;
            this.lnkFinish.TabStop = true;
            this.lnkFinish.Text = "Finish";
            this.lnkFinish.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFinish_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 327);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kasahorow Keyboard Installer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgArrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private LineControl lineControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private LineControl lineControl2;
        private LineControl lineControl3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.LinkLabel lnkKeyboard;
        private System.Windows.Forms.LinkLabel lnkWelcome;
        private System.Windows.Forms.LinkLabel lnkReview;
        private System.Windows.Forms.LinkLabel lnkFonts;
        private System.Windows.Forms.PictureBox imgArrow;
        private System.Windows.Forms.LinkLabel lnkFinish;

    }
}

