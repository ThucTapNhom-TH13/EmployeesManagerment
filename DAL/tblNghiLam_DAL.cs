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
    public class tblNghiLam_DAL:SqlConnect
    {
        DataTable dt = new DataTable();
        SqlConnection conn = SqlConnect.Connect();
        public DataTable Get(string manhanvien)
        {
            try
            {
                string query = @"select count* as songaynghi from NghiLam where maNV=@ma";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter p = new SqlParameter("@ma", manhanvien);
                cmd.Parameters.Add(p);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch
            {
                return null;
            }
        }

        public DataTable statistic()
        {
            SqlConnection conn = SqlConnect.Connect();
            SqlCommand command = new SqlCommand("select NghiLam.maNV, tenNV, count(maNghi) as soLanNghi from NghiLam, NhanVien where NghiLam.maNV = NhanVien.maNV group by NghiLam.maNV, tenNV", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.SelectCommand = command;
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable GET()
        {
            try
            {
                string query = @"select maNghi, NghiLam.maNV, tenNV, ngayNghi, lyDo, coPhep, nghiKhongLuong from NghiLam, NhanVien where NghiLam.maNV = NhanVien.maNV";

                SqlCommand cmd = new SqlCommand(query, conn);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }

            catch
            {
                return null;
            }
        }
        //public DAL_nghilam()
        //{
        //    dt = Get();
        //    dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
        //}
  

        public bool Insert(NghiLam nlam)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("nghiLam_insert", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@manv", nlam.maNV));
            cmd.Parameters.Add(new SqlParameter("@lydo", nlam.lyDo));
            cmd.Parameters.Add(new SqlParameter("@ngaynghi", nlam.ngayNghi));
            cmd.Parameters.Add(new SqlParameter("@cophep", nlam.coPhep));
            cmd.Parameters.Add(new SqlParameter("@khongluong", nlam.nghiKhongLuong));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int maN)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("nghiLam_delete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ma", maN));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Update(NghiLam nlam)
        {
            SqlConnection connection = SqlConnect.Connect();
            connection.Open();
            SqlCommand cmd = new SqlCommand("nghiLam_update", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@manv", nlam.maNV));
            cmd.Parameters.Add(new SqlParameter("@lydo", nlam.lyDo));
            cmd.Parameters.Add(new SqlParameter("@ngaynghi", nlam.ngayNghi));
            cmd.Parameters.Add(new SqlParameter("@cophep", nlam.coPhep));
            cmd.Parameters.Add(new SqlParameter("@khongluong", nlam.nghiKhongLuong));
            cmd.Parameters.Add(new SqlParameter("@ma", nlam.ma));
            int msg = cmd.ExecuteNonQuery();
            if (msg > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
