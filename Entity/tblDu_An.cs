using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    public class tblDu_An
    {
        private int maDuan;
        private string tenDuan;
        private string diaDiem;
        private DateTime ngayBd;
        private DateTime ngayKt;
        private int maPb;

        public int MaDuan
        {
            get
            {
                return maDuan;
            }

            set
            {
                maDuan = value;
            }
        }

        public string TenDuan
        {
            get
            {
                return tenDuan;
            }

            set
            {
                tenDuan = value;
            }
        }

        public string DiaDiem
        {
            get
            {
                return diaDiem;
            }

            set
            {
                diaDiem = value;
            }
        }

        public DateTime NgayBd
        {
            get
            {
                return ngayBd;
            }

            set
            {
                ngayBd = value;
            }
        }

        public DateTime NgayKt
        {
            get
            {
                return ngayKt;
            }

            set
            {
                ngayKt = value;
            }
        }

        public int MaPb
        {
            get
            {
                return maPb;
            }

            set
            {
                maPb = value;
            }
        }
        public tblDu_An(string tenda, string diadiem, DateTime ngaybd, DateTime ngaykt, int mapb)
        {
            this.tenDuan = tenda;
            this.diaDiem = diadiem;
            this.ngayBd = ngaybd;
            this.ngayKt = ngaykt;
            this.MaPb = mapb;
        }
        public tblDu_An(int mada,string tenda, string diadiem, DateTime ngaybd, DateTime ngaykt, int mapb)
        {
            this.maDuan = mada;
            this.tenDuan = tenda;
            this.diaDiem = diadiem;
            this.ngayBd = ngaybd;
            this.ngayKt = ngaykt;
            this.MaPb = mapb;
        }
    }
}
