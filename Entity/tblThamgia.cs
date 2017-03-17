using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class tblThamgia
    {
        private int maNV;
        private int maDA;
        private float soGio;
        private string nhiemVu;

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

        public int MaDA
        {
            get
            {
                return maDA;
            }

            set
            {
                maDA = value;
            }
        }

        public float SoGio
        {
            get
            {
                return soGio;
            }

            set
            {
                soGio = value;
            }
        }

        public string NhiemVu
        {
            get
            {
                return nhiemVu;
            }

            set
            {
                nhiemVu = value;
            }
        }
        public tblThamgia(int manv, int mada, float sogio, string nhiemvu)
        {
            this.maDA = mada;
            this.maNV = manv;
            this.soGio = sogio;
            this.nhiemVu = nhiemvu;
        }
    }
}
