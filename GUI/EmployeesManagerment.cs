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
            txtMaDuAn.DataBindings.Add("Text", dgvDuAn.DataSource, "MaDA");
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
            else if (btnThem_Duan.Text == "Lưu Thêm")
            {
                btnThem_Duan.Text = "Thêm";
                btnSua_Duan.Text = "Sửa";
                btnXoa_Duan.Enabled = true;
                if (!Catch.cNullTB(txtTenDuAn.Text) & !Catch.cNullTB(txtDiaDiem.Text) & !Catch.cNullTB(txtMaPB_DA.Text))
                {
                    try
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
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
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
                    try
                    {
                        int mada = Convert.ToInt32(txtMaDuAn.Text.Trim());
                        string tenda = txtTenDuAn.Text.Trim();
                        string diadiem = txtDiaDiem.Text.Trim();
                        DateTime ngaybd = Convert.ToDateTime(dtpNgayBD.Text.Trim());
                        DateTime ngaykt = Convert.ToDateTime(dtpNgayKT.Text.Trim());
                        int mapb = Convert.ToInt32(txtMaPB_DA.Text.Trim());

                        tblDu_An duan = new tblDu_An(mada, tenda, diadiem, ngaybd, ngaykt, mapb);
                        tblDuAn_BUS.suaDu_An(duan);
                        showDu_An();
                        buidingDu_An();
                        Enebal();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
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
        private void dgvDuAn_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int maduan = Convert.ToInt32(dgvDuAn.Rows[e.RowIndex].Cells[0].Value.ToString());
            showThamgia(maduan);
            buidingTham_gia();
        }
        public void clearDtaThamgia()
        {
            txtMANV_TGIA.Text = "";
            txtMaDA_TGIA.Text = "";
            txtSogio_TGIA.Text = "";
            txtNV_TGIA.Text = "";
        }
        public void enebalTHAM_GIA()
        {
            txtMaDA_TGIA.Enabled = false;
            txtMANV_TGIA.Enabled = false;
            txtSogio_TGIA.Enabled = false;
            txtNV_TGIA.Enabled = false;
        }
        public void unenebalTHAM_GIA()
        {
            txtMaDA_TGIA.Enabled = true;
            txtMANV_TGIA.Enabled = true;
            txtSogio_TGIA.Enabled = true;
            txtNV_TGIA.Enabled = true;
        }
        public void buidingTham_gia()
        {
            txtMANV_TGIA.DataBindings.Clear();
            txtMANV_TGIA.DataBindings.Add("Text", dgvNV_DA.DataSource, "maNV");
            txtMaDA_TGIA.DataBindings.Clear();
            txtMaDA_TGIA.DataBindings.Add("Text", dgvNV_DA.DataSource, "maDA");
            txtNV_TGIA.DataBindings.Clear();
            txtNV_TGIA.DataBindings.Add("Text", dgvNV_DA.DataSource, "nhiemVu");
            txtMaDA_TGIA.DataBindings.Clear();
            txtSogio_TGIA.DataBindings.Clear();
            txtSogio_TGIA.DataBindings.Add("Text", dgvNV_DA.DataSource, "soGioLam");
        }
        private void btnThem_NVDA_Click(object sender, EventArgs e)
        {
            if (btnThem_NVDA.Text == "Thêm")
            {
                clearDtaThamgia();
                btnThem_NVDA.Text = "Lưu Thêm";
                btnSua_NVDA.Text = "Cannel";
                btnXoa_NVDA.Enabled = false;
                unenebalTHAM_GIA();
            }
            else if (btnThem_NVDA.Text == "Lưu Thêm")
            {
                btnThem_NVDA.Text = "Thêm";
                btnSua_NVDA.Text = "Sửa";
                btnXoa_NVDA.Enabled = true;
                if (!Catch.cNullTB(txtMANV_TGIA.Text) & !Catch.cNullTB(txtMaDA_TGIA.Text) & !Catch.cNullTB(txtNV_TGIA.Text) & !Catch.cNullTB(txtSogio_TGIA.Text))
                {
                    try
                    {
                        int mada = Convert.ToInt32(txtMaDA_TGIA.Text.Trim());
                        int manv = Convert.ToInt32(txtMANV_TGIA.Text.Trim());
                        string nhiemvu = txtTenDuAn.Text.Trim();
                        float sogiolam = (float)Convert.ToDouble(txtSogio_TGIA.Text.Trim());

                        tblThamgia tgia = new tblThamgia(manv, mada, sogiolam, nhiemvu);
                        tblThamgia_BUS.addThamGia(tgia);
                        showThamgia(mada);
                        buidingTham_gia();
                        enebalTHAM_GIA();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
            else if (btnThem_NVDA.Text == "Lưu Sửa")
            {
                btnThem_NVDA.Text = "Thêm";
                btnSua_NVDA.Text = "Sửa";
                btnXoa_NVDA.Enabled = true;
                if (!Catch.cNullTB(txtMANV_TGIA.Text) & !Catch.cNullTB(txtMaDA_TGIA.Text) & !Catch.cNullTB(txtNV_TGIA.Text) & !Catch.cNullTB(txtSogio_TGIA.Text))
                {
                    try
                    {
                        int mada = Convert.ToInt32(txtMaDA_TGIA.Text);
                        int manv = Convert.ToInt32(txtMANV_TGIA.Text);
                        string nhiemvu = txtNV_TGIA.Text.Trim();
                        float sogiolam = (float)Convert.ToDouble(txtSogio_TGIA.Text.Trim());

                        tblThamgia tgia = new tblThamgia(manv, mada, sogiolam, nhiemvu);
                        tblThamgia_BUS.updateThamGia(tgia);
                        showThamgia(mada);
                        buidingTham_gia();
                        enebalTHAM_GIA();
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
        }

        private void btnSua_NVDA_Click(object sender, EventArgs e)
        {
            if (btnSua_NVDA.Text == "Sửa")
            {
                unenebalTHAM_GIA();
                txtMaDA_TGIA.Enabled = false;
                txtMANV_TGIA.Enabled = false;
                btnThem_NVDA.Text = "Lưu Sửa";
                btnSua_NVDA.Text = "Cannel";
                btnXoa_NVDA.Enabled = false;

            }
            else
            {
                btnThem_NVDA.Text = "Thêm";
                btnSua_NVDA.Text = "Sửa";
                btnXoa_NVDA.Enabled = true;
                enebalTHAM_GIA();
            }
        }

        private void btnXoa_NVDA_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaDA_TGIA.Text) & !Catch.cNullTB(txtMANV_TGIA.Text))
            {
                int maduan = Convert.ToInt32(txtMaDA_TGIA.Text);
                int manv = Convert.ToInt32(txtMANV_TGIA.Text);
                tblThamgia_BUS.deleteThamGia(maduan, manv);
                showThamgia(maduan);
                buidingDu_An();
                Enebal();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }
        private void EmployeesManagerment_Load(object sender, EventArgs e)
        {
            Enebal();
            showDu_An();
            buidingDu_An();
            enebalTHAM_GIA();

        }

        private void dayOffTab_Click(object sender, EventArgs e)
        {

        }
    }
}
