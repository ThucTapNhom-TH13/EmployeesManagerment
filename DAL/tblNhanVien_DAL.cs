using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Windows.Forms;

namespace DAL
{
    public class tblNhanVien_DAL
    {
        public static String getEmplNameById(int emplId)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("GET_EMPL_NAME", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MA_NV", SqlDbType.Int);
            command.Parameters["@MA_NV"].Value = emplId;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt.Rows[0].Field<String>("TenNV");
        }

        public static DataView getAll()
        {
            SqlConnection connection = SqlConnect.Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("Xem_nhan_vien", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }

        public static DataView getProjects(int employeeId)
        {
            SqlConnection connection = SqlConnect.Connect();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Xem_du_an_tham_gia", connection);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = employeeId;

            da.SelectCommand = cmd;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataView dv = new DataView(dt);
            return dv;
        }

        public static void editEmployee(NhanVien employee)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("Sua_nhan_vien", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime);
            cmd.Parameters.Add("@gt", SqlDbType.Bit);
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar);
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
            cmd.Parameters.Add("@luong", SqlDbType.Money);
            cmd.Parameters.Add("@nguoiGiamSat", SqlDbType.Int);
            cmd.Parameters.Add("@maPB", SqlDbType.Int);

            cmd.Parameters["@id"].Value = employee.MId;
            cmd.Parameters["@ten"].Value = employee.MName;
            cmd.Parameters["@ngaysinh"].Value = employee.MDob;
            cmd.Parameters["@gt"].Value = employee.MIsMale;
            cmd.Parameters["@sdt"].Value = employee.MPhoneNumber;
            cmd.Parameters["@diachi"].Value = employee.MAddress;
            cmd.Parameters["@luong"].Value = employee.MSalary;
            cmd.Parameters["@nguoiGiamSat"].Value = employee.MSupervisorId == -1 ? Convert.DBNull : employee.MSupervisorId;
            cmd.Parameters["@maPB"].Value = employee.MDepartmentId == -1 ? Convert.DBNull : employee.MDepartmentId;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void addEmployee(NhanVien employee)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("Them_nhan_vien", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime);
            cmd.Parameters.Add("@gt", SqlDbType.Bit);
            cmd.Parameters.Add("@sdt", SqlDbType.NVarChar);
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
            cmd.Parameters.Add("@luong", SqlDbType.Money);
            cmd.Parameters.Add("@nguoiGiamSat", SqlDbType.Int);
            cmd.Parameters.Add("@maPB", SqlDbType.Int);

            cmd.Parameters["@ten"].Value = employee.MName;
            cmd.Parameters["@ngaysinh"].Value = employee.MDob;
            cmd.Parameters["@gt"].Value = employee.MIsMale;
            cmd.Parameters["@sdt"].Value = employee.MPhoneNumber;
            cmd.Parameters["@diachi"].Value = employee.MAddress;
            cmd.Parameters["@luong"].Value = employee.MSalary;
            cmd.Parameters["@nguoiGiamSat"].Value = employee.MSupervisorId == -1 ? Convert.DBNull : employee.MSupervisorId;
            cmd.Parameters["@maPB"].Value = employee.MDepartmentId == -1 ? Convert.DBNull : employee.MDepartmentId;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void loadDepartmentCombobox(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            string Sql = "select maPB from PhongBan";
            SqlConnection conn = SqlConnect.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            comboBox.Items.Clear();
            comboBox.Items.Add("");
            while (DR.Read())
            {
                int name = DR.GetInt32(0);
                comboBox.Items.Add(name);
            }       
            conn.Close(); 
        }

        public static void deleteEmployee(int id)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("Xoa_nhan_vien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void loadSupervisorComboBox(ComboBox comboBox, int employeeId)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            string Sql = "select maNV from NhanVien where maNV <>" + employeeId;
            SqlConnection conn = SqlConnect.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();
            comboBox.Items.Clear();
            comboBox.Items.Add("");
            while (DR.Read())
            {
                int id = DR.GetInt32(0);
                comboBox.Items.Add(id);
            }
            conn.Close();
        }
    }
}
