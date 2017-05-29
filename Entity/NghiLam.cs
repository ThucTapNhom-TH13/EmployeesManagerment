using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NghiLam
    {
        public int ma;
        public int maNV;
        public string lyDo;
        public DateTime ngayNghi;
        public bool coPhep;
        public bool nghiKhongLuong;

        public NghiLam(int ma, int manv, string lydo, DateTime ngaynghi, bool cophep, bool nghiKhongLuong)
        {
            this.ma = ma;
            this.maNV = manv;
            this.lyDo = lydo;
            this.ngayNghi = ngaynghi;
            this.coPhep = cophep;
            this.nghiKhongLuong = nghiKhongLuong;
        }

        public NghiLam(int manv, string lydo, DateTime ngaynghi, bool cophep, bool nghiKhongLuong)
        {
            this.maNV = manv;
            this.lyDo = lydo;
            this.ngayNghi = ngaynghi;
            this.coPhep = cophep;
            this.nghiKhongLuong = nghiKhongLuong;
        }
    }
}
