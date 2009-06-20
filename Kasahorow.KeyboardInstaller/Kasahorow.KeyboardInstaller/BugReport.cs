using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
namespace Kasahorow.KeyboardInstaller
{
	/// <summary>
	/// Bug handler creates a user friendly report for the user
	/// in case of a bug and it gives the user the ability to send a bug
	/// reportby clicking on "Send Bug" button.
	/// </summary>
	public class BugReport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage gpage;
		private System.Windows.Forms.TabPage tpage;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RichTextBox txttrace;
		private System.Windows.Forms.Button btncopy;
		private System.Windows.Forms.Button btnsaveas;
		private System.Windows.Forms.RichTextBox txtinfo;
		private Exception exception;

		/// <summary>
		/// Initializes a new instance of the BugReport class.
		/// </summary>
		public BugReport()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Initializes a new instance of the BugReport class using
		/// e to create a report.
		/// </summary>
		/// <param name="e">Contains the necessary information
		/// needed to craft an informative error message for the 
		/// user</param>
		public BugReport(Exception e)
		{
			InitializeComponent();
			Exception=e;
		}

		/// <summary>
		/// Sets the error message needed to constructed an informative 
		/// message for the user
		/// </summary>
		public Exception Exception
		{
			set{
				exception=value;
				
				System.Reflection.Assembly assem=this.GetType().Assembly;
				System.Reflection.AssemblyName an=assem.GetName();
                txttrace.Text="Build Information \n Version: "+an.Version+"\n\n";
                StringBuilder buffer = new StringBuilder();
                Exception ex = value;
                while (ex != null)
                {
                    buffer.Append("Message: " + ex.Message+"\n");
                    buffer.Append("StackTrace: "+ex.StackTrace+"\n");
                    ex = ex.InnerException;
                }

				txttrace.Text+="Error message:\n"+exception.Message+"\n\n";
				txttrace.Text+="Source: \n"+exception.Source+"\n\n";
				txttrace.Text+="Trace: \n"+buffer.ToString()+"\n\n";
				txttrace.Text+="Target site: \n"+exception.TargetSite+"\n\n";
			}
		}

		/// <summary>
		/// Cleans up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			foreach(Control con in this.Controls)
			{
				if(con!=null)
					con.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BugReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gpage = new System.Windows.Forms.TabPage();
            this.txtinfo = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpage = new System.Windows.Forms.TabPage();
            this.txttrace = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsaveas = new System.Windows.Forms.Button();
            this.btncopy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.gpage.SuspendLayout();
            this.tpage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 40);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(282, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.gpage);
            this.tabControl1.Controls.Add(this.tpage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 213);
            this.tabControl1.TabIndex = 1;
            // 
            // gpage
            // 
            this.gpage.Controls.Add(this.txtinfo);
            this.gpage.Controls.Add(this.label3);
            this.gpage.Controls.Add(this.label2);
            this.gpage.Controls.Add(this.label1);
            this.gpage.Location = new System.Drawing.Point(4, 22);
            this.gpage.Name = "gpage";
            this.gpage.Size = new System.Drawing.Size(360, 187);
            this.gpage.TabIndex = 0;
            this.gpage.Text = "General";
            // 
            // txtinfo
            // 
            this.txtinfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtinfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtinfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtinfo.Location = new System.Drawing.Point(8, 104);
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.ReadOnly = true;
            this.txtinfo.Size = new System.Drawing.Size(344, 72);
            this.txtinfo.TabIndex = 3;
            this.txtinfo.Text = "You might want to send a bug report by e-mail to help@kasahorow.org .  Please inc" +
                "lude as much information as possible in order for us to reproduce the error.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "What you can do:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "An unexpected error has occured in this program.  You may continue to work but if" +
                " you continue to experience problems, save your work and restart the program.";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Short description:";
            // 
            // tpage
            // 
            this.tpage.Controls.Add(this.txttrace);
            this.tpage.Controls.Add(this.panel2);
            this.tpage.Location = new System.Drawing.Point(4, 22);
            this.tpage.Name = "tpage";
            this.tpage.Size = new System.Drawing.Size(360, 187);
            this.tpage.TabIndex = 1;
            this.tpage.Text = "Trace";
            this.tpage.Visible = false;
            // 
            // txttrace
            // 
            this.txttrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txttrace.Location = new System.Drawing.Point(0, 0);
            this.txttrace.Name = "txttrace";
            this.txttrace.Size = new System.Drawing.Size(360, 147);
            this.txttrace.TabIndex = 1;
            this.txttrace.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnsaveas);
            this.panel2.Controls.Add(this.btncopy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 40);
            this.panel2.TabIndex = 0;
            // 
            // btnsaveas
            // 
            this.btnsaveas.Location = new System.Drawing.Point(280, 8);
            this.btnsaveas.Name = "btnsaveas";
            this.btnsaveas.Size = new System.Drawing.Size(75, 23);
            this.btnsaveas.TabIndex = 1;
            this.btnsaveas.Text = "Save As";
            this.btnsaveas.Click += new System.EventHandler(this.btnsaveas_Click);
            // 
            // btncopy
            // 
            this.btncopy.Location = new System.Drawing.Point(145, 8);
            this.btncopy.Name = "btncopy";
            this.btncopy.Size = new System.Drawing.Size(106, 23);
            this.btncopy.TabIndex = 0;
            this.btncopy.Text = "Copy To Clipboard";
            this.btncopy.Click += new System.EventHandler(this.btncopy_Click);
            // 
            // BugReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(368, 253);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BugReport";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bug Handler";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.gpage.ResumeLayout(false);
            this.tpage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Copies onto the clipboard the trace of the program leading up to the bug.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btncopy_Click(object sender, System.EventArgs e)
		{
			string strRtf = this.txttrace.Rtf;
			System.Windows.Forms.DataObject data = new System.Windows.Forms.DataObject();
			data.SetData(DataFormats.Rtf, strRtf);
			Clipboard.SetDataObject(data);
				
		}

		/// <summary>
		/// Prompts the user to save, in rich text format,
		/// the trace of the program leading up to the bug.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnsaveas_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sdiag=new SaveFileDialog();
			sdiag.Filter="*.rtf|Rich Text File";
			sdiag.FileName="KasahorowKeyboard.rtf";
			if(sdiag.ShowDialog()==DialogResult.OK)
			{
				this.txttrace.SaveFile(sdiag.FileName);
			}
        }
	}
}
