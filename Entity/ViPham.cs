using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ViPham
    {
        private int maVP;
        private string lydo;
        private string hinhthucKL;
        private DateTime ngayVP;
        private int maNV;

        public int MaVP
        {
            get
            {
                return maVP;
            }

            set
            {
                maVP = value;
            }
        }

        public string Lydo
        {
            get
            {
                return lydo;
            }

            set
            {
                lydo = value;
            }
        }

        public string HinhthucKL
        {
            get
            {
                return hinhthucKL;
            }

            set
            {
                hinhthucKL = value;
            }
        }

        public DateTime NgayVP
        {
            get
            {
                return ngayVP;
            }

            set
            {
                ngayVP = value;
            }
        }

        public int MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
            }
        }
        public ViPham(int mavp, string lydo, string kl, DateTime ngayVP,int manv)
        {
            this.maVP = mavp;
            this.lydo = lydo;
            this.hinhthucKL = kl;
            this.ngayVP = ngayVP;
            this.maNV = manv;
        }
        public ViPham(string lydo, string kl, DateTime ngayVP, int manv)
        {
            this.lydo = lydo;
            this.hinhthucKL = kl;
            this.ngayVP = ngayVP;
            this.maNV = manv;
        }
    }
}
