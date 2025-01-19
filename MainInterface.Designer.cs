namespace ExpenseTracker
{
    partial class MainInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainInterface));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.LogOutBtn = new Guna.UI2.WinForms.Guna2Button();
            this.CategoryBtn = new Guna.UI2.WinForms.Guna2Button();
            this.IncomeExp = new Guna.UI2.WinForms.Guna2Button();
            this.IncomeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.OverviewBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.UsernameLbl);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1351, 101);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLbl.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.Location = new System.Drawing.Point(1180, 41);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(104, 23);
            this.UsernameLbl.TabIndex = 2;
            this.UsernameLbl.Text = "User Name";
            this.UsernameLbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(1115, 24);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(50, 54);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 1;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.Click += new System.EventHandler(this.guna2PictureBox2_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(44, -91);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(338, 189);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.LogOutBtn);
            this.guna2Panel2.Controls.Add(this.CategoryBtn);
            this.guna2Panel2.Controls.Add(this.IncomeExp);
            this.guna2Panel2.Controls.Add(this.IncomeBtn);
            this.guna2Panel2.Controls.Add(this.OverviewBtn);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 101);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(271, 686);
            this.guna2Panel2.TabIndex = 1;
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LogOutBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LogOutBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LogOutBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LogOutBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.LogOutBtn.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutBtn.ForeColor = System.Drawing.Color.Black;
            this.LogOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("LogOutBtn.Image")));
            this.LogOutBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.LogOutBtn.ImageSize = new System.Drawing.Size(35, 35);
            this.LogOutBtn.Location = new System.Drawing.Point(0, 617);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(268, 69);
            this.LogOutBtn.TabIndex = 4;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // CategoryBtn
            // 
            this.CategoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.CategoryBtn.BorderRadius = 10;
            this.CategoryBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CategoryBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CategoryBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CategoryBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CategoryBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.CategoryBtn.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryBtn.ForeColor = System.Drawing.Color.Black;
            this.CategoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("CategoryBtn.Image")));
            this.CategoryBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CategoryBtn.ImageSize = new System.Drawing.Size(35, 35);
            this.CategoryBtn.Location = new System.Drawing.Point(3, 302);
            this.CategoryBtn.Name = "CategoryBtn";
            this.CategoryBtn.Size = new System.Drawing.Size(281, 69);
            this.CategoryBtn.TabIndex = 3;
            this.CategoryBtn.Text = "Categories";
            this.CategoryBtn.Click += new System.EventHandler(this.CategoryBtn_Click);
            // 
            // IncomeExp
            // 
            this.IncomeExp.BackColor = System.Drawing.Color.Transparent;
            this.IncomeExp.BorderRadius = 10;
            this.IncomeExp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.IncomeExp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.IncomeExp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.IncomeExp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.IncomeExp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.IncomeExp.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IncomeExp.ForeColor = System.Drawing.Color.Black;
            this.IncomeExp.Image = ((System.Drawing.Image)(resources.GetObject("IncomeExp.Image")));
            this.IncomeExp.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IncomeExp.ImageSize = new System.Drawing.Size(35, 35);
            this.IncomeExp.Location = new System.Drawing.Point(3, 227);
            this.IncomeExp.Name = "IncomeExp";
            this.IncomeExp.Size = new System.Drawing.Size(281, 69);
            this.IncomeExp.TabIndex = 2;
            this.IncomeExp.Text = "Expenses";
            this.IncomeExp.Click += new System.EventHandler(this.IncomeExp_Click);
            // 
            // IncomeBtn
            // 
            this.IncomeBtn.BackColor = System.Drawing.Color.Transparent;
            this.IncomeBtn.BorderRadius = 10;
            this.IncomeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.IncomeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.IncomeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.IncomeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.IncomeBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.IncomeBtn.Font = new System.Drawing.Font("Bahnschrift", 14.25F);
            this.IncomeBtn.ForeColor = System.Drawing.Color.Black;
            this.IncomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("IncomeBtn.Image")));
            this.IncomeBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IncomeBtn.ImageSize = new System.Drawing.Size(35, 35);
            this.IncomeBtn.Location = new System.Drawing.Point(3, 152);
            this.IncomeBtn.Name = "IncomeBtn";
            this.IncomeBtn.Size = new System.Drawing.Size(281, 69);
            this.IncomeBtn.TabIndex = 1;
            this.IncomeBtn.Text = "Income";
            this.IncomeBtn.Click += new System.EventHandler(this.IncomeBtn_Click);
            // 
            // OverviewBtn
            // 
            this.OverviewBtn.BackColor = System.Drawing.Color.Transparent;
            this.OverviewBtn.BorderRadius = 10;
            this.OverviewBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OverviewBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OverviewBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OverviewBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OverviewBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.OverviewBtn.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverviewBtn.ForeColor = System.Drawing.Color.Black;
            this.OverviewBtn.Image = ((System.Drawing.Image)(resources.GetObject("OverviewBtn.Image")));
            this.OverviewBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.OverviewBtn.ImageSize = new System.Drawing.Size(35, 35);
            this.OverviewBtn.Location = new System.Drawing.Point(3, 77);
            this.OverviewBtn.Name = "OverviewBtn";
            this.OverviewBtn.Size = new System.Drawing.Size(281, 69);
            this.OverviewBtn.TabIndex = 0;
            this.OverviewBtn.Text = "Dashboard";
            this.OverviewBtn.Click += new System.EventHandler(this.OverviewBtn_Click);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Location = new System.Drawing.Point(274, 107);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1070, 680);
            this.guna2Panel3.TabIndex = 2;
            this.guna2Panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel3_Paint);
            // 
            // MainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1351, 787);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainInterface";
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button IncomeExp;
        private Guna.UI2.WinForms.Guna2Button IncomeBtn;
        private Guna.UI2.WinForms.Guna2Button OverviewBtn;
        private Guna.UI2.WinForms.Guna2Button CategoryBtn;
        public System.Windows.Forms.Label UsernameLbl;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button LogOutBtn;
    }
}