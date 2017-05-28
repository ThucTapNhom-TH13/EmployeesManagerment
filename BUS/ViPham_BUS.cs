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
    public class ViPham_BUS
    {
        public static DataTable loadViPham()
        {
            return ViPham_DAL.getViPham();
        }
        public static DataTable Thongke()
        {
            return ViPham_DAL.thongke();
        }
        public static void addViPham(ViPham vp)
        {
            ViPham_DAL.ThemViPham(vp);
        }
        public static void suaViPham(ViPham vp)
        {
            ViPham_DAL.SuaViPham(vp);
        }
        public static void xoaViPham(int maVP)
        {
            ViPham_DAL.XoaViPham(maVP);
        }
    }
}
