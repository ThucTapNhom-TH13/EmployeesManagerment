using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{


    /// <summary>
    /// BANG DU AN
    /// </summary>
    public class tblDuAn_DAL
    {
        /// <summary>
        /// LAY TAT CA DU LIEU TU BANG DU AN CUA DATABASE
        /// </summary>
        /// <returns></returns>
        public static DataTable getDuAn()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_DU_AN", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataSet getDA()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT maDA,tenDA FROM DuAn", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// THEM DU AN
        /// </summary>
        /// <param name="Duan"></param>
        public static void ThemDuAn(tblDu_An Duan)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_DU_AN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TEN_DA", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@DIA_DIEM", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NGAY_BD", SqlDbType.DateTime);
            cmd.Parameters.Add("@NGAY_KT", SqlDbType.DateTime);
            cmd.Parameters.Add("@MA_PB", SqlDbType.Int);
            cmd.Parameters["@TEN_DA"].Value = Duan.TenDuan;
            cmd.Parameters["@DIA_DIEM"].Value = Duan.DiaDiem;
            cmd.Parameters["@NGAY_BD"].Value = Duan.NgayBd;
            cmd.Parameters["@NGAY_KT"].Value = Duan.NgayKt;
            cmd.Parameters["@MA_PB"].Value = Duan.MaPb;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// SUA DU AN
        /// </summary>
        /// <param name="Duan"></param>

        public static void SuaDuAn(tblDu_An Duan)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_DU_AN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_DA", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_DA", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@DIA_DIEM", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NGAY_BD", SqlDbType.DateTime);
            cmd.Parameters.Add("@NGAY_KT", SqlDbType.DateTime);
            cmd.Parameters.Add("@MA_PB", SqlDbType.Int);
            cmd.Parameters["@MA_DA"].Value = Duan.MaDuan;
            cmd.Parameters["@TEN_DA"].Value = Duan.TenDuan;
            cmd.Parameters["@DIA_DIEM"].Value = Duan.DiaDiem;
            cmd.Parameters["@NGAY_BD"].Value = Duan.NgayBd;
            cmd.Parameters["@NGAY_KT"].Value = Duan.NgayKt;
            cmd.Parameters["@MA_PB"].Value = Duan.MaPb;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// XOA DU AN
        /// </summary>
        /// <param name="maduan"></param>
        public static void XoaDuan(int maduan)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_DU_AN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_DA", SqlDbType.Int);
            cmd.Parameters["@MA_DA"].Value = maduan;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }



    }
}
