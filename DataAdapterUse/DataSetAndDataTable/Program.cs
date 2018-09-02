using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetAndDataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个Dataset,DataSet就是一个临时数据库
            DataSet ds = new DataSet("School");
            //创建一张表
            DataTable dt = new DataTable("Student");
            //向表中创建列
            DataColumn dcAutoId = new DataColumn("AutoId", typeof(int));
            dcAutoId.AutoIncrement = true;
            dcAutoId.AutoIncrementSeed = 1;
            dcAutoId.AutoIncrementStep = 1;
            dt.Columns.Add(dcAutoId);
            DataColumn dcUserName=dt.Columns.Add("Name",typeof(String));
            dcUserName.AllowDBNull = false;

            //向表中增加行
            DataRow one=dt.NewRow();
            one["Name"]="ABC";
            dt.Rows.Add(one);
            DataRow tow = dt.NewRow();
            tow["Name"] = "QWE";
            dt.Rows.Add(tow);

            //将表加入数据库
            ds.Tables.Add(dt);

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Console.WriteLine("TableName:",ds.Tables[i].TableName);
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    DataRow row = ds.Tables[i].Rows[j];
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        Console.Write(row[c]+"     || ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
