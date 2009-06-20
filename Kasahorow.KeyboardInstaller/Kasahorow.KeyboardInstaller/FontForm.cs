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
    /// Displays a list of available fonts for users to choose from. Selected fonts are copied to the
    /// Windows fonts folder during the installation process.
    /// </summary>
    public partial class FontForm : WizardForm
    {
        /// <summary>
        /// contains xml information of available fonts
        /// </summary>
        private XmlDocument document = null;

        public FontForm()
        {
            InitializeComponent();
            wizardStep = WizardSteps.Fonts;
        }


        private void FontInstallForm_Load(object sender, EventArgs e)
        {
            //load and display the fonts in the font selection box.
            document = new XmlDocument();
            document.LoadXml(Resource.configuration);
            XmlNodeList fonts = document.SelectNodes("/configuration/fonts/font");
            foreach (XmlNode font in fonts)
            {
                clbFonts.Items.Add(font.Attributes["Name"].Value);
            }
        }
        /// <summary>
        /// Invert Selection link handler. Mark any unselected item as selected and any selected item as unselected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkInvertSelection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < clbFonts.Items.Count; i++)
            {
                if (clbFonts.GetItemChecked(i))
                    clbFonts.SetItemChecked(i, false);
                else
                    clbFonts.SetItemChecked(i, true);
            }
        
        }

        /// <summary>
        /// Get a list of user selected fonts to be used by the MainForm screen to copy to windows folder.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetSelectedFonts()
        {
            Dictionary<string, string> selectedItems = new Dictionary<string, string>();
            string root = Path.GetDirectoryName(Application.ExecutablePath);
            List<string> entries = new List<string>();
            foreach (string item in clbFonts.CheckedItems)
            {
                XmlNode font = document.SelectSingleNode(string.Format("/configuration/fonts/font[@Name='{0}']", item));
                string path = font.Attributes["Path"].Value;
                path = Path.Combine(root, path);
                selectedItems.Add(item, path);
            }
            return selectedItems;
        }
        private void clbFonts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }
    }
}