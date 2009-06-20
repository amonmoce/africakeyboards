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
    /// <summary>
    /// Displays a list of selected keyboards and fonts for the user to review before proceeding
    /// with installation.
    /// </summary>
    public partial class ReviewForm : WizardForm
    {
        /// <summary>
        /// A list of selected keyboards 
        /// </summary>
        private Dictionary<string,string> selectedKeyboards;

        /// <summary>
        /// A list of selected fonts.
        /// </summary>
        private Dictionary<string,string> selectedFonts;

        //localized string container.
        private ResourceManager languageResources;

        /// <summary>
        /// Get or set the list of fonts chosen by the user.
        /// </summary>
        public Dictionary<string,string> SelectedFonts
        {
            get { return selectedFonts; }
            set { selectedFonts = value;
            InitializeForm();
            }
        }
        /// <summary>
        /// Get or set the list of keyboards chosen by the user.
        /// </summary>
        public Dictionary<string,string> SelectedKeyboards
        {
            get { return selectedKeyboards; 
            }
            set { 
                selectedKeyboards = value;
                InitializeForm();
            }
        }
	
        public ReviewForm()
        {
            //initialize the form
            InitializeComponent();
            wizardStep = WizardSteps.Review;

            //initialize the text fields with localized strings.
            languageResources = new ResourceManager("Kasahorow.KeyboardInstaller.LanguageResource", typeof(MainForm).Assembly);
            lblMessage.Text = languageResources.GetString("ReviewFormMessage");
            lblPostMessage.Text = languageResources.GetString("ReviewFormNoteMessage");
            
        }
        private void ReviewForm_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }
        /// <summary>
        /// Display the selected keyboards/fonts in a formatted list style.
        /// </summary>
        private void InitializeForm()
        {
            txtSummary.Text = "";
            txtSummary.Text = string.Format("{0}:{1}", languageResources.GetString("Keyboards"), Environment.NewLine);

            if (selectedKeyboards != null && selectedKeyboards.Count > 0)
            {
                foreach (string name in selectedKeyboards.Keys)
                {
                    txtSummary.Text += string.Format("\t{0}{1}", name, Environment.NewLine);
                }
                txtSummary.Text += Environment.NewLine;
            }
            else
            {
                txtSummary.Text += string.Format("\t{0}{1}", languageResources.GetString("None"), Environment.NewLine);
            }
            txtSummary.Text += string.Format("{0}:{1}", languageResources.GetString("Fonts"), Environment.NewLine);
            if (SelectedFonts!=null && SelectedFonts.Count > 0)
            {
                foreach (string name in selectedFonts.Keys)
                {
                    txtSummary.Text += string.Format("\t{0}{1}", name, Environment.NewLine);
                }
            }
            else
            {
                txtSummary.Text += string.Format("\t{0}{1}", languageResources.GetString("None"), Environment.NewLine);
            }
        }
    }
}