namespace WindowsUI
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dashboardLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dashboardTopPanel = new System.Windows.Forms.Panel();
            this.dashboardBottomPanel = new System.Windows.Forms.Panel();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.dashboardTile3 = new WindowsUI.DashboardTile();
            this.dashboardTile2 = new WindowsUI.DashboardTile();
            this.dashboardTile1 = new WindowsUI.DashboardTile();
            this.dashboardLayoutPanel.SuspendLayout();
            this.dashboardBottomPanel.SuspendLayout();
            this.dashboardPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dashboardLayoutPanel
            // 
            this.dashboardLayoutPanel.ColumnCount = 1;
            this.dashboardLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dashboardLayoutPanel.Controls.Add(this.dashboardTopPanel, 0, 0);
            this.dashboardLayoutPanel.Controls.Add(this.dashboardBottomPanel, 0, 1);
            this.dashboardLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.dashboardLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.dashboardLayoutPanel.Name = "dashboardLayoutPanel";
            this.dashboardLayoutPanel.RowCount = 2;
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dashboardLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dashboardLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.dashboardLayoutPanel.TabIndex = 0;
            // 
            // dashboardTopPanel
            // 
            this.dashboardTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardTopPanel.Location = new System.Drawing.Point(3, 3);
            this.dashboardTopPanel.Name = "dashboardTopPanel";
            this.dashboardTopPanel.Size = new System.Drawing.Size(794, 69);
            this.dashboardTopPanel.TabIndex = 0;
            // 
            // dashboardBottomPanel
            // 
            this.dashboardBottomPanel.Controls.Add(this.dashboardPanel);
            this.dashboardBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardBottomPanel.Location = new System.Drawing.Point(1, 76);
            this.dashboardBottomPanel.Margin = new System.Windows.Forms.Padding(1);
            this.dashboardBottomPanel.Name = "dashboardBottomPanel";
            this.dashboardBottomPanel.Size = new System.Drawing.Size(798, 373);
            this.dashboardBottomPanel.TabIndex = 2;
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.Controls.Add(this.dashboardTile3);
            this.dashboardPanel.Controls.Add(this.dashboardTile2);
            this.dashboardPanel.Controls.Add(this.dashboardTile1);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardPanel.Location = new System.Drawing.Point(0, 0);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(798, 373);
            this.dashboardPanel.TabIndex = 1;
            // 
            // dashboardTile3
            // 
            this.dashboardTile3.BackColor = System.Drawing.Color.Linen;
            this.dashboardTile3.BackgroundImage = global::WindowsUI.Properties.Resources.number3_PNG14959;
            this.dashboardTile3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dashboardTile3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dashboardTile3.Location = new System.Drawing.Point(524, 94);
            this.dashboardTile3.MovementDirection = WindowsUI.DashboardTile.Direction.Any;
            this.dashboardTile3.Name = "dashboardTile3";
            this.dashboardTile3.RunMethodName = "";
            this.dashboardTile3.Size = new System.Drawing.Size(192, 159);
            this.dashboardTile3.TabIndex = 2;
            // 
            // dashboardTile2
            // 
            this.dashboardTile2.BackColor = System.Drawing.Color.Linen;
            this.dashboardTile2.BackgroundImage = global::WindowsUI.Properties.Resources._2_Number_PNG;
            this.dashboardTile2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dashboardTile2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dashboardTile2.Location = new System.Drawing.Point(302, 94);
            this.dashboardTile2.MovementDirection = WindowsUI.DashboardTile.Direction.Any;
            this.dashboardTile2.Name = "dashboardTile2";
            this.dashboardTile2.RunMethodName = "";
            this.dashboardTile2.Size = new System.Drawing.Size(170, 159);
            this.dashboardTile2.TabIndex = 1;
            // 
            // dashboardTile1
            // 
            this.dashboardTile1.BackColor = System.Drawing.Color.Linen;
            this.dashboardTile1.BackgroundImage = global::WindowsUI.Properties.Resources.number1_634914_640;
            this.dashboardTile1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dashboardTile1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dashboardTile1.Location = new System.Drawing.Point(72, 94);
            this.dashboardTile1.MovementDirection = WindowsUI.DashboardTile.Direction.Any;
            this.dashboardTile1.Name = "dashboardTile1";
            this.dashboardTile1.RunMethodName = "";
            this.dashboardTile1.Size = new System.Drawing.Size(180, 159);
            this.dashboardTile1.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dashboardLayoutPanel);
            this.Name = "Dashboard";
            this.Text = "Windows UI";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.dashboardLayoutPanel.ResumeLayout(false);
            this.dashboardBottomPanel.ResumeLayout(false);
            this.dashboardPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dashboardLayoutPanel;
        private System.Windows.Forms.Panel dashboardTopPanel;
        private System.Windows.Forms.Panel dashboardPanel;
        private DashboardTile dashboardTile2;
        private DashboardTile dashboardTile1;
        private DashboardTile dashboardTile3;
        private System.Windows.Forms.Panel dashboardBottomPanel;
    }
}

