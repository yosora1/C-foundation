using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        public Person() { }
        public Person(String name)
        {
            this.name = name;
        }
        public String name
        {
            get;
            set;
        }
        public int age
        {
            get;
            set;
        }
        public void Say()
        {
            Console.WriteLine("你好");
        }

        public void SayHello(String msg)
        {
            Console.WriteLine(msg);
        }
        static void Main(string[] args)
        {
        }
    }

    public interface IFlyable
    {
        void Fly();
    }

    public class Students : Person
    {

    }

    public delegate void Mydelegate();

    public struct MyStruct
    {

    }

    public enum MyEnum
    {

    }
}
