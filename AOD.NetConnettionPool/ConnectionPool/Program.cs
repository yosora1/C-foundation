using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionPool
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 启用ado.net连接池
            //String constr = "Data Source=DESKTOP-40POHN9;Initial Catalog=Test;Integrated Security=True";
            ////默认情况下.net启用了连接池
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    using (SqlConnection con = new SqlConnection(constr))
            //    {
            //        con.Open();
            //    }
            //}
            //watch.Stop();
            //Console.WriteLine(watch.Elapsed);
            //Console.ReadKey();
            #endregion

            #region 禁用ado.net连接池
            String constr = "Data Source=DESKTOP-40POHN9;Initial Catalog=Test;Integrated Security=True;Pooling=false";
            //禁用了aod.net连接池（禁用连接池之后连接时间会明显增长）
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 1000; i++)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                }
            }
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.ReadKey();
            #endregion
        }
    }
}
