using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_Sinhvien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnugthieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chương trình quản lý sinh viên 2017","Giới thiệu");
        }

        private void mnudong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnudangnhap_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmdangnhap fDangNhap = new frmdangnhap(this);
            fDangNhap.ShowDialog();
        }
    }
}
