using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;
namespace BUS
{
    public class tblThamgia_BUS
    {// hienthi du lieu bang tham gia
        public static DataTable loadThamgia(int maduan)
        {
            return tblThamGia_DAL.getThamGia(maduan);
        }

        public static void addThamGia(tblThamgia tgia)
        {
            tblThamGia_DAL.ThemThamGia(tgia);
        }
        public static void updateThamGia(tblThamgia tgia)
        {
            tblThamGia_DAL.SuaThamGia(tgia);
        }
        public static void deleteThamGia(int mada, int manv)
        {
            tblThamGia_DAL.XoaThamGia(mada, manv);
        }

    }
}
