using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entity;
namespace DAL
{
    public class SqlConnect
    {
        public static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LINH\SQLEXPRESS;Initial Catalog=EmployeesManagerment;Integrated Security=True");
            return conn;
        }
    }

}
