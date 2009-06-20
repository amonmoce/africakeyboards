using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Xml;
using Kasahorow.KeyboardInstaller.Properties;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace Kasahorow.KeyboardInstaller
{
    /// <summary>
    /// Displays a drop down list of countries and available keyboards for each language
    /// for user to select from.
    /// </summary>
    public partial class KeyboardForm : WizardForm
    {
        /// <summary>
        /// content of the xml config file containing keyboard definitions.
        /// </summary>
        private XmlDocument document = null;
        public KeyboardForm()
        {
            InitializeComponent();
            wizardStep = WizardSteps.Keyboards;

            ResourceManager resources = new ResourceManager("Kasahorow.KeyboardInstaller.LanguageResource", typeof(MainForm).Assembly);
            lblMessage.Text = resources.GetString("KeyboardFormMessage");
        }
        private void KeyboardInstallForm_Load(object sender, EventArgs e)
        {
            //populate the drop down list with a list of available countries.
            document = new XmlDocument();
            document.LoadXml(Resource.configuration);

            XmlNodeList countries = document.SelectNodes("/configuration/countries/country");
           foreach (XmlNode country in countries)
           {
               ddlCountries.Items.Add(country.Attributes["Name"].Value);
           }
        }
        /// <summary>
        /// Populate the listbox with a list of available keyboards for the given country.
        /// </summary>
        /// <param name="country"></param>
        private void LoadLanguages(string country)
        {
            //load the configuration file if it hasn't been loaded already.
            if (document == null)
            {
                document = new XmlDocument();
                document.LoadXml(Resource.configuration);
            }
            //query for the list of available keyboards for the given country.
            XmlNodeList keyboards = document.SelectNodes(string.Format("/configuration/countries/country[@Name='{0}']/keyboards/keyboard", country));

            //add the keyboards to the keyboard selection list box.
            clbKeyboards.Items.Clear();
            foreach (XmlNode keyboard in keyboards)
            {
                clbKeyboards.Items.Add(keyboard.Attributes["Name"].Value);
            }
        }
        /// <summary>
        /// Used by the main form to retrieve the list of user selected keyboards.
        /// </summary>
        /// <returns>A list of selected keyboard names and path to their msi package.</returns>
        public Dictionary<string,string> GetSelectedKeyboards()
        {
            Dictionary<string, string> selectedItems = new Dictionary<string, string>();

            if (ddlCountries.SelectedItem == null)
                return selectedItems;

            string path = Application.ExecutablePath;
            string country = ddlCountries.SelectedItem.ToString();
            //build a list of keyboards to uninstall.
            List<string> entries = new List<string>();
            foreach (string item in clbKeyboards.CheckedItems)
            {
                XmlNode keyboard = document.SelectSingleNode(string.Format("/configuration/countries/country[@Name='{0}']/keyboards/keyboard[@Name='{1}']", country,item));
                string setup = keyboard.Attributes["Setup"].Value;

                string execPath = Path.Combine(Path.GetDirectoryName(path), setup);
                selectedItems.Add(item, execPath);
            }
            return selectedItems;
        }
        /// <summary>
        /// Country dropdown list handler.  Reload the keyboard selection list box with keyboards
        /// from the selected country.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbKeyboards.Items.Clear();
            string country = ddlCountries.SelectedItem as string;

            XmlNodeList keyboards = document.SelectNodes(string.Format("/configuration/countries/country[@Name='{0}']/keyboards/keyboard", country));

            foreach (XmlNode keyboard in keyboards)
            {
                clbKeyboards.Items.Add(keyboard.Attributes["Name"].Value);
            }
        }
        /// <summary>
        /// Invert selection link handler. Mark unselected items as selected and selected items as unselected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkInvertSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < clbKeyboards.Items.Count; i++)
            {
                if (clbKeyboards.GetItemChecked(i))
                    clbKeyboards.SetItemChecked(i, false);
                else
                    clbKeyboards.SetItemChecked(i, true);
            }
        }
    }
}