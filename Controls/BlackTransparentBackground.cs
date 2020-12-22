using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class BlackTransparentBackground : Form
    {
        public Button closeButton = new Button();
        public BlackTransparentBackground()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }

        private void BlackTransparentBackground_Load(object sender, EventArgs e)
        {
            closeButton.Click += new EventHandler(closeButton_Click);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
