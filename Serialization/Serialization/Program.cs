using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Name = "walila";
            p1.Age = 33;
            p1.Email = "walila.daozei.com";
            #region 序列化介绍
            
            //json序列化
            //JavaScriptSerializer jsSer = new JavaScriptSerializer();
            //String msg = jsSer.Serialize(p1);
            //Console.WriteLine(msg);
            //Console.ReadKey();

            //xml序列化
            //XmlSerializer xml = new XmlSerializer(typeof(Person));
            //using(FileStream fs=new FileStream("person.xml",FileMode.Create))
            //{
            //    xml.Serialize(fs, p1);
            //}
            //Console.WriteLine("OK");
            #endregion

            #region 二进制序列化
            //创建序列化器
            //BinaryFormatter bf = new BinaryFormatter();
            ////创建一个文件流
            //using(FileStream fsWrite=new FileStream("person.bin",FileMode.Create))
            //{
            //    //开始执行序列化
            //    bf.Serialize(fsWrite, p1);
            //}
            //Console.WriteLine("序列化完毕");
            //Console.ReadKey();
            #endregion

            #region 反序列化
            //创建序列化器
            BinaryFormatter bf = new BinaryFormatter();
            //创建文件流
            using(FileStream fs=new FileStream("person.bin",FileMode.Open))
            {
                //执行反序列化
                object obj = bf.Deserialize(fs);
                Person person = obj as Person;
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Email);
            }
            Console.WriteLine("OK");
            Console.ReadKey();
            #endregion
        }

        [Serializable]//被序列化对象的类型必须被标记为可序列化，其所有父类和所有包含的字段也是可序列化的
        public class Person
        {
            public string Name
            {
                get;
                set;
            }
            public int Age
            {
                get;
                set;
            }
            public String Email
            {
                get;
                set;
            }
        }
    }
}
