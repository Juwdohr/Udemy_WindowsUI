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
    public partial class Dashboard : Form
    {
        #region properties
        #endregion
        #region variables

        Page1 page1;

        //Ribbon Panels
        TableLayoutPanel navigationTableLayoutPanel = new TableLayoutPanel();

        //Labels
        Label titleLabel = new Label();

        // Buttons
        Button exitButton = new Button();
        Button aboutButton = new Button();
        Button fullScreenButton = new Button();
        Button languageBtn = new Button();

        bool showFullScreen = false;

        #endregion
        #region init & load
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GlobalConfig.LANGUAGE = GlobalConfig.ENGLISH;
            this.Icon = MakeIcon();

            BuildNavigationRibbonPanel();
            LoadDashboard();
            SetScreen();

            this.MouseDown += new MouseEventHandler(form_MouseDown);
            dashboardPanel.MouseDown += new MouseEventHandler(tableLayoutPanel1_MouseDown);

            foreach(DashboardTile dt in dashboardPanel.Controls.OfType<DashboardTile>())
            {
                dt.TileClicked += new EventHandler(dashboardTile_TileClicked);
                dt.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
                dt.TileMoved += new EventHandler(dashboardTile_TileMoved);

                dt.RunMethodName += String.Format("{0}_Run", dt.Name);
            }

            //dashboardTile1.TileClicked += new EventHandler(dashboardTile_TileClicked);
            //dashboardTile1.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
            //dashboardTile1.TileMoved += new EventHandler(dashboardTile_TileMoved);

            //dashboardTile2.TileClicked += new EventHandler(dashboardTile_TileClicked);
            //dashboardTile2.TileRightClicked += new EventHandler(dashboardTile_TileRightClicked);
            //dashboardTile2.TileMoved += new EventHandler(dashboardTile_TileMoved);

            exitButton.MouseHover += new EventHandler(Utility.Control_MouseHover);
            aboutButton.MouseHover += new EventHandler(Utility.Control_MouseHover);
            fullScreenButton.MouseHover += new EventHandler(Utility.Control_MouseHover);
            languageBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);

            fullScreenButton.Click += new EventHandler(delegate { SetScreen(); });
            aboutButton.Click += new EventHandler(delegate { ShowAboutBox(); });
            exitButton.Click += new EventHandler(delegate { ExitApplication(); });
            languageBtn.Click += new EventHandler(delegate { ChangeLanguage(); });

            SetScreen();
            RefreshLabels(new object(), new EventArgs());

            GlobalConfig.LanguageChanged += new EventHandler(RefreshLabels);
        }
        private void RefreshLabels(object sender, EventArgs e)
        {
            titleLabel.Text = Phrases.GetPhrase("DASHBOARD");
            aboutButton.Name = Phrases.GetPhrase("ABOUT");
            exitButton.Name = Phrases.GetPhrase("EXIT");
            titleLabel.Text = Phrases.GetPhrase("DASHBOARD");
            languageBtn.Name = Phrases.GetPhrase(GlobalConfig.LANGUAGE == GlobalConfig.ENGLISH ? "ENGLISH" : "HEBREW");
            fullScreenButton.Name = Phrases.GetPhrase(showFullScreen ? "WINDOW" : "FULLSCREEN:");
        }
        #endregion
        #region make Icon
        private Icon MakeIcon()
        {
            Image img = Properties.Resources.BigDashboard;

            Bitmap newImg = new Bitmap(img);

            IntPtr Hicon = newImg.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);

            return myIcon;
        }
        #endregion
        #region Load Dashboard
        private void LoadDashboard()
        {
            titleLabel.Text = Phrases.GetPhrase("DASHBOARD");
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleLabel.ForeColor = Color.Silver;
            titleLabel.TextAlign = ContentAlignment.TopLeft;

            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(titleLabel);
        }
        #endregion

        #region Dashboard Tile Events
        private void dashboardTile_TileClicked(object sender, EventArgs e)
        {
            DashboardTile tile = sender as DashboardTile;

            //MessageBox.Show(tile.Name + " Tile Clicked");
            
            this.GetType().InvokeMember(tile.RunMethodName,
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
                null, this, new string[] { "" });

        }
        private void dashboardTile_TileRightClicked(object sender, EventArgs e)
        {
            DashboardTile tile = sender as DashboardTile;

            MessageBox.Show(tile.Name + " Right Clicked");
        }
        private void dashboardTile_TileMoved(object sender, EventArgs e)
        {
            this.Refresh();
        }
        public void dashboardTile1_Run(string str)
        {
            if (page1 == null)
            {
                page1 = new Page1();

                page1.Dock = DockStyle.Fill;

                //TODO: any other Itemsv 
            }
        }
        public void dashboardTile2_Run(string str)
        {
            MessageBox.Show("DashboardTile2 Clicked");
        }
        public void dashboardTile3_Run(string str)
        {
            MessageBox.Show("DashboardTile3 Clicked");
        }
        #endregion

        #region build navigation
        private void BuildNavigationRibbonPanel()
        {
            aboutButton.BackColor = Color.Transparent;
            aboutButton.BackgroundImage = Properties.Resources.SmallI;
            aboutButton.BackgroundImageLayout = ImageLayout.Center;
            aboutButton.Dock = DockStyle.Fill;
            aboutButton.FlatAppearance.BorderColor = Color.White;
            aboutButton.FlatAppearance.BorderSize = 0;
            aboutButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            aboutButton.FlatStyle = FlatStyle.Flat;
            aboutButton.Margin = new Padding(0);
            aboutButton.Name = Phrases.GetPhrase("ABOUT");
            aboutButton.UseVisualStyleBackColor = false;

            exitButton.BackColor = Color.Transparent;
            exitButton.BackgroundImage = Properties.Resources.SmallX;
            exitButton.BackgroundImageLayout = ImageLayout.Center;
            exitButton.Dock = DockStyle.Fill;
            exitButton.FlatAppearance.BorderColor = Color.White;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Margin = new Padding(0);
            exitButton.Name = Phrases.GetPhrase("EXIT");
            exitButton.UseVisualStyleBackColor = false;

            languageBtn.BackColor = Color.Transparent;
            languageBtn.BackgroundImage = Properties.Resources.SmallLanguage;
            languageBtn.BackgroundImageLayout = ImageLayout.Center;
            languageBtn.Dock = DockStyle.Fill;
            languageBtn.FlatAppearance.BorderColor = Color.White;
            languageBtn.FlatAppearance.BorderSize = 0;
            languageBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            languageBtn.FlatStyle = FlatStyle.Flat;
            languageBtn.Margin = new Padding(0);
            languageBtn.Name = Phrases.GetPhrase("HEBREW");
            languageBtn.UseVisualStyleBackColor = false;

            fullScreenButton.BackColor = Color.Transparent;
            fullScreenButton.BackgroundImage = Properties.Resources.SmallWindow;
            fullScreenButton.BackgroundImageLayout = ImageLayout.Center;
            fullScreenButton.Dock = DockStyle.Fill;
            fullScreenButton.FlatAppearance.BorderColor = Color.White;
            fullScreenButton.FlatAppearance.BorderSize = 0;
            fullScreenButton.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            fullScreenButton.FlatStyle = FlatStyle.Flat;
            fullScreenButton.Margin = new Padding(0);
            fullScreenButton.Name = Phrases.GetPhrase("WINDOW");
            fullScreenButton.UseVisualStyleBackColor = false;

            navigationTableLayoutPanel.ColumnCount = 11;
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            navigationTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));

            navigationTableLayoutPanel.Controls.Add(exitButton, 10, 0);
            navigationTableLayoutPanel.Controls.Add(aboutButton, 9, 0);
            navigationTableLayoutPanel.Controls.Add(fullScreenButton, 8, 0);
            navigationTableLayoutPanel.Controls.Add(languageBtn, 7, 0);

            navigationTableLayoutPanel.Margin = new Padding(0);

            navigationTableLayoutPanel.RowCount = 1;
            navigationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            navigationTableLayoutPanel.Size = new Size(875, 75);
            navigationTableLayoutPanel.Dock = DockStyle.Fill;
            navigationTableLayoutPanel.BackColor = Color.Transparent;
        }
        #endregion
        #region Set Ribbon Panel
        private void SetRibbonPanel()
        {
            dashboardTopPanel.BackColor = Color.White;
            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(titleLabel);
        }
        #endregion
        #region mouseDown
        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dashboardTopPanel.BackColor = Color.Silver;
                dashboardTopPanel.Controls.Clear();
                dashboardTopPanel.Controls.Add(navigationTableLayoutPanel);
            }
            else
            {
                SetRibbonPanel();
            }
        }
        
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        #endregion
        #region Change Language
        private void ChangeLanguage()
        {
            switch(GlobalConfig.LANGUAGE)
            {
                case GlobalConfig.ENGLISH:
                    GlobalConfig.LANGUAGE = GlobalConfig.HEBREW;
                    languageBtn.Name = Phrases.GetPhrase("HEBREW");
                    break;
                case GlobalConfig.HEBREW:
                    GlobalConfig.LANGUAGE = GlobalConfig.ENGLISH;
                    languageBtn.Name = Phrases.GetPhrase("ENGLISH");
                    break;
                default:
                    break;
            }

            GlobalConfig.LanguageChangedFunction();
        }
        #endregion
        #region set screen
        private void SetScreen() 
        {
            if(showFullScreen)
            {
                showFullScreen = false;
                fullScreenButton.Name = Phrases.GetPhrase("FULLSCREEN");
            }
            else
            {
                showFullScreen = true;
                fullScreenButton.Name = Phrases.GetPhrase("WINDOW");
            }

            Rectangle workingArea = Screen.GetWorkingArea(this);
            
            if(showFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                //TODO: Swap image here
            }
            else
            {
                this.ShowIcon = true;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
                this.Top = 0;
                this.Left = 0;
                this.Height = workingArea.Height;
                this.Width = workingArea.Width;
                //TODO: Swap Image here;
            }

            SetRibbonPanel();
        }
        #endregion
        #region show about box
        private void ShowAboutBox()
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            msgBox.Cursor = Cursors.Hand;
            msgBox.BoxType = "About";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.DeepSkyBlue;
            msgBox.Main_Location = Location;
            msgBox.Show();

            SetRibbonPanel();
        }
        #endregion
        #region exit application
        private void ExitApplication()
        {
            PopupMessageBox msgBox = new PopupMessageBox();
            msgBox.UseButtons = "YN";
            msgBox.FColor = Color.White;
            msgBox.BColor = Color.DodgerBlue;
            msgBox.LabelText = Phrases.GetPhrase("QUIT");
            if(msgBox.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                SetRibbonPanel();
            }
            msgBox.Dispose();
        }
        #endregion
    }
}
