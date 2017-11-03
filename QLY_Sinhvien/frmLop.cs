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
    public partial class frmLop : Form
    {
        DataSet dsLop = new DataSet();
        SqlDataAdapter daLop = new SqlDataAdapter();
        BindingSource bsLop = new BindingSource();
        bool blnThem = false;
        void DieuKhienViTri() {
            if (bsLop.Position > 0)
            {
                btnDau.Enabled = true;
                btnTruoc.Enabled = true;
            }
            else {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            if (bsLop.Position < bsLop.Count - 1) 
            {
                btnKe.Enabled = true;
                btnCuoi.Enabled = true;
            }
            else
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtVitri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
        }
        void DieuKhienKhiBinhThuong() {
            if (Mypublic.strQuyenSD=="AdminKhoa")
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
            cboLop.Enabled = true;
            DieuKhienViTri();
        }
        void DieuKhienKhiThem()
        {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
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
            cboLop.Enabled = false;
            cboLop.SelectedIndex = -1;
            txtVitri.Text = bsLop.Count + "/" + bsLop.Count;
            txtMSLop.Focus();
        }
        void DieuKhienKhiChinhSua() {
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            btnThem.Enabled = false;
            btnChinhsua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongluu.Enabled = true;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            txtKhoaHoc.ReadOnly = false;
            txtTenLop.ReadOnly = false;
            cboLop.Enabled = false;
            txtTenLop.Focus();
        }
        void GanDuLieu() {
            txtMSLop.DataBindings.Add(new Binding("Text", bsLop, "MSLop"));
            txtTenLop.DataBindings.Add(new Binding("Text",bsLop,"TenLop"));
            txtKhoaHoc.DataBindings.Add(new Binding("Text", bsLop, "KhoaHoc"));
        }
        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From Lop";
            Mypublic.OpenData(strSelect, dsLop, "Lop", daLop);
            bsLop.DataSource = dsLop;
            bsLop.DataMember = "Lop";
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MSLop";
            txtMSLop.MaxLength = 8;
            txtTenLop.MaxLength = 40;
            txtVitri.ReadOnly = true;
            txtVitri.BackColor = Color.White;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedIndex!=-1)
            {
                bsLop.Position = cboLop.SelectedIndex;
                DieuKhienViTri();
                if (Mypublic.strQuyenSD=="AdminLop")
                {
                    if (cboLop.SelectedValue.ToString()==Mypublic.strLop)
                    {
                        btnChinhsua.Enabled = true;
                    }
                    else
                    {
                        btnChinhsua.Enabled = false;
                    }
                }
            }
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bsLop.MoveFirst();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            txtVitri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bsLop.MovePrevious();
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
            if (bsLop.Position==0)
            {
                btnDau.Enabled = false;
                btnTruoc.Enabled = false;
            }
            txtVitri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            bsLop.MoveNext();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            if (bsLop.Position==bsLop.Count-1)
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            txtVitri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bsLop.MoveLast();
            btnDau.Enabled = true;
            btnTruoc.Enabled = true;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
            txtVitri.Text = (bsLop.Position + 1) + "/" + bsLop.Count;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            blnThem = true;
            bsLop.AddNew();
            DieuKhienKhiThem();
        }

        private void btnChinhsua_Click(object sender, EventArgs e)
        {
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int Khoa;
            if ((txtMSLop.Text=="")||(txtTenLop.Text=="")||(!int.TryParse(txtKhoaHoc.Text,out Khoa))||(Khoa<=0))
            {
                MessageBox.Show("Lỗi nhập dữ liệu !");
            }
            else
            {
                if ((blnThem)&(Mypublic.TonTaiKhoaChinh(txtMSLop.Text,"MSLop","Lop")))
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
    }
}
