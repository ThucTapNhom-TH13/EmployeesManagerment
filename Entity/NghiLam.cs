using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class NghiLam
    {
        private int _Manghi;
        public int Manghi
        {
            get { return _Manghi; }
            set { _Manghi = value; }
        }
        private int _MaNV;
        public int ManNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        private string _LyDo;
        public string LyDo
        {
            get { return _LyDo; }
            set { _LyDo = value; }
        }
        private Boolean _CoPhep;
        public Boolean CoPhep
        {
            get { return _CoPhep; }
            set { _CoPhep = value; }
        }
        private Boolean _NghiKhongLuong;
        public Boolean NghiKhongLuong
        {
            get { return _NghiKhongLuong; }
            set { _NghiKhongLuong = value; }
        }


        private DateTime _NgayNghi;
        private string text1;
        private string text2;
        private string v;
        private bool checked1;
        private bool checked2;

        public DateTime NgayNghi
        {
            get { return _NgayNghi; }
            set { _NgayNghi = DateTime.Now; }
        }
        public NghiLam(int manghi, int manv, DateTime ngaynghi, Boolean cophep, Boolean nghikhongluong)
        {
            this._Manghi = manghi;
            this._MaNV = manv;
            this._NgayNghi = ngaynghi;
            this._CoPhep = cophep;
            this._NghiKhongLuong = nghikhongluong;
        }

        public NghiLam(string text1, string text2, string v, bool checked1, bool checked2)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.v = v;
            this.checked1 = checked1;
            this.checked2 = checked2;
        }
    }
}
