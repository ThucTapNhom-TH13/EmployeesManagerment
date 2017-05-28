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
    public class ViPham_DAL
    {
        public static DataTable getViPham()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("XEM_VP", conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataTable thongke()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("SELECT Vipham.maNV, count(maViPham) as Solanvipham FROM ViPham group by maNV", conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static void ThemViPham(ViPham vp)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("THEM_VP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LY_DO", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@KY_LUAT", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NGAY_VP", SqlDbType.DateTime);
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters["@LY_DO"].Value = vp.Lydo;
            cmd.Parameters["@KY_LUAT"].Value = vp.HinhthucKL;
            cmd.Parameters["@NGAY_VP"].Value = vp.NgayVP;
            cmd.Parameters["@MA_NV"].Value = vp.MaNV;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void SuaViPham(ViPham vp)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("SUA_VP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_VP", SqlDbType.Int);
            cmd.Parameters.Add("@LY_DO", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@KY_LUAT", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@NGAY_VP", SqlDbType.DateTime);
            cmd.Parameters.Add("@MA_NV", SqlDbType.Int);
            cmd.Parameters["@MA_VP"].Value = vp.MaVP;
            cmd.Parameters["@LY_DO"].Value = vp.Lydo;
            cmd.Parameters["@KY_LUAT"].Value = vp.HinhthucKL;
            cmd.Parameters["@NGAY_VP"].Value = vp.NgayVP;
            cmd.Parameters["@MA_NV"].Value = vp.MaNV;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void XoaViPham(int maVP)
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand cmd = new SqlCommand("XOA_VP", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MA_VP", SqlDbType.Int);
            cmd.Parameters["@MA_VP"].Value = maVP;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
