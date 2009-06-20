using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using Microsoft.Win32;

namespace Kasahorow.KeyboardInstaller
{
    public partial class MainForm : Form
    {
        //product information in windows registry. will be used for uninstall purposes.
        private const string PRODUCT_NAME = "Kasahorow Keyboard Installer";
        private const string PRODUCT_PUBLISHER = "Kasahorow";
        private const string PRODUCT_CODE = "{5E97E846-C869-4A79-95C2-043DEA86B7BE}";
        
        //current step in the installation wizard
        private WizardSteps currentStep;

        //string and embedded resources like images and such.
        private ResourceManager languageResource;


        public WizardSteps CurrentStep
        {
            get { return currentStep; }
            set { currentStep = value; }
        }
	
        public MainForm()
        {
            InitializeComponent();

            languageResource = new ResourceManager("Kasahorow.KeyboardInstaller.LanguageResource", typeof(MainForm).Assembly);
            ///TODO: Add support for switching between languages.
            
            //initialize the control text based on the selected language strings. english by default.
            lnkWelcome.Text = languageResource.GetString("Welcome");
            lnkKeyboard.Text = languageResource.GetString("Keyboards");
            lnkFonts.Text = languageResource.GetString("Fonts");
            lnkReview.Text = languageResource.GetString("Review");
            lnkFinish.Text = languageResource.GetString("Finish");
            btnNext.Text = languageResource.GetString("Next") +" >>";
            btnBack.Text = "<< " + languageResource.GetString("Back");
            btnExit.Text = languageResource.GetString("Exit");
        }

        /// <summary>
        /// Display a wizard form of the given type in the main tab container.
        /// If the an existing form of the same type exist, make it visible, otherwise create a new one
        /// </summary>
        /// <param name="step">The type of wizard step to display</param>
        private void LoadForm(WizardSteps step)
        {
            WizardForm form = null;
            //search for the list of wizard forms currently available for the given type.
            //if an existing form already exist, make it visible.
            foreach (Control control in pnlContent.Controls)
            {
                if (control is WizardForm)
                {
                    form = control as WizardForm;
                    if (form.WizardStep == step)
                        break;
                    else
                        form = null;
                }
            }
            //wizard form of the given type not found. create a new one.
            if (form == null)
            {
                switch (step)
                {
                    case WizardSteps.Welcome:
                        form = new WelcomeForm();
                        break;
                    case WizardSteps.Keyboards:
                        form = new KeyboardForm();
                        break;
                    case WizardSteps.Fonts:
                        form = new FontForm();
                        break;
                    case WizardSteps.Review:
                        form = new ReviewForm();
                        break;
                    case WizardSteps.Finish:
                        form = new FinishForm();
                        break;
                    default:
                        throw new ApplicationException("Wizard form type not supported: " + step);
                }

                //wizard forms are displayed as child controls of the tab container.
                form.TopMost = false;
                form.TopLevel = false;

                //occupy all the available real estate in the container.
                form.Dock = DockStyle.Fill;

                //add the form to container.
                pnlContent.Controls.Add(form);
                
            }

            //customize the command buttons based on the current active wizard form.
            switch (step)
            {
                case WizardSteps.Welcome:
                    imgArrow.Location = new Point(6, lnkWelcome.Location.Y - 4 + lnkWelcome.Size.Height / 2);
                    btnNext.Text = languageResource.GetString("Next") + " >>";
                    btnNext.Enabled = true;
                    btnBack.Enabled = false;
                    break;
                case WizardSteps.Keyboards:
                    imgArrow.Location = new Point(6, lnkKeyboard.Location.Y - 4 + lnkKeyboard.Size.Height / 2);
                    btnNext.Text = languageResource.GetString("Next") +" >>";
                    btnNext.Enabled = true;
                    btnBack.Enabled = true;
                    break;
                case WizardSteps.Fonts:
                    imgArrow.Location = new Point(6, lnkFonts.Location.Y - 4 + lnkFonts.Size.Height / 2);
                    btnNext.Text = languageResource.GetString("Next") + " >>";
                    btnNext.Enabled = true;
                    btnBack.Enabled = true;
                    break;
                case WizardSteps.Review:
                    imgArrow.Location = new Point(6, lnkReview.Location.Y - 4 + lnkReview.Size.Height / 2);
                    btnNext.Text = languageResource.GetString("Install");
                    btnNext.Enabled = true;

                    //display a list of selected keyboards and fonts when in the review form.
                    ReviewForm rform = form as ReviewForm;
                    foreach (Control control in pnlContent.Controls)
                    {
                        if (control is KeyboardForm)
                        {
                            KeyboardForm kform = control as KeyboardForm;
                            rform.SelectedKeyboards = kform.GetSelectedKeyboards();
                        }
                        else if (control is FontForm)
                        {
                            FontForm fontform = control as FontForm;
                            rform.SelectedFonts = fontform.GetSelectedFonts();
                        }
                    }
                    //allow user to proceed to install screen only if a keyboard/font has been selected.
                    if ((rform.SelectedKeyboards!=null && rform.SelectedKeyboards.Count > 0) ||
                        (rform.SelectedFonts!=null && rform.SelectedFonts.Count > 0))
                    {
                        btnNext.Enabled = true;
                    }
                    else
                    {
                        btnNext.Enabled = false;
                    }
                    break;
                default:
                    break ;
            }
            //show the wizard form, or bring it to the front so it shows.
            form.Show();
            form.BringToFront();
            CurrentStep = step;
        }

        /// <summary>
        /// Instantiate a new process to execute the application in the given path.
        /// This is used primary to install/uninstall individual keyboard msi builds.
        /// </summary>
        /// <param name="path">The path to the application to install</param>
        /// <param name="arg">Arguments to pass to the application</param>
        /// <param name="wait">Wait for the process to complete before returning.</param>
        private void ExecProc(string path, string arg, bool wait)
        {
            //create the process instance to execute the application.
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = true;
            proc.Exited += new EventHandler(proc_Exited);
            proc.StartInfo.FileName = path;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            this.WindowState = FormWindowState.Minimized;
            proc.Start();

            //wait for the process to finish.
            if (wait == true)
            {
                proc.WaitForExit();
                if (proc.HasExited == false)
                    proc.CloseMainWindow();
            }
        }

        /// <summary>
        /// For a list of selected keyboards invoke the corresponding msi package to install the
        /// package on the user's computer.  The selected fonts are copied to the appropraite folder
        /// in the windows directory.
        /// </summary>
        private void InstallSelectedItems()
        {
            try
            {
                btnNext.Enabled = false;

                //compile a list of selected keyboards/fonts.
                Dictionary<string, string> selectedKeyboards = null;
                Dictionary<string, string> selectedFonts = null;
                foreach (Control control in pnlContent.Controls)
                {
                    if (control is KeyboardForm)
                    {
                        KeyboardForm kform = control as KeyboardForm;
                        selectedKeyboards = kform.GetSelectedKeyboards();
                    }
                    else if (control is FontForm)
                    {
                        FontForm fontform = control as FontForm;
                        selectedFonts = fontform.GetSelectedFonts();
                    }
                }
                //for each selected keyboard, invoke its installer.
                if (selectedKeyboards != null)
                {
                    foreach (string key in selectedKeyboards.Keys)
                    {
                        string path = selectedKeyboards[key];
                        ExecProc(string.Format("\"{0}\"", path), "", true);
                    }
                }
                //expand the selected font files and copy them to the windows font folder.
                if (selectedFonts != null)
                {
                    foreach (string key in selectedFonts.Keys)
                    {
                        string path = selectedFonts[key];
                        string dir = Path.GetDirectoryName(path);
                        string pattern = Path.GetFileName(path);
                        string[] files = null;
                        try
                        {
                            files = Directory.GetFiles(dir, pattern);
                        }
                        catch
                        {
                            continue;
                        }
                        foreach (string file in files)
                        {
                            int status = Win32.AddFontResource(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BugReport report = new BugReport(ex);
                report.ShowDialog(this);
            }
        }

        /// <summary>
        /// Delegate to be used by worker threads to update the main form
        /// </summary>
        delegate void UIUpdate();
        /// <summary>
        /// Show the main form after installing the msi installer.
        /// </summary>
        private void ShowWindow()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UIUpdate(ShowWindow));
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }


        #region "Event Handlers"
        
        /// <summary>
        /// Called when a msi installer Process completes and exits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void proc_Exited(object sender, EventArgs e)
        {
            ///TODO: show this when all the installer processes are complete.
            ShowWindow();
        }
        /// <summary>
        /// Called when the this form is first loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //initialize the form with the welcome screen
            LoadForm(WizardSteps.Welcome);
        }
        /// <summary>
        /// Called when the user clicks the 'Next' button. Advances the user to the next
        /// screen in the installation wizard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (currentStep)
            {
                case WizardSteps.Welcome:
                    LoadForm(WizardSteps.Keyboards);
                    break;
                case WizardSteps.Keyboards:
                    LoadForm(WizardSteps.Fonts);
                    break;
                case WizardSteps.Fonts:
                    LoadForm(WizardSteps.Review);
                    break;
                case WizardSteps.Review:
                    LoadForm(WizardSteps.Finish);
                    InstallSelectedItems();
                    break;
                case WizardSteps.Finish:
                    //the next button changes to Exit when in the Finish screen.
                    Application.Exit();
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        /// <summary>
        /// Called when the user clicks the 'Back' button. Navigates to the previous screen
        /// of the wizard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (currentStep)
            {
                case WizardSteps.Welcome:
                    break;
                case WizardSteps.Keyboards:
                    LoadForm(WizardSteps.Welcome);
                    break;
                case WizardSteps.Fonts:
                    LoadForm(WizardSteps.Keyboards);
                    break;
                case WizardSteps.Review:
                    LoadForm(WizardSteps.Fonts);
                    break;
                case WizardSteps.Finish:
                    LoadForm(WizardSteps.Welcome);
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        /// <summary>
        /// Left navigation handler for the Welcome links. Display the welcome screen when the Welcome link is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkWelcome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm(WizardSteps.Welcome);
        }
        /// <summary>
        /// Left navigation handler for the Keyboard link. Display the keyboard selection screen when the Keyboard link is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkKeyboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm(WizardSteps.Keyboards);
        }

        /// <summary>
        /// Left navigation link handler. Displays the Fonts selection screen when the Font link is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkFonts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm(WizardSteps.Fonts);
        }
        /// <summary>
        /// Left navigation handler for the Exit link.  Terminates the application and if selected,
        /// uninstall the keyboard installer package.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            bool deleteFiles = false;
            foreach (Control control in pnlContent.Controls)
            {
                if (control is FinishForm)
                {
                    FinishForm reviewform = control as FinishForm;
                    deleteFiles = reviewform.DeleteTempInstallationFiles;
                    break;
                }
            }
            if (deleteFiles)
            {
                string arg = "/uninstall " + PRODUCT_CODE + " /quiet";
                ExecProc("MsiExec.exe", arg, false);
            }
            Application.Exit();
        }

        /// <summary>
        /// Left navigation handler for the Review link.  Displays the Review screen for users to view
        /// their selection before proceeding to save.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadForm(WizardSteps.Review);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkFinish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnExit_Click(btnExit, new EventArgs());
        }

        #endregion
    }
}