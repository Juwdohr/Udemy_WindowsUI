using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsUI.Controls;

namespace WindowsUI
{
    public partial class PopupMessageBox : Form
    {

        #region properties

        private string _labelText;
        private string _returnText;
        private string _useButtons;
        private string _boxType;
        private Color _bColor;
        private Color _fColor;
        private string _mode;
        private bool _isTransparent;
        private Point _main_location;

        public string LabelText
        {
            get { return _labelText; }
            set { _labelText = value; }
        }

        public string ReturnText
        {
            get { return _returnText; }
            set { _returnText = value; }
        }

        public string UseButtons
        {
            get { return _useButtons; }
            set { _useButtons = value; }
        }

        public string BoxType
        {
            get { return _boxType; }
            set { _boxType = value; }
        }

        public Color BColor
        {
            get { return _bColor; }
            set { _bColor = value; }
        }

        public Color FColor
        {
            get { return _fColor; }
            set { _fColor = value; }
        }

        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public bool IsTransparent
        {
            get { return _isTransparent; }
            set { _isTransparent = value; }
        }

        public Point Main_Location
        {
            get { return _main_location; }
            set { _main_location = value; }
        }

        #endregion

        System.Timers.Timer DelayTimer;
        BlackTransparentBackground bb = new BlackTransparentBackground();
        Rectangle workingArea;
        //Label invalidLabel;

        public PopupMessageBox()
        {
            InitializeComponent();

            workingArea = Screen.GetWorkingArea(this);

            this.StartPosition = FormStartPosition.Manual;
            this.Location = Location;
            this.WindowState = FormWindowState.Maximized;

            this.Cursor = Cursors.Hand;
            textLabel.Cursor = Cursors.Hand;
            yesButton.Cursor = Cursors.Hand;
            okButton.Cursor = Cursors.Hand;
            noButton.Cursor = Cursors.Hand;
            panel1.Cursor = Cursors.Hand;
            tableLayoutPanel1.Cursor = Cursors.Hand;
            tableLayoutPanel2.Cursor = Cursors.Hand;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (UseButtons == "YN" || UseButtons == "OC")
                {
                    noButton.PerformClick();
                }
                return true;    // indicate that you handled this keystroke
            }
            else if (keyData == Keys.Enter)
            {
                if (UseButtons == "YN" || UseButtons == "OC")
                {
                    yesButton.PerformClick();
                    return true;
                }
                else
                {
                    okButton.Visible = true;
                }
                return false;    // indicate that you handled this keystroke
            }


            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        

        public void ResetAllControlsBackColor(Control control)
        {
            control.BackColor = BColor;
            if (control.HasChildren)
            {
                // Recursively call this method for each child control. 
                foreach (Control childControl in control.Controls)
                {
                    ResetAllControlsBackColor(childControl);
                }
            }
        }

        public void ResetAllControlsForeColor(Control control)
        {
            control.ForeColor = this.FColor;
            if (control is Button)
            {
                Button button = control as Button;
                button.FlatAppearance.BorderColor = FColor;
                if (IsTransparent)
                {
                    button.ForeColor = BColor;
                    button.FlatAppearance.BorderColor = BColor;
                }
            }
            foreach (Control childControl in control.Controls)
            {
                ResetAllControlsForeColor(childControl);
            }
            if (IsTransparent)
            {
                textLabel.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void PopupMessageBox_Load(object sender, EventArgs e)
        { 
            int popupTimer = 4;
      
            if (BColor != null) 
            {
                ResetAllControlsBackColor(panel1);
            }
            if (FColor != null)
            {
                ResetAllControlsForeColor(panel1);
            }

            bb.StartPosition = FormStartPosition.Manual;
            bb.Location = Main_Location;
            bb.WindowState = FormWindowState.Maximized;
            bb.Cursor = Cursors.Hand;
            bb.Show();

            if (BoxType == "About")
            {
                panel1.Controls.Remove(textLabel);
                About about = new About();
                about.Cursor = Cursors.Hand;
                about.Top = 0;
                about.Width = workingArea.Width;
                about.BackColor = BColor;
                panel1.Controls.Add(about);
            }
            else
            {
                textLabel.Text = LabelText;
            }

            yesButton.Visible = false;
            noButton.Visible = false;
            okButton.Visible = false;

            if (UseButtons == "YN")
            {
                yesButton.Visible = true;
                noButton.Visible = true;
            }
            else if (UseButtons == "OC")
            {
                yesButton.Visible = true;
                noButton.Visible = true;
                noButton.Text = "Cancel";
                yesButton.Text = "OK";
            }
            else
            {
                okButton.Visible = true;
            }

            DelayTimer = new System.Timers.Timer(popupTimer * 1000);
            DelayTimer.Elapsed += new System.Timers.ElapsedEventHandler(DelayTimer_Elapsed);
     
            if (UseButtons == "YN" || UseButtons == "OC" 
                || BoxType == "Wait"  || BoxType == "About" ) { } // don't enable timer
            else DelayTimer.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bb.closeButton.PerformClick();
            if (DelayTimer != null)   DelayTimer.Enabled = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        void DelayTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DelayTimer.Enabled = false;

            this.Invoke(new EventHandler(delegate
            {
                bb.closeButton.PerformClick();
                this.Close();
            }));
        }

        private void PopupMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DelayTimer.Enabled) DelayTimer.Enabled = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            bb.closeButton.PerformClick();
            if (DelayTimer != null) DelayTimer.Enabled = false;
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            bb.closeButton.PerformClick();
            if (DelayTimer != null) DelayTimer.Enabled = false;
            DialogResult = DialogResult.Yes;
            Close();
        }

    }
}
