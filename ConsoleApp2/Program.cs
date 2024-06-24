﻿using System.ComponentModel;

namespace ConsoleApp2
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            HelloFrom("Generated Code");
            People pp = new People();
            //var aa = pp.GetInitString();
            Console.ReadLine();

           
        }

        static partial void HelloFrom(string name);
    }

    public partial class AugmentClass
    {
        public void AugmentMethod()
        {
            // 调用代码生成器中的方法
            //this.GeneratedMethod();
        }
    }

    [Description("AA")]
    [IniSection]
    public partial class People 
    {
        public string Name { set; get; }
        public int Age { set; get; }
    }

    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class IniSectionAttribute:Attribute
    {
        //public string Name {  get; set; }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IniIgnoreAttribute : Attribute
    {

    }

}
