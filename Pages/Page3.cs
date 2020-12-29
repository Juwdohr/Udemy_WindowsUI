using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class Page3 : UserControl
    {
        #region Properties
        #endregion
        #region Variables
        #endregion
        int count = 0;
        #region Init & Load
        public Page3()
        {
            InitializeComponent();
        }
        private void Page3_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                ctl.MouseDown += new MouseEventHandler(base_MouseDown);
            }

            RefreshLabels(new object(), new EventArgs());

            GlobalConfig.LanguageChanged += new EventHandler(RefreshLabels);
        }
        public void RefreshLabels(object sender, EventArgs e)
        {
            count++;
            nameLabel.Text = String.Format("{0} {1}", Phrases.GetPhrase("PAGE3"), count);
        }
        private void base_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }
        #endregion
        #region Button Clicks
        public void Step1BtnClicked(string str)
        {
            SendMessageBox(Phrases.GetPhrase("PAGE3"));
        }
        private void SendMessageBox(string txt)
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            // msgBox.useButtons = "YN";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.Orange;
            msgBox.LabelText = txt;
            if (msgBox.ShowDialog() == DialogResult.Yes) { } else { }
            msgBox.Dispose();
        }
        #endregion
    }
}
