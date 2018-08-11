using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 泛型委托
            //Action非泛型委托，就是一个无参数，无返回值的委托
            //Action的泛型委托就是一个无返回值，但是参数可以变化的委托
            Action<String> a1 = m => { Console.WriteLine(m); };
            a1("泛型委托");

            Action<int, int> a2 = (x, y) => { Console.WriteLine(x+y); };
            a2(100, 100);
            Console.ReadKey();
            //Func委托只有泛型版本，参数列表中最后一个参数表示返回值类型
            Func<int, int, int, int> a3 = (x1, x2, x3) => { return x1 + x2 + x3; };
            Console.WriteLine(a3(1,2,3));
            Console.ReadKey();
            #endregion

            #region 使用lambda表达式
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            IEnumerable<int> ie = list.Where(x => { return x > 6; });
            foreach (var item in ie)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            #endregion
        }
    }
}
