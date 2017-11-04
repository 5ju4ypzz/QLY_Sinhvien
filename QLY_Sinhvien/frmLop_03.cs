using System;
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
    public partial class frmLop_03 : Form
    {
        DataSet dsLop = new DataSet();
        bool blnThem = false;
        void DieuKhienKhiBinhThuong()
        {
            if (Mypublic.strQuyenSD == "AdminKhoa")
            {
                btnThem.Enabled = true;
                btnChinhsua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnChinhsua.Enabled = false;
                btnXoa.Enabled = false;
            }
            btnLuu.Enabled = false;
            btnKhongluu.Enabled = false;
            btnDong.Enabled = true;
            txtMSLop.ReadOnly = true;
            txtMSLop.BackColor = Color.White;
            txtTenLop.ReadOnly = true;
            txtTenLop.BackColor = Color.White;
            txtKhoaHoc.ReadOnly = true;
            txtKhoaHoc.BackColor = Color.White;
        }
        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhsua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongluu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtKhoaHoc.ReadOnly = false;
            txtMSLop.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            txtKhoaHoc.Clear();
            txtMSLop.Clear();
            txtTenLop.Clear();
            txtMSLop.Focus();
        }
        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhsua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongluu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtKhoaHoc.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            txtTenLop.Focus();
        }
        void NhanDuLieu()
        {
            dsLop.Clear();
            string strSelect = "Select * From Lop";
            Mypublic.OpenData(strSelect, dsLop, "Lop");
            dgvLop.DataSource = dsLop;
            dgvLop.DataMember = "Lop";
        }
        void GanDuLieu()
        {
            if (dsLop.Tables["Lop"].Rows.Count > 0) 
            {
                txtMSLop.Text = dgvLop[0, dgvLop.CurrentRow.Index].Value.ToString();
                txtTenLop.Text = dgvLop[1, dgvLop.CurrentRow.Index].Value.ToString();
                txtKhoaHoc.Text = dgvLop[2, dgvLop.CurrentRow.Index].Value.ToString();

            }
            else
            {
                txtKhoaHoc.Clear();
                txtMSLop.Clear();
                txtTenLop.Clear();
            }
        }
        public frmLop_03()
        {
            InitializeComponent();
        }

        private void frmLop_03_Load(object sender, EventArgs e)
        {
            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            NhanDuLieu();
            GanDuLieu();
            dgvLop.Width = 440;
            dgvLop.Columns[0].Width = 95;
            dgvLop.Columns[0].HeaderText = "Mã số";
            dgvLop.Columns[1].Width = 190;
            dgvLop.Columns[1].HeaderText = "Tên lớp";
            dgvLop.Columns[2].Width = 95;
            dgvLop.Columns[2].HeaderText = "Khóa học";
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.EditMode = DataGridViewEditMode.EditProgrammatically;
            DieuKhienKhiBinhThuong();
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            DieuKhienKhiThem();
        }

        private void btnChinhsua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }
        void LuuLopMoi()
        {
            string strSql = "Insert Into Lop Values(@MSLop,@TenLop,@KhoaHoc)";
            if (Mypublic.conMyConnection.State==ConnectionState.Closed)
            {
                Mypublic.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSql, Mypublic.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MSLop", txtMSLop.Text);
            cmdCommand.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
            cmdCommand.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);
            cmdCommand.ExecuteNonQuery();
            Mypublic.conMyConnection.Close();
            dsLop.Clear();
            NhanDuLieu();
            GanDuLieu();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }
        void CapNhapLop()
        {
            string strSql = "Update Lop Set TenLop = @TenLop, KhoaHoc = @KhoaHoc Where MSLop = @MSLop";
            if (Mypublic.conMyConnection.State == ConnectionState.Closed)
            {
                Mypublic.conMyConnection.Open();
            }
            SqlCommand cmdCommand = new SqlCommand(strSql, Mypublic.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MSLop", txtMSLop.Text);
            cmdCommand.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
            cmdCommand.Parameters.AddWithValue("@KhoaHoc", txtKhoaHoc.Text);
            cmdCommand.ExecuteNonQuery();
            Mypublic.conMyConnection.Close();
            dgvLop[1, dgvLop.CurrentRow.Index].Value = txtTenLop.Text;
            dgvLop[2, dgvLop.CurrentRow.Index].Value = txtKhoaHoc.Text;
            DieuKhienKhiBinhThuong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int khoa;
            if ((txtMSLop.Text == "") || (txtTenLop.Text == "") || (txtKhoaHoc.Text == "") || (!int.TryParse(txtKhoaHoc.Text, out khoa)) || (khoa <= 0)) 
            {
                MessageBox.Show("Lỗi nhập dữ liệu!");
            }
            else
            {
                if (blnThem)
                {
                    if (Mypublic.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "Lop")) 
                    {
                        MessageBox.Show("Mã số lớp này đã có rồi!");
                        txtMSLop.Focus();
                    }
                    else
                    {
                        LuuLopMoi();
                    }
                }
                else
                {
                    CapNhapLop();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Mypublic.TonTaiKhoaChinh(txtMSLop.Text,"MSLop","SinhVien"))
            {
                MessageBox.Show("Phải xóa sinh viên thuộc lớp trước!");
            }
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY==DialogResult.Yes)
                {
                    string strDelete = "Delete Lop Where MSLop = @MSLop";
                    if (Mypublic.conMyConnection.State==ConnectionState.Closed)
                    {
                        Mypublic.conMyConnection.Open();
                    }
                    SqlCommand cmdConmand = new SqlCommand(strDelete, Mypublic.conMyConnection);
                    cmdConmand.Parameters.AddWithValue("@MSLop", txtMSLop.Text);
                    cmdConmand.ExecuteNonQuery();
                    Mypublic.conMyConnection.Close();
                    dgvLop.Rows.RemoveAt(dgvLop.CurrentRow.Index);
                    GanDuLieu();
                }
            }
        }

        private void btnKhongluu_Click(object sender, EventArgs e)
        {
            blnThem = false;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
