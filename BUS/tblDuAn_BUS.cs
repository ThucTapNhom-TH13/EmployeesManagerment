using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using System.Data;
namespace BUS
{
    public class tblDuAn_BUS
    {
        public static DataTable loadDu_An()
        {
            return tblDuAn_DAL.getDuAn();
        }
        public static DataSet getDA()
        {
            return tblDuAn_DAL.getDA();
        }
        public static void addDu_An(tblDu_An Duan)
        {
            tblDuAn_DAL.ThemDuAn(Duan);
        }
        public static void suaDu_An(tblDu_An Duan)
        {
            tblDuAn_DAL.SuaDuAn(Duan);
        }
        public static void xoaDu_An(int Duan)
        {
            tblDuAn_DAL.XoaDuan(Duan);
        }
    }
}
