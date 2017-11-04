namespace QLY_Sinhvien
{
    partial class frmMain
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
            this.mnuQLySV = new System.Windows.Forms.MenuStrip();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.lớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLopGv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusinhvien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnumonhoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSVtheolop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnucapnhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuchonHK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKQHT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutienich = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudangnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuthoatDN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudoipass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnugthieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnudong = new System.Windows.Forms.ToolStripMenuItem();
            this.lớpCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQLySV.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuQLySV
            // 
            this.mnuQLySV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuLieu,
            this.mnucapnhat,
            this.mnutienich});
            this.mnuQLySV.Location = new System.Drawing.Point(0, 0);
            this.mnuQLySV.Name = "mnuQLySV";
            this.mnuQLySV.Size = new System.Drawing.Size(659, 24);
            this.mnuQLySV.TabIndex = 0;
            this.mnuQLySV.Text = "menuStrip1";
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLop,
            this.mnusinhvien,
            this.mnumonhoc,
            this.mnuSVtheolop});
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(56, 20);
            this.mnuDuLieu.Text = "Dữ liệu";
            // 
            // mnuLop
            // 
            this.mnuLop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lớpToolStripMenuItem,
            this.mnuLopGv,
            this.lớpCommandToolStripMenuItem});
            this.mnuLop.Name = "mnuLop";
            this.mnuLop.Size = new System.Drawing.Size(169, 22);
            this.mnuLop.Text = "Lớp ";
            this.mnuLop.Click += new System.EventHandler(this.mnuLop_Click);
            // 
            // lớpToolStripMenuItem
            // 
            this.lớpToolStripMenuItem.Name = "lớpToolStripMenuItem";
            this.lớpToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lớpToolStripMenuItem.Text = "Lớp";
            this.lớpToolStripMenuItem.Click += new System.EventHandler(this.lớpToolStripMenuItem_Click);
            // 
            // mnuLopGv
            // 
            this.mnuLopGv.Name = "mnuLopGv";
            this.mnuLopGv.Size = new System.Drawing.Size(154, 22);
            this.mnuLopGv.Text = "Lớp GirdView";
            this.mnuLopGv.Click += new System.EventHandler(this.lớpGirdViewToolStripMenuItem_Click);
            // 
            // mnusinhvien
            // 
            this.mnusinhvien.Name = "mnusinhvien";
            this.mnusinhvien.Size = new System.Drawing.Size(169, 22);
            this.mnusinhvien.Text = "Sinh viên";
            // 
            // mnumonhoc
            // 
            this.mnumonhoc.Name = "mnumonhoc";
            this.mnumonhoc.Size = new System.Drawing.Size(169, 22);
            this.mnumonhoc.Text = "Môn học";
            // 
            // mnuSVtheolop
            // 
            this.mnuSVtheolop.Name = "mnuSVtheolop";
            this.mnuSVtheolop.Size = new System.Drawing.Size(169, 22);
            this.mnuSVtheolop.Text = "Sinh viên theo lớp";
            // 
            // mnucapnhat
            // 
            this.mnucapnhat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuchonHK,
            this.mnuKQHT});
            this.mnucapnhat.Name = "mnucapnhat";
            this.mnucapnhat.Size = new System.Drawing.Size(67, 20);
            this.mnucapnhat.Text = "Cập nhật";
            // 
            // mnuchonHK
            // 
            this.mnuchonHK.Name = "mnuchonHK";
            this.mnuchonHK.Size = new System.Drawing.Size(157, 22);
            this.mnuchonHK.Text = "Chọn học kì";
            // 
            // mnuKQHT
            // 
            this.mnuKQHT.Name = "mnuKQHT";
            this.mnuKQHT.Size = new System.Drawing.Size(157, 22);
            this.mnuKQHT.Text = "Kết quả học tập";
            // 
            // mnutienich
            // 
            this.mnutienich.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnudangnhap,
            this.mnuthoatDN,
            this.mnudoipass,
            this.mnugthieu,
            this.mnudong});
            this.mnutienich.Name = "mnutienich";
            this.mnutienich.Size = new System.Drawing.Size(61, 20);
            this.mnutienich.Text = "Tiện ích";
            // 
            // mnudangnhap
            // 
            this.mnudangnhap.Name = "mnudangnhap";
            this.mnudangnhap.Size = new System.Drawing.Size(165, 22);
            this.mnudangnhap.Text = "Đăng nhập";
            this.mnudangnhap.Click += new System.EventHandler(this.mnudangnhap_Click);
            // 
            // mnuthoatDN
            // 
            this.mnuthoatDN.Name = "mnuthoatDN";
            this.mnuthoatDN.Size = new System.Drawing.Size(165, 22);
            this.mnuthoatDN.Text = "Thoát đăng nhập";
            // 
            // mnudoipass
            // 
            this.mnudoipass.Name = "mnudoipass";
            this.mnudoipass.Size = new System.Drawing.Size(165, 22);
            this.mnudoipass.Text = "Đổi mật khẩu";
            // 
            // mnugthieu
            // 
            this.mnugthieu.Name = "mnugthieu";
            this.mnugthieu.Size = new System.Drawing.Size(165, 22);
            this.mnugthieu.Text = "Giới thiệu ";
            this.mnugthieu.Click += new System.EventHandler(this.mnugthieu_Click);
            // 
            // mnudong
            // 
            this.mnudong.Name = "mnudong";
            this.mnudong.Size = new System.Drawing.Size(165, 22);
            this.mnudong.Text = "Thoát";
            this.mnudong.Click += new System.EventHandler(this.mnudong_Click);
            // 
            // lớpCommandToolStripMenuItem
            // 
            this.lớpCommandToolStripMenuItem.Name = "lớpCommandToolStripMenuItem";
            this.lớpCommandToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.lớpCommandToolStripMenuItem.Text = "Lớp Command";
            this.lớpCommandToolStripMenuItem.Click += new System.EventHandler(this.lớpCommandToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 299);
            this.Controls.Add(this.mnuQLySV);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuQLySV;
            this.Name = "frmMain";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuQLySV.ResumeLayout(false);
            this.mnuQLySV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuQLySV;
        public System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        private System.Windows.Forms.ToolStripMenuItem mnuLop;
        private System.Windows.Forms.ToolStripMenuItem mnusinhvien;
        private System.Windows.Forms.ToolStripMenuItem mnumonhoc;
        private System.Windows.Forms.ToolStripMenuItem mnuSVtheolop;
        public System.Windows.Forms.ToolStripMenuItem mnucapnhat;
        private System.Windows.Forms.ToolStripMenuItem mnuchonHK;
        private System.Windows.Forms.ToolStripMenuItem mnuKQHT;
        public System.Windows.Forms.ToolStripMenuItem mnutienich;
        public System.Windows.Forms.ToolStripMenuItem mnudangnhap;
        public System.Windows.Forms.ToolStripMenuItem mnuthoatDN;
        public System.Windows.Forms.ToolStripMenuItem mnudoipass;
        private System.Windows.Forms.ToolStripMenuItem mnugthieu;
        private System.Windows.Forms.ToolStripMenuItem mnudong;
        private System.Windows.Forms.ToolStripMenuItem lớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLopGv;
        private System.Windows.Forms.ToolStripMenuItem lớpCommandToolStripMenuItem;
    }
}

