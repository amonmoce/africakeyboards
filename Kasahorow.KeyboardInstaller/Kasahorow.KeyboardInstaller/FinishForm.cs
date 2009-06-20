using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Kasahorow.KeyboardInstaller
{
    public partial class FinishForm : WizardForm
    {
        
        public bool DeleteTempInstallationFiles
        {
            get { 
                return btnRemoveTempFiles.Checked; 
            }
        }
	
        public FinishForm()
        {
            InitializeComponent();
            wizardStep = WizardSteps.Finish;

            ResourceManager resources = new ResourceManager("Kasahorow.KeyboardInstaller.LanguageResource", typeof(MainForm).Assembly);
            lblMessage.Text = resources.GetString("FinishFormMessage");

            btnRemoveTempFiles.Text = resources.GetString("DeleteInstallationFiles");
        }

        private void FinishForm_Load(object sender, EventArgs e)
        {
        }
    }
}