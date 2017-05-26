using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhongBan_BUS
    {
        public static DataTable loadPhongBan()
        {
            return PhongBan_DAL.getPhongBan();
        }
        public static DataSet getPB()
        {
            return PhongBan_DAL.getPB();
        }
        public static void addPhongBan(PhongBan pb)
        {
            PhongBan_DAL.ThemPhongBan(pb);
        }
        public static void suaPhongBan(PhongBan pb)
        {
            PhongBan_DAL.SuaPhongBan(pb);
        }
        public static void xoaPhongBan(int mapb)
        {
            PhongBan_DAL.XoaPhongBan(mapb);
        }
    }
}
