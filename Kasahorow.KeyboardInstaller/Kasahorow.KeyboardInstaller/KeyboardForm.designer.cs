namespace Kasahorow.KeyboardInstaller
{
    partial class KeyboardForm
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
            this.lnkInvertSelection = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clbKeyboards = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ddlCountries = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkInvertSelection
            // 
            this.lnkInvertSelection.AutoSize = true;
            this.lnkInvertSelection.Location = new System.Drawing.Point(9, 5);
            this.lnkInvertSelection.Name = "lnkInvertSelection";
            this.lnkInvertSelection.Size = new System.Drawing.Size(65, 13);
            this.lnkInvertSelection.TabIndex = 12;
            this.lnkInvertSelection.TabStop = true;
            this.lnkInvertSelection.Text = "Selection All";
            this.lnkInvertSelection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInvertSelection_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkInvertSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 22);
            this.panel1.TabIndex = 13;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Location = new System.Drawing.Point(4, 4);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(29, 13);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "label";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.clbKeyboards);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 17);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(322, 196);
            this.panel2.TabIndex = 15;
            // 
            // clbKeyboards
            // 
            this.clbKeyboards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbKeyboards.FormattingEnabled = true;
            this.clbKeyboards.Location = new System.Drawing.Point(4, 33);
            this.clbKeyboards.Name = "clbKeyboards";
            this.clbKeyboards.Size = new System.Drawing.Size(314, 154);
            this.clbKeyboards.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ddlCountries);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel3.Size = new System.Drawing.Size(314, 29);
            this.panel3.TabIndex = 10;
            // 
            // ddlCountries
            // 
            this.ddlCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlCountries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCountries.FormattingEnabled = true;
            this.ddlCountries.Location = new System.Drawing.Point(46, 4);
            this.ddlCountries.Name = "ddlCountries";
            this.ddlCountries.Size = new System.Drawing.Size(268, 21);
            this.ddlCountries.TabIndex = 13;
            this.ddlCountries.SelectedIndexChanged += new System.EventHandler(this.ddlCountries_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Country:";
            // 
            // KeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 239);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyboardForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "KeyboardInstallForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KeyboardInstallForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkInvertSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox clbKeyboards;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox ddlCountries;
        private System.Windows.Forms.Label label1;
    }
}