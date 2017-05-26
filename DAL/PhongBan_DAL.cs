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
    public class PhongBan_DAL
    {
        public static DataTable getPhongBan()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_PHONG_BAN", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataSet getPB()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT maPB,tenPB FROM PhongBan", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataSet dt = new DataSet();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemPhongBan(PhongBan pb)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_PHONG_BAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TEN_PB", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@DIA_DIEM", SqlDbType.NVarChar,100);
            cmd.Parameters.Add("@MA_TP", SqlDbType.Int);
            cmd.Parameters["@TEN_PB"].Value = pb.Tenpb;
            cmd.Parameters["@DIA_DIEM"].Value = pb.Diadiem;
            cmd.Parameters["@MA_TP"].Value = pb.Matp;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaPhongBan(PhongBan pb)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_PHONG_BAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_PB", SqlDbType.Int);
            cmd.Parameters.Add("@TEN_PB", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@DIA_DIEM", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@MA_TP", SqlDbType.Int);
            cmd.Parameters["@MA_PB"].Value = pb.Mapb;
            cmd.Parameters["@TEN_PB"].Value = pb.Tenpb;
            cmd.Parameters["@DIA_DIEM"].Value = pb.Diadiem;
            cmd.Parameters["@MA_TP"].Value = pb.Matp;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void XoaPhongBan(int mapb)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_PHONG_BAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_PB", SqlDbType.Int);
            cmd.Parameters["@MA_PB"].Value = mapb;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
