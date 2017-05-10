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
using System.Data.SqlClient;

namespace GUI
{
    public partial class EmployeesManagerment : Form
    {
        public EmployeesManagerment()
        {
            InitializeComponent();
        }
        private void EmployeesManagerment_Load(object sender, EventArgs e)
        {

            Enebal();
            showDu_An();
            buidingDu_An();
            enebalTHAM_GIA();
            loadNhanVien();
            EnebalPB();
            showPhongBan();
            buidingPhongBan();
            enebalVP();
            showVP();
            buidingVP();
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dayOffTab_Click(object sender, EventArgs e)
        {

        }

        private void loadNhanVien()
        {
            DataView table = tblNhanVien_BUS.getAll();
            employeesTable.DataSource = table;
            readOnlyEmployeesViews(MODE_VIEW, true);

            initEmployeesViews();

            loadDepartments();
        }

        private void loadEmployeesProjects(int id)
        {
            DataView table = tblNhanVien_BUS.getProjects(id);
            projectJoinedTable.DataSource = table;
        }

        private void employeesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            initEmployeesViews();

            int CurrentIndex = employeesTable.CurrentCell.RowIndex;
            if (employeesTable.Rows[CurrentIndex].Cells[0].Value != null)
            {
                loadSupervisors(Int32.Parse(employeesTable.Rows[CurrentIndex].Cells[0].Value.ToString()));
            }else
            {
                loadSupervisors(0);
            }
        }

        private void emplButton2_Click(object sender, EventArgs e)
        {
            if ("Sửa".Equals(emplButton2.Text))
            {
                emplButton2.Text = "Lưu";
                readOnlyEmployeesViews(MODE_EDIT, false);
            }
            else
            {
                emplButton2.Text = "Sửa";
                if (!Catch.cNullTB(emplNameTxt.Text) & !Catch.cNullTB(emplIDTxt.Text))
                {
                    try
                    {
                        int id = Int32.Parse(emplIDTxt.Text.Trim());
                        string name = emplNameTxt.Text.Trim();
                        DateTime dob = emplDobTimepicker.Value;
                        bool isMale = "nam".Equals(emplGenderCombobox.Text.Trim().ToLower()) ? true : false;
                        String phone = emplPhoneNumTxt.Text.Trim();
                        String address = emplAddressTxt.Text.Trim();
                        decimal salary = Decimal.Parse(emplSalaryTxt.Text.Trim());
                        int supervisorId = -1;
                        if (!(emplSuperVisorCombobox.Text.Trim() == ""))
                        {
                            supervisorId = Int32.Parse(emplSuperVisorCombobox.Text.Trim());
                        }
                        int departmentId = -1;
                        if (!(emplDepartmentCombobox.Text.Trim() == ""))
                        {
                            departmentId = Int32.Parse(emplDepartmentCombobox.Text.Trim());
                        }

                        NhanVien employee = new NhanVien(id, name, dob, isMale, phone, address, salary, supervisorId, departmentId);
                        tblNhanVien_BUS.editEmployee(employee);
                        loadNhanVien();
                        readOnlyEmployeesViews(MODE_EDIT, true);
                    }
                    catch(Exception excep)
                    {
                        MessageBox.Show("Loi: " + excep.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                }
            }
        }

        private void employeesTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void readOnlyEmployeesViews(int mode, bool isReadOnly)
        {
            emplNameTxt.ReadOnly = isReadOnly;
            emplDobTimepicker.Enabled = !isReadOnly;
            emplGenderCombobox.Enabled = !isReadOnly;
            emplPhoneNumTxt.ReadOnly = isReadOnly;
            emplAddressTxt.ReadOnly = isReadOnly;
            emplSalaryTxt.ReadOnly = isReadOnly;
            emplSuperVisorCombobox.Enabled = !isReadOnly;
            emplDepartmentCombobox.Enabled = !isReadOnly;
        }

        private void loadDepartments()
        {
            tblNhanVien_BUS.loadDepartmentCombobox(emplDepartmentCombobox);
        }

        private void loadSupervisors(int id)
        {
            tblNhanVien_BUS.loadSupervisorComboBox(emplSuperVisorCombobox, id);
        }

        private void clearAllEmployeesViews()
        {
            emplIDTxt.Text = "";
            emplAddressTxt.Text = "";
            emplNameTxt.Text = "";
            emplGenderCombobox.Text = "";
            emplDepartmentCombobox.Text = "";
            emplDobTimepicker.Text = "";
            emplPhoneNumTxt.Text = "";
            emplSalaryTxt.Text = "";
            emplSuperVisorCombobox.Text = "";
        }

        private void initEmployeesViews()
        {
            int CurrentIndex = employeesTable.CurrentCell.RowIndex;

            int id = 0;
            if (employeesTable.Rows[CurrentIndex].Cells[0].Value != null)
            {
                emplIDTxt.Text = employeesTable.Rows[CurrentIndex].Cells[0].Value.ToString();
                id = Int32.Parse(employeesTable.Rows[CurrentIndex].Cells[0].Value.ToString());
            }
            loadEmployeesProjects(id);
            if (employeesTable.Rows[CurrentIndex].Cells[1].Value != null)
            {
                emplNameTxt.Text = employeesTable.Rows[CurrentIndex].Cells[1].Value.ToString();
            }
            if (employeesTable.Rows[CurrentIndex].Cells[2].Value != null)
            {
                String[] dateTime = employeesTable.Rows[CurrentIndex].Cells[2].Value.ToString().Split('/', ' ');
                if(dateTime.Length > 2)
                {
                    DateTime date = new DateTime(Int32.Parse(dateTime[2]), Int32.Parse(dateTime[0]), Int32.Parse(dateTime[1]));
                    emplDobTimepicker.Value = date;
                }
            }
            if (employeesTable.Rows[CurrentIndex].Cells[3].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[3].Value.ToString();
                String genderString = value.Equals("True") ? "Nam" : "Nữ";
                emplGenderCombobox.Text = genderString;
            }
            if (employeesTable.Rows[CurrentIndex].Cells[4].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[4].Value.ToString();
                emplPhoneNumTxt.Text = value;
            }
            if (employeesTable.Rows[CurrentIndex].Cells[5].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[5].Value.ToString();
                emplAddressTxt.Text = value;
            }
            if (employeesTable.Rows[CurrentIndex].Cells[6].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[6].Value.ToString();
                emplSalaryTxt.Text = value;
            }
            if (employeesTable.Rows[CurrentIndex].Cells[7].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[7].Value.ToString();
                emplSuperVisorCombobox.Text = value;
            }
            if (employeesTable.Rows[CurrentIndex].Cells[8].Value != null)
            {
                String value = employeesTable.Rows[CurrentIndex].Cells[8].Value.ToString();
                emplDepartmentCombobox.Text = value;
            }
        }

        private void changeButtonsStatus(int mode)
        {
            switch (mode)
            {
                case MODE_ADD:
                    emplButton1.Text = "Lưu";
                    enableButtons(true, false, false);
                    break;
                case MODE_EDIT:
                    emplButton2.Text = "Lưu";
                    enableButtons(false, true, false);
                    break;
                default:
                    emplButton1.Text = "Thêm";
                    emplButton1.Text = "Sửa";
                    emplButton1.Text = "Xóa";
                    enableButtons(true, true, true);
                    break;
            }
        }

        private void enableButtons(bool isEnableAddButton, bool isEnableEditButton, bool isEnableDeleteButton)
        {
            emplButton1.Enabled = isEnableAddButton;
            emplButton2.Enabled = isEnableEditButton;
            emplButton3.Enabled = isEnableDeleteButton;
        }

        /************************** CuongCV *******************************/
        private const int MODE_VIEW = 0;
        private const int MODE_ADD = 1;
        private const int MODE_EDIT = 2;
        private const int MODE_DELETE = 3;

        private void emplButton1_Click(object sender, EventArgs e)
        {
            if (emplButton1.Text.Equals("Thêm"))
            {
                clearAllEmployeesViews();
                readOnlyEmployeesViews(MODE_ADD, false);
                changeButtonsStatus(MODE_ADD);
                loadSupervisors(0);
            }else
            {
                if (!Catch.cNullTB(emplNameTxt.Text))
                {
                    try
                    {
                        string name = emplNameTxt.Text.Trim();
                        DateTime dob = emplDobTimepicker.Value;
                        bool isMale = "nam".Equals(emplGenderCombobox.Text.Trim().ToLower()) ? true : false;
                        String phone = emplPhoneNumTxt.Text.Trim();
                        String address = emplAddressTxt.Text.Trim();
                        decimal salary = Decimal.Parse(emplSalaryTxt.Text.Trim());
                        int supervisorId = -1;
                        if (!(emplSuperVisorCombobox.Text.Trim() == ""))
                        {
                            supervisorId = Int32.Parse(emplSuperVisorCombobox.Text.Trim());
                        }
                        int departmentId = -1;
                        if (!(emplDepartmentCombobox.Text.Trim() == ""))
                        {
                            departmentId = Int32.Parse(emplDepartmentCombobox.Text.Trim());
                        }

                        NhanVien employee = new NhanVien(0, name, dob, isMale, phone, address, salary, supervisorId, departmentId);
                        tblNhanVien_BUS.addEmployee(employee);
                        loadNhanVien();
                        readOnlyEmployeesViews(MODE_VIEW, true);
                        changeButtonsStatus(MODE_VIEW);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Error: \n " + excep.ToString());
                        readOnlyEmployeesViews(MODE_VIEW, true);
                        changeButtonsStatus(MODE_VIEW);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập tên nhân viên");
                }
            }
        }

        private void emplButton3_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(emplIDTxt.Text))
            {
                try
                {
                    int id = Int32.Parse(emplIDTxt.Text.Trim());
                    deleteEmployee(id);
                    loadNhanVien();

                }
                catch (Exception excep)
                {
                    MessageBox.Show("Error: \n " + excep.ToString());
                    readOnlyEmployeesViews(MODE_VIEW, true);
                    changeButtonsStatus(MODE_VIEW);
                }
            }
            else
            {
                MessageBox.Show("Chọn nhân viên cần xóa");
            }
        }

        private void deleteEmployee(int id)
        {
            tblNhanVien_BUS.deleteEmployee(id);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Phong Ban
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void showPhongBan()
        {
            dgvPB.DataSource = PhongBan_BUS.loadPhongBan();
        }
        public void buidingPhongBan()
        {
            txtMaPB.DataBindings.Clear();
            txtMaPB.DataBindings.Add("Text", dgvPB.DataSource, "maPB");
            txtTenPB.DataBindings.Clear();
            txtTenPB.DataBindings.Add("Text", dgvPB.DataSource, "tenPB");
            txtDD_PB.DataBindings.Clear();
            txtDD_PB.DataBindings.Add("Text", dgvPB.DataSource, "diaDiem");
            txtTP_PB.DataBindings.Clear();
            txtTP_PB.DataBindings.Add("Text", dgvPB.DataSource, "maTruongPhong");
        }
        public void clearDataPB()
        {
            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtDD_PB.Text = "";
            txtTP_PB.Text = "";
        }

        public void EnebalPB()
        {
            txtMaPB.Enabled = false;
            txtTenPB.Enabled = false;
            txtDD_PB.Enabled = false;
            txtTP_PB.Enabled = false;
        }

        public void UnEnebalPB()
        {
            txtTenPB.Enabled = true;
            txtDD_PB.Enabled = true;
            txtTP_PB.Enabled = true;
        }
        private void btnThem_PB_Click(object sender, EventArgs e)
        {
            if (btnThem_PB.Text == "Thêm")
            {
                UnEnebalPB();
                clearDataPB();
                btnThem_PB.Text = "Lưu Thêm";
                btnSua_PB.Text = "Cannel";
                btnXoa_PB.Enabled = false;
            }
            else if (btnThem_PB.Text == "Lưu Thêm")
            {
                btnThem_PB.Text = "Thêm";
                btnSua_PB.Text = "Sửa";
                btnXoa_PB.Enabled = true;
                if (!Catch.cNullTB(txtTenPB.Text) & !Catch.cNullTB(txtTP_PB.Text))
                {
                    try
                    {
                        string tenpb = txtTenPB.Text.Trim();
                        string diadiem = txtDD_PB.Text.Trim();
                        int matp = Convert.ToInt32(txtTP_PB.Text.Trim());

                        PhongBan pb = new PhongBan(tenpb, diadiem, matp);
                        PhongBan_BUS.addPhongBan(pb);
                        showPhongBan();
                        buidingPhongBan();
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
            else if (btnThem_PB.Text == "Lưu Sửa")
            {
                btnThem_PB.Text = "Thêm";
                btnSua_PB.Text = "Sửa";
                btnXoa_PB.Enabled = true;
                if (!Catch.cNullTB(txtTenPB.Text) & !Catch.cNullTB(txtTP_PB.Text))
                {
                    try
                    {
                        int mapb = Convert.ToInt32(txtMaPB.Text.Trim());
                        string tenpb = txtTenPB.Text.Trim();
                        string diadiem = txtDD_PB.Text.Trim();
                        int matp = Convert.ToInt32(txtTP_PB.Text.Trim());

                        PhongBan pb = new PhongBan(mapb,tenpb, diadiem, matp);
                        PhongBan_BUS.suaPhongBan(pb);
                        showPhongBan();
                        buidingPhongBan();
                        EnebalPB();
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

        private void btnSua_PB_Click(object sender, EventArgs e)
        {
            if (btnSua_PB.Text == "Sửa")
            {
                UnEnebalPB();
                txtMaPB.Enabled = false;
                btnThem_PB.Text = "Lưu Sửa";
                btnSua_PB.Text = "Cannel";
                btnXoa_PB.Enabled = false;

            }
            else
            {
                btnThem_PB.Text = "Thêm";
                btnSua_PB.Text = "Sửa";
                btnXoa_PB.Enabled = true;
                Enebal();
            }
        }

        private void btnXoa_PB_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaPB.Text))
            {
                int mapb = Convert.ToInt32(txtMaPB.Text);
                PhongBan_BUS.xoaPhongBan(mapb);
                showPhongBan();
                buidingPhongBan();
                Enebal();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }

        public void showNV_PB(int mapb)
        {
            dgvNV_PB.DataSource = tblNhanVien_BUS.loadNVPB(mapb);
        }
        private void dgvPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mapb = Convert.ToInt32(dgvPB.Rows[e.RowIndex].Cells[0].Value.ToString());
            showNV_PB(mapb);
        }
        private void dgvNV_PB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvPB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// 
        /// VI PHAM
        /// /////////////////////////////////////////////////////////////////////////
        /// </summary>
        public void showVP()
        {
            dgvViPham.DataSource = ViPham_BUS.loadViPham();
        }

        public void clearVP()
        {
            txtMaViPham.Text = "";
            txtMaNV.Text = "";
            txtLyDo.Text = "";
            txtKyLuat.Text = "";
           
        }
        public void enebalVP()
        {
            txtMaViPham.Enabled = false;
            txtMaNV.Enabled = false;
            txtLyDo.Enabled = false;
            txtKyLuat.Enabled = false;
            dtpNgayVP.Enabled = false;
        }
        public void unenebalVP()
        {
            dtpNgayVP.Enabled = true;
            txtMaNV.Enabled = true;
            txtLyDo.Enabled = true;
            txtKyLuat.Enabled = true;
           
        }
        public void buidingVP()
        {
            txtMaViPham.DataBindings.Clear();
            txtMaViPham.DataBindings.Add("Text", dgvViPham.DataSource, "maViPham");
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dgvViPham.DataSource, "maNV");
            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", dgvViPham.DataSource, "lyDo");
            txtKyLuat.DataBindings.Clear();
            txtKyLuat.DataBindings.Add("Text", dgvViPham.DataSource, "hinhThucKyLuat");
            dtpNgayVP.DataBindings.Clear();
            dtpNgayVP.DataBindings.Add("Text", dgvViPham.DataSource, "ngayViPham");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                clearVP();
                btnThem.Text = "Lưu Thêm";
                btnSua.Text = "Cannel";
                btnXoa.Enabled = false;
                unenebalVP();
            }
            else if (btnThem.Text == "Lưu Thêm")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                if (!Catch.cNullTB(txtLyDo.Text) & !Catch.cNullTB(txtMaNV.Text) & !Catch.cNullTB(txtKyLuat.Text))
                {
                    try
                    {
                        int manv = Convert.ToInt32(txtMaNV.Text.Trim());
                        string lydo = txtLyDo.Text.Trim();
                        string kyluat = txtKyLuat.Text.Trim();
                        DateTime ngayvp = Convert.ToDateTime(dtpNgayVP.Text.Trim());

                        ViPham vp = new ViPham(lydo, kyluat, ngayvp,manv);
                        ViPham_BUS.addViPham(vp);
                        showVP();
                        buidingVP();
                       
                    }
                    catch
                    {
                        MessageBox.Show("Loi");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập dữ liệu");
                    enebalVP();
                }
            }
            else if (btnThem.Text == "Lưu Sửa")
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                if (!Catch.cNullTB(txtMaViPham.Text) & !Catch.cNullTB(txtLyDo.Text) & !Catch.cNullTB(txtMaNV.Text) & !Catch.cNullTB(txtKyLuat.Text))
                {
                    try
                    {
                        int mavp = Convert.ToInt32(txtMaViPham.Text.Trim());
                        int manv = Convert.ToInt32(txtMaNV.Text.Trim());
                        string lydo = txtLyDo.Text.Trim();
                        string kyluat = txtKyLuat.Text.Trim();
                        DateTime ngayvp = Convert.ToDateTime(dtpNgayVP.Text.Trim());

                        ViPham vp = new ViPham(mavp, lydo, kyluat, ngayvp, manv);
                        ViPham_BUS.suaViPham(vp);
                        showVP();
                        buidingVP();
                        
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
                enebalVP();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                unenebalVP();
                txtMaViPham.Enabled = false;
                btnThem.Text = "Lưu Sửa";
                btnSua.Text = "Cannel";
                btnXoa.Enabled = false;

            }
            else
            {
                btnThem.Text = "Thêm";
                btnSua.Text = "Sửa";
                btnXoa.Enabled = true;
                enebalVP();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Catch.cNullTB(txtMaViPham.Text))
            {
                int mavp = Convert.ToInt32(txtMaViPham.Text);
                ViPham_BUS.xoaViPham(mavp);
                showVP();
                buidingVP();

            }
            else
            {
                MessageBox.Show("Chưa nhập dữ liệu");
            }
        }
    }
}
