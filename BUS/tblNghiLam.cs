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
    public class tblNghiLam
    {
        tblNghiLam_DAL dal_nghilam = new tblNghiLam_DAL();
        public bool Insert(NghiLam nlam)
        {
            return dal_nghilam.Insert(nlam);
        }
        public bool Delete(int maN)
        {
            return dal_nghilam.Delete(maN);
        }
        public bool Update(NghiLam nlam)
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
        public DataTable statistic()
        {
            return dal_nghilam.statistic();
        }
    }
}
