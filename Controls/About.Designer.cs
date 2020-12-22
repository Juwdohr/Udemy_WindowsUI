namespace WindowsUI.Controls
{
    partial class About
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.copyrightLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.assemblyLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.descriptionLbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.copyrightLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.versionLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.assemblyLbl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1540, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.Location = new System.Drawing.Point(3, 135);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(1534, 45);
            this.descriptionLbl.TabIndex = 3;
            this.descriptionLbl.Text = "description";
            this.descriptionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrightLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyrightLbl.Location = new System.Drawing.Point(3, 90);
            this.copyrightLbl.Name = "copyrightLbl";
            this.copyrightLbl.Size = new System.Drawing.Size(1534, 45);
            this.copyrightLbl.TabIndex = 2;
            this.copyrightLbl.Text = "copyright";
            this.copyrightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.Location = new System.Drawing.Point(3, 45);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(1534, 45);
            this.versionLbl.TabIndex = 1;
            this.versionLbl.Text = "version";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // assemblyLbl
            // 
            this.assemblyLbl.AutoSize = true;
            this.assemblyLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assemblyLbl.Location = new System.Drawing.Point(3, 0);
            this.assemblyLbl.Name = "assemblyLbl";
            this.assemblyLbl.Size = new System.Drawing.Size(1534, 45);
            this.assemblyLbl.TabIndex = 0;
            this.assemblyLbl.Text = "assembly";
            this.assemblyLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "About";
            this.Size = new System.Drawing.Size(1540, 180);
            this.Load += new System.EventHandler(this.About_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label copyrightLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label assemblyLbl;
    }
}
