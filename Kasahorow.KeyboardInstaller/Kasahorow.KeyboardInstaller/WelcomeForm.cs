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
    public partial class WelcomeForm : WizardForm
    {
        public WelcomeForm()
        {
            InitializeComponent();
            wizardStep = WizardSteps.Welcome;
                        
            //display the welcome message based on the selected language.
            ResourceManager resources = new ResourceManager("Kasahorow.KeyboardInstaller.LanguageResource", typeof(MainForm).Assembly);
            lblMessage.Text = resources.GetString("WelcomeFormMessage");
        }
    }
}