using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class tblThamGia_DAL
    {

        public static DataTable getThamGia(int maduan)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_THAM_GIA", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@MA_DA", SqlDbType.Int);
            command.Parameters["@MA_DA"].Value = maduan;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemThamGia(tblThamgia tgia)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_THAM_GIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters.Add("@MA_DA", SqlDbType.Int);
            cmd.Parameters.Add("@SO_GIO", SqlDbType.Float);
            cmd.Parameters.Add("@NHIEM_VU", SqlDbType.NVarChar, 50);
            cmd.Parameters["@MA_DA"].Value = tgia.MaDA;
            cmd.Parameters["@MA_NV"].Value = tgia.MaNV;
            cmd.Parameters["@SO_GIO"].Value = tgia.SoGio;
            cmd.Parameters["@NHIEM_VU"].Value = tgia.NhiemVu;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void SuaThamGia(tblThamgia tgia)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_THAM_GIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters.Add("@MA_DA", SqlDbType.Int);
            cmd.Parameters.Add("@SO_GIO", SqlDbType.Float);
            cmd.Parameters.Add("@NHIEM_VU", SqlDbType.NVarChar, 50);
            cmd.Parameters["@MA_DA"].Value = tgia.MaDA;
            cmd.Parameters["@MA_NV"].Value = tgia.MaNV;
            cmd.Parameters["@SO_GIO"].Value = tgia.SoGio;
            cmd.Parameters["@NHIEM_VU"].Value = tgia.NhiemVu;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void XoaThamGia(int maduan, int manv)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_THAM_GIA", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_DA", SqlDbType.Int);
            cmd.Parameters["@MA_DA"].Value = maduan;
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters["@MA_NV"].Value = manv;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
