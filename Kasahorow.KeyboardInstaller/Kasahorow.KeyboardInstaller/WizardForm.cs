using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Kasahorow.KeyboardInstaller
{
    public enum WizardSteps
    {
        Welcome = 1,
        Keyboards = 2,
        Fonts = 3,
        Review = 4,
        Finish = 5
    }
    public class WizardForm : Form
    {
        protected WizardSteps wizardStep;

        public WizardSteps WizardStep
        {
            get { return wizardStep; }
        }

    }
 
}
