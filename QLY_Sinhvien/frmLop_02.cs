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
    public partial class frmLop_02 : Form
    {
        DataSet dsLop = new DataSet();
        SqlDataAdapter daLop = new SqlDataAdapter();
        BindingSource bsLop = new BindingSource();
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
        void GanDuLieu()
        {
            txtMSLop.DataBindings.Add(new Binding("Text", bsLop, "MSLop"));
            txtTenLop.DataBindings.Add(new Binding("Text", bsLop, "TenLop"));
            txtKhoaHoc.DataBindings.Add(new Binding("Text", bsLop, "KhoaHoc"));
        }
        public frmLop_02()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsLop.AddNew();
            bsLop.Position = bsLop.Count;
            dgvLop.CurrentCell = dgvLop[0, bsLop.Count - 1];
            DieuKhienKhiThem();
        }

        private void btnChinhsua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int Khoa;
            if ((txtMSLop.Text == "") || (txtTenLop.Text == "") || (!int.TryParse(txtKhoaHoc.Text, out Khoa)) || (Khoa <= 0))
            {
                MessageBox.Show("Lỗi nhập dữ liệu !");
            }
            else
            {
                if ((blnThem) & (Mypublic.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "Lop")))
                {
                    MessageBox.Show("Mã số lớp này đã có rồi!");
                    txtMSLop.Focus();
                }
                else
                {
                    bsLop.EndEdit();
                    daLop.Update(dsLop, "Lop");
                    dsLop.AcceptChanges();
                    blnThem = false;
                    DieuKhienKhiBinhThuong();
                }
            }
        }

        private void btnKhongluu_Click(object sender, EventArgs e)
        {
            bsLop.EndEdit();
            dsLop.RejectChanges();
            blnThem = false;
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Mypublic.TonTaiKhoaChinh(txtMSLop.Text, "MSLop", "SinhVien"))
            {
                MessageBox.Show("Phải xóa sinh viên thuộc lớp trước!");
            }
            else
            {
                DialogResult blnDongY;
                blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (blnDongY == DialogResult.Yes)
                {
                    bsLop.RemoveCurrent();
                    daLop.Update(dsLop, "Lop");
                    dsLop.AcceptChanges();
                }
            }
            DieuKhienKhiBinhThuong();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLop_02_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From Lop";
            Mypublic.OpenData(strSelect, dsLop, "Lop", daLop);
            bsLop.DataSource = dsLop;
            bsLop.DataMember = "Lop";
            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            GanDuLieu();
            dgvLop.DataSource = dsLop;
            dgvLop.DataMember = "Lop";
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
            bsLop.Position = dgvLop.CurrentRow.Index;
        }
    }
}
