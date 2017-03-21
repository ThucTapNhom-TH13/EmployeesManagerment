using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Entity;
namespace GUI
{
    public partial class EmployeesManagerment : Form
    {
        public EmployeesManagerment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BANG DU AN
        /// </summary>
        public void showDu_An()
        {
            dgvDuAn.DataSource = tblDuAn_BUS.loadDu_An();
        }

        public void clearData()
        {
            txtMaDuAn.Text = "";
            txtMaPB_DA.Text = "";
            txtTenDuAn.Text = "";
            txtDiaDiem.Text = "";
        }

        public void Enebal()
        {
            txtMaDuAn.Enabled = false;
            txtTenDuAn.Enabled = false;
            txtMaPB_DA.Enabled = false;
            txtDiaDiem.Enabled = false;
            dtpNgayKT.Enabled = false;
            dtpNgayBD.Enabled = false;
        }

        public void UnEnebal()
        {
            txtTenDuAn.Enabled = true;
            txtMaPB_DA.Enabled = true;
            txtDiaDiem.Enabled = true;
            dtpNgayKT.Enabled = true;
            dtpNgayBD.Enabled = true;
        }


        public void buidingDu_An()
        {
            txtMaDuAn.DataBindings.Clear();
            txtMaDuAn.DataBindings.Add("Text",dgvDuAn.DataSource,"MaDA");
            txtTenDuAn.DataBindings.Clear();
            txtTenDuAn.DataBindings.Add("Text", dgvDuAn.DataSource, "tenDA");
            txtDiaDiem.DataBindings.Clear();
            txtDiaDiem.DataBindings.Add("Text", dgvDuAn.DataSource, "diaDiem");
            dtpNgayBD.DataBindings.Clear();
            dtpNgayBD.DataBindings.Add("Text", dgvDuAn.DataSource, "ngayBatDau");
            dtpNgayKT.DataBindings.Clear();
            dtpNgayKT.DataBindings.Add("Text", dgvDuAn.DataSource, "ngayKetThuc");
            txtMaPB_DA.DataBindings.Clear();
            txtMaPB_DA.DataBindings.Add("Text", dgvDuAn.DataSource, "maPB");
        }

        
        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Them DU AN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Duan_Click(object sender, EventArgs e)
        {
            if (btnThem_Duan.Text == "Thêm")
            {
                UnEnebal();
                clearData();
                btnThem_Duan.Text = "Lưu Thêm";
                btnSua_Duan.Text = "Cannel";
                btnXoa_Duan.Enabled = false;
            }
            else if(btnThem_Duan.Text == "Lưu Thêm")
            {
                btnThem_Duan.Text = "Thêm";
                btnSua_Duan.Text = "Sửa";
                btnXoa_Duan.Enabled = true;
                if( !Catch.cNullTB(txtTenDuAn.Text)& !Catch.cNullTB(txtDiaDiem.Text)& !Catch.cNullTB(txtMaPB_DA.Text))
                {
                    string tenda = txtTenDuAn.Text.Trim();
                    string diadiem = txtDiaDiem.Text.Trim();
                    DateTime ngaybd = Convert.ToDateTime(dtpNgayBD.Text.Trim());
                    DateTime ngaykt = Convert.ToDateTime(dtpNgayKT.Text.Trim());
                    int mapb = Convert.ToInt32(txtMaPB_DA.Text.Trim());

                    tblDu_An duan = new tblDu_An(tenda, diadiem, ngaybd, ngaykt, mapb);
                    tblDuAn_BUS.addDu_An(duan);
                    showDu_An();
                    buidingDu_An();
                    Enebal();
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
            else if (btnThem_Duan.Text == "Lưu Sửa")
            {
                btnThem_Duan.Text = "Thêm";
                btnSua_Duan.Text = "Sửa";
                btnXoa_Duan.Enabled = true;
                if (!Catch.cNullTB(txtTenDuAn.Text) & !Catch.cNullTB(txtDiaDiem.Text) & !Catch.cNullTB(txtMaPB_DA.Text))
                {
                    int mada = Convert.ToInt32(txtMaDuAn.Text.Trim());
                    string tenda = txtTenDuAn.Text.Trim();
                    string diadiem = txtDiaDiem.Text.Trim();
                    DateTime ngaybd = Convert.ToDateTime(dtpNgayBD.Text.Trim());
                    DateTime ngaykt = Convert.ToDateTime(dtpNgayKT.Text.Trim());
                    int mapb = Convert.ToInt32(txtMaPB_DA.Text.Trim());

                    tblDu_An duan = new tblDu_An(mada ,tenda, diadiem, ngaybd, ngaykt, mapb);
                    tblDuAn_BUS.suaDu_An(duan);
                    showDu_An();
                    buidingDu_An();
                    Enebal();
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }

        }

        private void btnSua_Duan_Click(object sender, EventArgs e)
        {
            if (btnSua_Duan.Text == "Sửa")
            {
                UnEnebal();
                txtMaPB_DA.Enabled = false;
                btnThem_Duan.Text = "Lưu Sửa";
                btnSua_Duan.Text = "Cannel";
                btnXoa_Duan.Enabled = false;

            }
            else
            {
                btnThem_Duan.Text = "Thêm";
                btnSua_Duan.Text = "Sửa";
                btnXoa_Duan.Enabled = true;
                Enebal();
            }
        }

        private void btnXoa_Duan_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaDuAn.Text))
            {
                int maduan = Convert.ToInt32(txtMaDuAn.Text);
                tblDuAn_BUS.xoaDu_An(maduan);
                showDu_An();
                buidingDu_An();
                Enebal();
                
            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }
        

        /// <summary>
        /// THAM GIA
        /// </summary>
        /// <param name="maduan"></param>
        public void showThamgia(int maduan)
        {
            dgvNV_DA.DataSource = tblThamgia_BUS.loadThamgia(maduan);
        }

        public void buidingTham_gia()
        {
            txtMANV_DA.DataBindings.Clear();
            txtMANV_DA.DataBindings.Add("Text", dgvNV_DA.DataSource, "maNV");
            txtNV_DA.DataBindings.Clear();
            txtNV_DA.DataBindings.Add("Text", dgvNV_DA.DataSource, "nhiemVu");
            txtTenNV_DA.DataBindings.Clear();
            String TenNV = tblNhanVien_BUS.getEmplName(Int32.Parse(txtMANV_DA.Text));
            txtTenNV_DA.Text = TenNV;
            txtSogio_DA.DataBindings.Clear();
            txtSogio_DA.DataBindings.Add("Text", dgvNV_DA.DataSource, "soGioLam");
        }
        private void btnThem_NVDA_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_NVDA_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_NVDA_Click(object sender, EventArgs e)
        {

        }
        private void EmployeesManagerment_Load(object sender, EventArgs e)
        {
            Enebal();
            showDu_An();
            buidingDu_An();
            
        }
        
        private void dgvDuAn_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int maduan = Convert.ToInt32(dgvDuAn.Rows[e.RowIndex].Cells[0].Value.ToString());
            int maduan1 = Convert.ToInt32(txtMaDuAn.Text);
            showThamgia(maduan);
            buidingTham_gia();
        }

        private void dayOffTab_Click(object sender, EventArgs e)
        {

        }
    }
}
