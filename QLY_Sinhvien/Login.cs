﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLY_Sinhvien
{
    public partial class frmdangnhap : Form
    {
        int intSoLanDangNhap;
        private frmMain fMain;
        public frmdangnhap(frmMain fm)
            : this()
        {
            fMain = fm;
        }
        public frmdangnhap()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (Mypublic.conMyConnection != null)
                Mypublic.conMyConnection = null;
            fMain.mnuDuLieu.Enabled = false;
            fMain.mnucapnhat.Enabled = false;
            fMain.mnudoipass.Enabled = false;
            fMain.mnuthoatDN.Enabled = false;
            this.Close();
        }

        private void frmdangnhap_Load(object sender, EventArgs e)
        {           
            intSoLanDangNhap = 0;
            txtMaychu.Text = "Localhost";
            txtMSSV.Text = "1065779";
            txtMatkhau.Text = "1679057";
            txtMatkhau.PasswordChar = '♥';
            txtMSSV.Focus();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            string sqlSelect, strPasswordSV;
            Mypublic.strsever = txtMaychu.Text;
            try
            {
                Mypublic.ConnectionDatabase();
                if (Mypublic.conMyConnection.State == ConnectionState.Open)
                {
                    Mypublic.strMSSV = txtMSSV.Text;
                    //strPasswordSV = txtMatkhau.Text;
                    strPasswordSV = Mypublic.MaHoaPassword(txtMatkhau.Text);
                    sqlSelect = "Select MSLop, QuyenSD From SinhVien Where MSSV = @MSSV And MatKhau = @MatKhau";
                    cmdCommand = new SqlCommand(sqlSelect, Mypublic.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@MSSV", txtMSSV.Text);
                    cmdCommand.Parameters.AddWithValue("@MatKhau", txtMatkhau.Text);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        Mypublic.strLop = drReader.GetString(0);
                        Mypublic.strQuyenSD = drReader.GetString(1);
                        drReader.Close();
                        Mypublic.XacDinhHKNK();
                        fMain.mnuDuLieu.Enabled = true;
                        fMain.mnucapnhat.Enabled = true;
                        fMain.mnudangnhap.Enabled = true;
                        fMain.mnudoipass.Enabled = true;
                        fMain.mnuthoatDN.Enabled = true;
                        MessageBox.Show("Đăng nhập thành công", "Thông báo");
                        Mypublic.conMyConnection.Close();
                        this.Close();
                    }
                    else
                        if (intSoLanDangNhap < 2)
                        {
                            MessageBox.Show("MSSV hoặc mật khẩu sai!", "Thông báo");
                            intSoLanDangNhap++;
                            txtMSSV.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi đăng nhâp, Form sẽ đóng", "Thông báo");
                            Mypublic.conMyConnection.Close();
                            fMain.mnuDuLieu.Enabled = false;
                            fMain.mnucapnhat.Enabled = false;
                            fMain.mnudoipass.Enabled = false;
                            fMain.mnuthoatDN.Enabled = false;
                        }
                }
                else
                    MessageBox.Show("Kết nối không thành công", "Thông báo");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thực hiện kết nối!", "Thông báo");
            }
        }
    }
}
