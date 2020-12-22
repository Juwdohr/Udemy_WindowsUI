using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsUI.Controls
{
    public partial class About : UserControl
    {

        #region properties

        private string AssemblyTitle
        {
            get
            {
                string _title = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    _title = ((AssemblyTitleAttribute)attributes[0]).Title;
                }
                return _title;
            }
        }
        private string AssemblyVersion
        {
            get 
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private string AssemblyDescription
        {
            get
            {
                string _description = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    _description = ((AssemblyDescriptionAttribute)attributes[0]).Description;
                }
                return _description;
            }
        }
        private string AssemblyCopyright
        {
            get 
            {
                string _copyright = "";
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length > 0)
                {
                    _copyright = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                }
                return _copyright;
            }
        }

        #endregion
        #region init & load
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            assemblyLbl.Text = AssemblyTitle;
            versionLbl.Text = AssemblyVersion;
            copyrightLbl.Text = AssemblyCopyright;
            descriptionLbl.Text = AssemblyDescription;
        }
        #endregion
    }
}
