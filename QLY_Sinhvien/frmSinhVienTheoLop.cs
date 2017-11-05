using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLY_Sinhvien
{
    public partial class frmSinhVienTheoLop : Form
    {
        DataSet dsSinhVien = new DataSet();
        DataSet dsLop = new DataSet();
        DataView dvSinhVien = new DataView();
        DataSet dsQuyenSD = new DataSet();
        int ViTriLop, ThemSua = 0;
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
            txtMSSV.ReadOnly = true;
            txtMSSV.BackColor = Color.White;
            txtTen.ReadOnly = true;
            txtTen.BackColor = Color.White;
            txtHoLot.ReadOnly = true;
            txtHoLot.BackColor = Color.White;
        }
        void DieuKhienKhiThem()
        {
            btnThem.Enabled = false;
            btnChinhsua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongluu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtMSSV.ReadOnly = false;
            txtTen.ReadOnly = false;
            txtHoLot.ReadOnly = false;
            txtMSSV.Clear();
            txtTen.Clear();
            txtHoLot.Focus();
        }
        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnChinhsua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongluu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtTen.ReadOnly = false;
            txtHoLot.Focus();
        }
        void NhanDuLieu()
        {
            string strSelect = "Select * From SinhVien";
            Mypublic.OpenData(strSelect, dsSinhVien, "SinhVien");
        }
        void GanDuLieu()
        {
            if (dvSinhVien.Count > 0) 
            {
                txtMSSV.Text = dgvSinhVien[0, dgvSinhVien.CurrentRow.Index].Value.ToString();
                txtHoLot.Text = dgvSinhVien[1, dgvSinhVien.CurrentRow.Index].Value.ToString();
                txtTen.Text = dgvSinhVien[2, dgvSinhVien.CurrentRow.Index].Value.ToString();
                if (dgvSinhVien[3,dgvSinhVien.CurrentRow.Index].Value.ToString()=="Nam")
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }
                dtpNgaySinh.Value = DateTime.Parse(dgvSinhVien[4, dgvSinhVien.CurrentRow.Index].Value.ToString());
                cboQuyenSD.SelectedIndex = cboQuyenSD.FindString(dgvSinhVien[7, dgvSinhVien.CurrentRow.Index].Value.ToString());
            }
            else
            {
                txtHoLot.Clear();
                txtMSSV.Clear();
                txtTen.Clear();
                rdoNam.Checked = true;
                dtpNgaySinh.Value = DateTime.Today;
                cboQuyenSD.SelectedIndex = -1;
            }
        }
        public frmSinhVienTheoLop()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmSinhVienTheoLop_Load(object sender, EventArgs e)
        {
            string strSelect = "Select MSLop, TenLop From Lop";
            Mypublic.OpenData(strSelect, dsLop, "Lop");
            cboLop.DataSource = dsLop.Tables["Lop"];
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MSLop";
            dsQuyenSD.Tables.Add("DSQuyenSD");
            dsQuyenSD.Tables["DSQuyenSD"].Columns.Add("DSQuyenSD");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("User");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("AdminLop");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("AdminKhoa");
            cboQuyenSD.DataSource = dsQuyenSD;
            cboQuyenSD.DisplayMember = "DSQuyenSD.QuyenSD";
            cboQuyenSD.ValueMember = "DSQuyenSD.QuyenSD";
            txtHoLot.MaxLength = 30;
            txtTen.MaxLength = 30;
            txtMSSV.MaxLength = 8;
            NhanDuLieu();
            dvSinhVien.Table = dsSinhVien.Tables["SinhVien"];
            dvSinhVien.RowFilter = "MSLop like'" + cboLop.SelectedValue + "'";
            dgvSinhVien.DataSource = dvSinhVien;
            dgvSinhVien.Width = 790;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.Columns[0].Width = 85;
            dgvSinhVien.Columns[0].HeaderText = "Mã số";
            dgvSinhVien.Columns[1].Width = 140;
            dgvSinhVien.Columns[1].HeaderText = "Họ lót";
            dgvSinhVien.Columns[2].Width = 60;
            dgvSinhVien.Columns[2].HeaderText = "Tên";
            dgvSinhVien.Columns[3].Width = 50;
            dgvSinhVien.Columns[3].HeaderText = "Phái";
            dgvSinhVien.Columns[4].Width = 100;
            dgvSinhVien.Columns[4].HeaderText = "Ngày sinh";
            dgvSinhVien.Columns[5].Width = 90;
            dgvSinhVien.Columns[5].HeaderText = "MS Lớp";
            dgvSinhVien.Columns[6].Width = 100;
            dgvSinhVien.Columns[6].HeaderText = "Mật khẩu";
            dgvSinhVien.Columns[7].Width = 100;
            dgvSinhVien.Columns[7].HeaderText = "Quyền SD";
            dgvSinhVien.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSinhVien.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvSinhVien_CellFormatting);
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        public DataGridViewCellFormattingEventHandler dgvSinhVien_CellFormatting { get; set; }
    }
}
