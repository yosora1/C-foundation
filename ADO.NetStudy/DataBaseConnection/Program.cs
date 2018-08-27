using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    class Program
    {
        static void Main(string[] args)
        {
       //     insertData();
            selectData();
        }

        public static void insertData()
        {
            #region
            //创建连接字符串
            //Data Source=服务器名称或IP
            //Initial Catalog=初始化的连接分类（数据库名称）
            //Integrated Security=Ture(表示数据验证方式为以Windows身份验证)或写为ID=;Password=;
            String constr = "Data source=DESKTOP-40POHN9;Initial Catalog=Test;Integrated Security=true";
            //创建连接对象
            using (SqlConnection con = new SqlConnection(constr))
            {

                //编写SQL语句
                String sql = "insert into FirstTable values('jiang',22,'深圳')";
                //创建执行sql语句的命令对象sqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    //测试打开连接
                    //打开连接（如果打开数据连接没有问题，表示连接成功）最晚打开，最早关闭，节省资源
                    con.Open();
                    Console.WriteLine("Connection Success");

                    //开始执行sql语句
                    int a = cmd.ExecuteNonQuery();//inset\delete\update调用，
                    //只有执行inset\delete\update返回值是所影响的行数，否则返回-1
                    //cmd.ExecuteScalar();//查询返回单个结果时调用
                    //cmd.ExecuteReader();//返回结果集调用
                    Console.WriteLine("成功插入{0}条数据", a);
                    Console.ReadKey();
                }
                //关闭连接
                //     con.Close();using调用了dispose方法，该方法中调用了close函数
                //     con.Dispose();使用了using可不写dispose方法
            }
            Console.WriteLine("Close Connection,release resourse");
            Console.ReadKey();

            #endregion
        }

        public static void selectData()
        {
            //创建连接字符串
            String constr = "Data source=DESKTOP-40POHN9;initial catalog=Test;integrated security=true";
            //创建连接对象
            using (SqlConnection con = new SqlConnection(constr))
            {
                //创建sql语句
                String sql = "select * from FirstTable";
                //创建声明对象
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    //打开连接
                    con.Open();
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //获取当前reader指向的数据
                            //reader.FieldCount获取查询出的列的个数
                            //for (int i = 0; i < reader.FieldCount; i++)
                            //{
                            //    Console.Write(reader[i]+"  ||  ");
                                //reader索引器还可以根据列名获取列的值
                                //Console.Writer(reader["name"]);
                                //Console.Write(reader.GetValue(i) + "  ||  ");GetValue只能通过列的索引获取列的值
                                //通过reader.GetXxx()获取的类型不是Object，而是对应的类型，使用起来更方便,但如果数据为null就会报异常，需要手动来判断
                            
                      //      }
                       //     if(reader.IsDBNull(2)?null)

                            Console.Write(reader.GetString(0)+"||" + "\t\t");
                            Console.Write(reader.GetInt32(1) + "||" + "\t\t");
                          //Console.WriteLine(reader.IsDBNull(2)?"null":reader.GetString(2));判断是否为空
                            Console.Write(reader.GetString(2) + "||" + "\t\t");

                            Console.WriteLine();
                        }
                        
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
