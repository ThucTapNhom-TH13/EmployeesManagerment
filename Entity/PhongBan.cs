using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PhongBan
    {
        private int mapb;
        private string tenpb;
        private string diadiem;
        private int matp;

        public int Mapb
        {
            get
            {
                return mapb;
            }

            set
            {
                mapb = value;
            }
        }

        public string Tenpb
        {
            get
            {
                return tenpb;
            }

            set
            {
                tenpb = value;
            }
        }

        public string Diadiem
        {
            get
            {
                return diadiem;
            }

            set
            {
                diadiem = value;
            }
        }

        public int Matp
        {
            get
            {
                return matp;
            }

            set
            {
                matp = value;
            }
        }
        public PhongBan(int mapb, string tenpb, string diadiem, int matp)
        {
            this.mapb = mapb;
            this.tenpb = tenpb;
            this.diadiem = diadiem;
            this.matp = matp;
        }
        public PhongBan( string tenpb, string diadiem, int matp)
        {
            this.tenpb = tenpb;
            this.diadiem = diadiem;
            this.matp = matp;
        }
    }
}
