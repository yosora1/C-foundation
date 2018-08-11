using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChain
{
     public delegate void MyDelegate();
    class Program
    {
       
        static void Main(string[] args)
        {
            #region 多播委托
            Action<String> action=M1;
            action+=M2;
            action+=M3;
            action+=M4;
            action("AAA");
            Console.ReadKey();
            action -= M3;
            action("BBB");
            Console.ReadKey();
            #endregion 

            MyDelegate md = new MyDelegate(T1);
            md=(MyDelegate)Delegate.Combine(md, new MyDelegate(T2),new MyDelegate(T3));
            md();
            Console.ReadKey();
        }
        static void T1()
        {
            Console.WriteLine("ok");
            
        }
        static void T2()
        {
            Console.WriteLine("ok2");
        }
        static void T3()
        {
            Console.WriteLine("ok3");
        }
        static void M1(String msg)
        {
            Console.WriteLine(msg);
        }
        static void M2(String msg)
        {
            Console.WriteLine(msg+"2");
        }
        static void M3(String msg)
        {
            Console.WriteLine(msg+"3");
        }
            static void M4(String msg)
        {
            Console.WriteLine(msg+"4");
        }
        
    }
}
