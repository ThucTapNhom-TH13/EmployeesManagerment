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
        public DataTable GET()
        {
            try
            {
                string query = @"select *  from NghiLam";

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
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from NghiLam", conn);
                DataRow r = null;
                r["maNghi"] = nlam.Manghi;
                r["ngayNghi"] = nlam.NgayNghi;
                r["lyDo"] = nlam.LyDo;
                r["coPhep"] = nlam.CoPhep;
                r["nghiKhongLuong"] = nlam.NghiKhongLuong;
                r["maNV"] = nlam.ManNV;
                dt.Rows.Add(r);
                SqlCommandBuilder cn = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }

            catch
            {
                return false;
            }
        }
        public bool Delete(string maN)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from NghiLam", conn);
                DataRow r = dt.Rows.Find(maN);
                if (r != null)
                {
                    r.Delete();
                }
                SqlCommandBuilder cn = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(NghiLam nlam)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select* from NghiLam", conn);
                DataRow r = dt.Rows.Find(nlam.Manghi);
                if (r != null)
                {
                    r["ngayNghi"] = nlam.NgayNghi;
                    r["lyDo"] = nlam.LyDo;
                    r["coPhep"] = nlam.CoPhep;
                    r["nghiKhongLuong"] = nlam.NghiKhongLuong;
                    r["maNV"] = nlam.ManNV;
                }
                SqlCommandBuilder cn = new SqlCommandBuilder(da);
                da.Update(dt);
                return true;
            }
            catch
            {
                return false;
            }

        }
        //public bool tatcasolannghi(nghilam nlam)
        //{
        //    try
        //    {
        //        DBconnect conn = new DBconnect();
        //        con = conn.con;
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("sp_tennv", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter p = new SqlParameter("@Ma", nlam.ManNV);
        //        cmd.Parameters.Add(p);
        //        SqlDataAdapter dg = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        dg.Fill(dt);
        //        if (nlam.ManNV != null)
        //        {
        //            textBox2.Text = Convert.ToString(dt.Rows[0]["HOTEN"]);
        //        }
        //        SqlCommandBuilder cn = new SqlCommandBuilder(da);
        //        da.Update(dt);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
    }
}
