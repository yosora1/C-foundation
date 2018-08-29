using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace EncapsulationConnectionPool
{
    public static class SqlHelper
    {
        //定义连接字符串
        //readonly修饰的变量，只能在初始化以及构造函数中赋值，其他地方只能读取不能赋值
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;

        //执行增删改-------ExecuteNonQuery()
        public static int ExcuteNonQuery(String sql,params SqlParameter[] pms)
        {
            using (SqlConnection con=new SqlConnection(conStr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //执行查询返回单个值-----ExecuteScalar()
        public static object ExecuteScalar(String sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //执行返回多行多列的方法------ExecuteReader()
        public static SqlDataReader ExecuteReader(string sql,params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(conStr);
            
                using (SqlCommand cmd=new SqlCommand(sql,con))
                {
                    if (pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    try
                    {
                        con.Open();
                        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    }
                    catch
                    {
                        con.Close();
                        con.Dispose();
                        throw;
                    }
                }
            
        }
    }
}
