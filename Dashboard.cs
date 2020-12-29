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
        Page2 page2;
        Page3 page3;

        //Ribbon Panels
        TableLayoutPanel navigationTableLayoutPanel = new TableLayoutPanel();
        TableLayoutPanel pageTableLayoutPanel = new TableLayoutPanel();

        //Labels
        Label titleLabel = new Label();

        // Buttons
        Button exitBtn = new Button();
        Button aboutBtn = new Button();
        Button fullScreenBtn = new Button();
        Button languageBtn = new Button();
        Button backBtn = new Button();
        Button step1Btn = new Button();

        bool showFullScreen = false;
        string holdFullScreenCode = "";
        string whichControl = GlobalConfig.DASHBOARD;

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

            this.MouseDown += new MouseEventHandler(form_MouseDown);
            dashboardPanel.MouseDown += new MouseEventHandler(base_MouseDown);
            titleLabel.MouseDown += new MouseEventHandler(base_MouseDown);
            navigationTableLayoutPanel.MouseDown += new MouseEventHandler(base_MouseDown);

            foreach (DashboardTile dt in dashboardPanel.Controls.OfType<DashboardTile>())
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

            exitBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);
            aboutBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);
            fullScreenBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);
            languageBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);
            backBtn.MouseHover += new EventHandler(Utility.Control_MouseHover);
            step1Btn.MouseHover += new EventHandler(Utility.Control_MouseHover);

            fullScreenBtn.Click += new EventHandler(delegate { SetScreen(); });
            aboutBtn.Click += new EventHandler(delegate { ShowAboutBox(); });
            exitBtn.Click += new EventHandler(delegate { ExitApplication(); });
            languageBtn.Click += new EventHandler(delegate { ChangeLanguage(); });
            backBtn.Click += new EventHandler(delegate { ShowDashboard(); });
            step1Btn.Click += new EventHandler(delegate { Step1(); });

            BuildNavigationRibbonPanels();

            LoadDashboardTiles();

            SetScreen();

            RefreshLabels(new object(), new EventArgs());

            GlobalConfig.LanguageChanged += new EventHandler(RefreshLabels);
        }

        private void RefreshLabels(object sender, EventArgs e)
        {
            titleLabel.Text = Phrases.GetPhrase("DASHBOARD");
            aboutBtn.Name = Phrases.GetPhrase("ABOUT");
            exitBtn.Name = Phrases.GetPhrase("EXIT");
            backBtn.Name = Phrases.GetPhrase("BACK");
            step1Btn.Name = Phrases.GetPhrase("STEP1");
            languageBtn.Name = Phrases.GetPhrase(GlobalConfig.LANGUAGE == GlobalConfig.ENGLISH ? "ENGLISH" : "HEBREW");
            fullScreenBtn.Name = Phrases.GetPhrase(showFullScreen ? "WINDOW" : "FULLSCREEN:");
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
        private void LoadDashboardTiles()
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

            dashboardTopPanel.BackColor = Color.White;
            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(pageTableLayoutPanel);
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
                page1.MouseDown += new MouseEventHandler(form_MouseDown);
            }
            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page1);
            page1.RefreshLabels(null, null);
            step1Btn.Tag = page1;
            whichControl = GlobalConfig.PAGE;
        }
        public void dashboardTile2_Run(string str)
        {
            if (page2 == null)
            {
                page2 = new Page2();
                page2.Dock = DockStyle.Fill;
                page2.MouseDown += new MouseEventHandler(form_MouseDown);
            }
            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page2);
            page2.RefreshLabels(null, null);
            step1Btn.Tag = page2;
            whichControl = GlobalConfig.PAGE;
        }
        public void dashboardTile3_Run(string str)
        {
            if (page3 == null)
            {
                page3 = new Page3();
                page3.Dock = DockStyle.Fill;
                page3.MouseDown += new MouseEventHandler(form_MouseDown);
            }
            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(page3);
            page3.RefreshLabels(null, null);
            step1Btn.Tag = page3;
            whichControl = GlobalConfig.PAGE;
        }
        #endregion
        #region build navigation
        private void BuildNavigationRibbonPanels()
        {
            // Navigator Panel
            aboutBtn.BackColor = Color.Transparent;
            aboutBtn.BackgroundImage = Properties.Resources.SmallI;
            aboutBtn.BackgroundImageLayout = ImageLayout.Center;
            aboutBtn.Dock = DockStyle.Fill;
            aboutBtn.FlatAppearance.BorderColor = Color.White;
            aboutBtn.FlatAppearance.BorderSize = 0;
            aboutBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            aboutBtn.FlatStyle = FlatStyle.Flat;
            aboutBtn.Margin = new Padding(0);
            //aboutButton.Name = Phrases.GetPhrase("ABOUT");
            aboutBtn.UseVisualStyleBackColor = false;

            exitBtn.BackColor = Color.Transparent;
            exitBtn.BackgroundImage = Properties.Resources.SmallX;
            exitBtn.BackgroundImageLayout = ImageLayout.Center;
            exitBtn.Dock = DockStyle.Fill;
            exitBtn.FlatAppearance.BorderColor = Color.White;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.Margin = new Padding(0);
            // exitButton.Name = Phrases.GetPhrase("EXIT");
            exitBtn.UseVisualStyleBackColor = false;

            languageBtn.BackColor = Color.Transparent;
            languageBtn.BackgroundImage = Properties.Resources.SmallLanguage;
            languageBtn.BackgroundImageLayout = ImageLayout.Center;
            languageBtn.Dock = DockStyle.Fill;
            languageBtn.FlatAppearance.BorderColor = Color.White;
            languageBtn.FlatAppearance.BorderSize = 0;
            languageBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            languageBtn.FlatStyle = FlatStyle.Flat;
            languageBtn.Margin = new Padding(0);
            //languageBtn.Name = Phrases.GetPhrase("HEBREW");
            languageBtn.UseVisualStyleBackColor = false;

            fullScreenBtn.BackColor = Color.Transparent;
            fullScreenBtn.BackgroundImage = Properties.Resources.SmallWindow;
            fullScreenBtn.BackgroundImageLayout = ImageLayout.Center;
            fullScreenBtn.Dock = DockStyle.Fill;
            fullScreenBtn.FlatAppearance.BorderColor = Color.White;
            fullScreenBtn.FlatAppearance.BorderSize = 0;
            fullScreenBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            fullScreenBtn.FlatStyle = FlatStyle.Flat;
            fullScreenBtn.Margin = new Padding(0);
            //fullScreenButton.Name = Phrases.GetPhrase("WINDOW");
            fullScreenBtn.UseVisualStyleBackColor = false;


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

            navigationTableLayoutPanel.Controls.Add(exitBtn, 10, 0);
            navigationTableLayoutPanel.Controls.Add(aboutBtn, 9, 0);
            navigationTableLayoutPanel.Controls.Add(fullScreenBtn, 8, 0);
            navigationTableLayoutPanel.Controls.Add(languageBtn, 7, 0);

            navigationTableLayoutPanel.Margin = new Padding(0);

            navigationTableLayoutPanel.RowCount = 1;
            navigationTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            navigationTableLayoutPanel.Size = new Size(875, 75);
            navigationTableLayoutPanel.Dock = DockStyle.Fill;
            navigationTableLayoutPanel.BackColor = Color.Transparent;

            // Ribbon Panel
            backBtn.BackColor = Color.Transparent;
            backBtn.BackgroundImage = Properties.Resources.MedGreyArrow;
            backBtn.BackgroundImageLayout = ImageLayout.Center;
            backBtn.Dock = DockStyle.Fill;
            backBtn.FlatAppearance.BorderColor = Color.White;
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.Margin = new Padding(0);
            // backBtn.Name = Phrases.GetPhrase("BACK");
            backBtn.UseVisualStyleBackColor = false;

            step1Btn.BackColor = Color.Transparent;
            step1Btn.BackgroundImage = Properties.Resources.MedStep1;
            step1Btn.BackgroundImageLayout = ImageLayout.Center;
            step1Btn.Dock = DockStyle.Fill;
            step1Btn.FlatAppearance.BorderColor = Color.White;
            step1Btn.FlatAppearance.BorderSize = 0;
            step1Btn.FlatAppearance.MouseOverBackColor = Color.SlateGray;
            step1Btn.FlatStyle = FlatStyle.Flat;
            step1Btn.Margin = new Padding(0);
            // step1Btn.Name = Phrases.GetPhrase("STEP1");
            step1Btn.UseVisualStyleBackColor = false;

            pageTableLayoutPanel.ColumnCount = 11;
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            pageTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));

            pageTableLayoutPanel.Controls.Add(step1Btn, 5, 0);
            pageTableLayoutPanel.Controls.Add(backBtn, 0, 0);

            pageTableLayoutPanel.Margin = new Padding(0);

            pageTableLayoutPanel.RowCount = 1;
            pageTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pageTableLayoutPanel.Size = new Size(875, 75);
            pageTableLayoutPanel.Dock = DockStyle.Fill;
            pageTableLayoutPanel.BackColor = Color.Transparent;

        }
        #endregion
        #region Set Ribbon Panel
        private void SetRibbonPanel()
        {
            if (whichControl == GlobalConfig.PAGE)
            {
                dashboardTopPanel.BackColor = Color.White;
                dashboardTopPanel.Controls.Clear();
                dashboardTopPanel.Controls.Add(pageTableLayoutPanel);
            }
            else
            {
                dashboardTopPanel.BackColor = Color.White;
                dashboardTopPanel.Controls.Clear();
                dashboardTopPanel.Controls.Add(titleLabel);
            }
            
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
        
        private void base_MouseDown(object sender, MouseEventArgs e)
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

            SetRibbonPanel();

            GlobalConfig.LanguageChangedFunction();
        }
        #endregion
        #region set screen
        private void SetScreen() 
        {
            if(showFullScreen)
            {
                showFullScreen = false;
                fullScreenBtn.Name = Phrases.GetPhrase("FULLSCREEN");
            }
            else
            {
                showFullScreen = true;
                fullScreenBtn.Name = Phrases.GetPhrase("WINDOW");
            }

            Rectangle workingArea = Screen.GetWorkingArea(this);
            
            if(showFullScreen)
            {
                this.WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                fullScreenBtn.BackgroundImage = Properties.Resources.SmallWindow;
                fullScreenBtn.Refresh();
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
                fullScreenBtn.BackgroundImage = Properties.Resources.SmallClosedWindow;
                fullScreenBtn.Refresh();
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
        #region Step1
        private void Step1()
        {
            ///TODO: implement Step 1
            object page = step1Btn.Tag;

            //MessageBox.Show(tile.Name + " Tile Clicked");

            page.GetType().InvokeMember("Step1BtnClicked",
                System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
                null, page, new string[] { "" });


        }
        #endregion
        #region Back
        private void ShowDashboard()
        {
            dashboardTopPanel.BackColor = Color.White;
            dashboardTopPanel.Controls.Clear();
            dashboardTopPanel.Controls.Add(titleLabel);

            dashboardBottomPanel.Controls.Clear();
            dashboardBottomPanel.Controls.Add(dashboardPanel);
            whichControl = GlobalConfig.DASHBOARD;
        }
        #endregion
    }
}