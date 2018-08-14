using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 对Type类型的介绍

            //获取一个类型的Type
            //MyClass m = new MyClass();
            //Type type1 = m.GetType();//获得了Myclass对应的Type

            //Type type2 = typeof(MyClass);//通过typeof关键字，无需获取MyClass类型的对象就可以拿到MyClass的Type对象
            ////获取当前类型的父类
            //Console.WriteLine(type2.BaseType.ToString());
            ////获取当前类型中的所有的字段信息,只能获取非私有字段
            //FieldInfo[] fileds = type2.GetFields();
            //Console.WriteLine("当前类型中的字段有：");
            //for (int i = 0; i < fileds.Length; i++)
            //{
            //    Console.WriteLine(fileds[i]);
            //}
            ////获取当前类型中的都所有属性
            //Console.WriteLine("当前类型中的属性有:");
            //PropertyInfo[] propery = type2.GetProperties();
            //for (int i = 0; i < propery.Length; i++)
            //{
            //    Console.WriteLine(propery[i]);
            //}
            //Console.ReadKey();
            #endregion

            #region 动态加载程序集
            //动态加载程序集
            Assembly asm=Assembly.LoadFile(@"E:\C#_project\Reflect\Person\bin\Debug\Person.dll");
            //获取该程序集中的所有类型
            Console.WriteLine("程序集中所有类型：");
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].Name);
            }
            //获取指定类型
            Type typePerson = asm.GetType("Person.Person");
            //调用Person类中的一个方法
            MethodInfo method = typePerson.GetMethod("Say");
            Object obj = Activator.CreateInstance(typePerson);

            MethodInfo method2 = typePerson.GetMethod("SayHello", new Type[] { typeof(String) });

            //调用该方法
            method.Invoke(obj, null);
            method2.Invoke(obj,new object[] {"HEllo"});
            
            #endregion

            #region 通过Type创建对象
           //根据Person的Type创建一个Person类型
            //通过调用指定的构造函数来创建对象
           ConstructorInfo info = typePerson.GetConstructor(new Type[] {typeof(String )});
            //调用构造函数创建对象
           object obj3=info.Invoke(new object[] { "Sam" });
            //通过反射获取指定对象的属性的值
           PropertyInfo pro = typePerson.GetProperty("name");
           String name=pro.GetValue(obj3, null).ToString();
           Console.WriteLine(name);
            #endregion

           Console.ReadKey();
        }
    }
    class MyClass
    {
        public String Name
        {
            get;
            set;
        }
        public string hoppy;
        public int age;
        public void Say()
        {
            Console.WriteLine("你好");
        }
        private void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
