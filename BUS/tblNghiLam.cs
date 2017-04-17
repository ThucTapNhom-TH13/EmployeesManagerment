using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    class tblNghiLam
    {
        tblNghiLam dal_nghilam = new tblNghiLam();
        public bool Insert(tblNghiLam nlam)
        {
            return dal_nghilam.Insert(nlam);
        }
        public bool Delete(string maN)
        {
            return dal_nghilam.Delete(maN);
        }
        public bool Update(tblNghiLam nlam)
        {
            return dal_nghilam.Update(nlam);
        }
        public DataTable Get(string txt)
        {
            return dal_nghilam.Get(txt);
        }
        public DataTable GET()
        {
            return dal_nghilam.GET();
        }
    }
}
