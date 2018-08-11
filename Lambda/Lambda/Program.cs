using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 没有参数没有返回值的方法使用lambda表达式
            MyDelegate md = () => { Console.WriteLine("lambda表达式"); };
            md();
            Console.ReadKey();
            #endregion

            #region 有参数的lambda表达式
            Mydelegate md2 = m => { Console.WriteLine(m); };
            md2("有参数的lambda表达式");
            Console.ReadKey();
            #endregion

            #region 有参数有返回值的lambda表达式
            AddDelegate1 ad = (arr) => 
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
                return arr.Sum();
            };
            int a = ad(1,2,3,4,5);
            Console.WriteLine(a);
            Console.ReadKey();
            #endregion
        }

        public delegate void MyDelegate();
        public delegate void Mydelegate(String msg);
        public delegate int AddDelegate1(params int[] arr);
    }
}
