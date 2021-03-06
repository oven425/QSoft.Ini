﻿using System;
using System.Collections.Generic;

namespace ConsoleApp_IniT
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type1 = typeof(TimeSpan);
            
            QSoft.Ini.IniSerializer ini = new QSoft.Ini.IniSerializer();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("TimeSpan", new TimeSpan(1, 2, 3, 4));
            dic.Add("bool_true", bool.TrueString);
            dic.Add("bool_false", bool.FalseString);
            dic.Add("decimal_max", decimal.MaxValue);
            dic.Add("decimal_min", decimal.MinValue);
            dic.Add("Now", DateTime.Now);
            dic.Add("double_max", double.MaxValue);
            dic.Add("double_min", double.MinValue);
            dic.Add("Single_max", Single.MaxValue);
            dic.Add("Single_min", Single.MinValue);
            dic.Add("SByte_max", SByte.MaxValue);
            dic.Add("SByte_min", SByte.MinValue);
            dic.Add("char_max", char.MaxValue);
            dic.Add("char_min", char.MinValue);
            dic.Add("short_max", short.MaxValue);
            dic.Add("short_min", short.MinValue);
            dic.Add("int_max", int.MaxValue);
            dic.Add("int_min", int.MinValue);
            dic.Add("long_max", long.MaxValue);
            dic.Add("long_min", long.MinValue);
            dic.Add("byte_max", byte.MaxValue);
            dic.Add("byte_min", byte.MinValue);
            dic.Add("ushort_max", ushort.MaxValue);
            dic.Add("ushort_min", ushort.MinValue);
            dic.Add("uint_max", uint.MaxValue);
            dic.Add("uint_min", uint.MinValue);
            dic.Add("ulong_max", ulong.MaxValue);
            dic.Add("ulong_min", ulong.MinValue);
            dic.Add("string", "ini serialize");

            dic.Add("CTest", new CTest() { A = "答案A", B = 101, Test1 = new CTest_1() { A1 = "答案B", B1 = 202 } });
            dic.Add("Array", new int[] { 1, 2, 3 });
            dic.Add("List", new List<int>() { 1, 2, 3 });
            ini.Serialize("test", dic, "test.ini");


            Dictionary<string, object> dic1 = new Dictionary<string, object>();
            //dic1.Add("TimeSpan", new TimeSpan());
            //dic1.Add("bool_true", new bool());
            //dic1.Add("bool_false", new bool());
            //dic1.Add("decimal_max", decimal.MaxValue);
            //dic1.Add("decimal_min", decimal.MinValue);
            //dic1.Add("Now", new DateTime());
            //dic1.Add("double_max", new double());
            //dic1.Add("double_min", new double());
            //dic1.Add("Single_max", Single.MaxValue);
            //dic1.Add("Single_min", Single.MinValue);
            //dic1.Add("SByte_max", SByte.MaxValue);
            //dic1.Add("SByte_min", SByte.MinValue);
            //dic1.Add("char_max", char.MaxValue);
            //dic1.Add("char_min", char.MinValue);
            //dic1.Add("short_max", short.MaxValue);
            //dic1.Add("short_min", short.MinValue);
            //dic1.Add("int_max", int.MaxValue);
            //dic1.Add("int_min", int.MinValue);
            //dic1.Add("long_max", long.MaxValue);
            //dic1.Add("long_min", long.MinValue);
            //dic1.Add("byte_max", new byte());
            //dic1.Add("byte_min", new byte());
            //dic1.Add("ushort_max", new ushort());
            //dic1.Add("ushort_min", new ushort());
            //dic1.Add("uint_max", new uint());
            //dic1.Add("uint_min", new uint());
            //dic1.Add("ulong_max", new ulong());
            //dic1.Add("ulong_min", new ulong());
            string strrr = "";
            dic1.Add("string", strrr);
            //dic1.Add("CTest", new CTest() { });
            //dic1.Add("Array", new int[1]);
            //dic1.Add("List", new List<int>());

            ini.Deserialize("test", dic1, "test.ini");
            

            //CSetting inifile = new CSetting();
            //inifile.MaxCount = 1000;
            //inifile.MinCount = 1;
            //inifile.Name = "account";
            //inifile.Password = "password";
            //inifile.Time = new TimeSpan(10, 9, 9, 7);
            //inifile.Test = new CTest() { A = "A1", B = 1, Test1 = new CTest_1() { A1 = "A11", B1 = 100 } };
            //ini.Serialize(inifile, "test1.ini");

            CSetting inifile1 = new CSetting();
            ini.Deserialize(inifile1, "test1.ini");
        }

    }

    //[QSoft.Ini.IniSection(DefaultSection = "General")]
    public class CSetting
    {
        [QSoft.Ini.IniSectionKey(Section = "Auth", Key = "Account")]
        public string Name { set; get; }

        [QSoft.Ini.IniSectionKey(Section = "Auth", Key = "Password")]
        public string Password { set; get; }

        [QSoft.Ini.IniSectionKey(Ignore = true)]
        public int MaxCount { set; get; } = 100;

        [QSoft.Ini.IniSectionKey(Key = "MinCount")]
        public int MinCount { set; get; } = 10;
        [QSoft.Ini.IniSectionKey(Key = "Time")]
        public TimeSpan Time { set; get; }

        public CTest Test { set; get; }
    }

    public class CTest
    {
        public string A { set; get; }
        public int B { set; get; }
        public CTest_1 Test1 { set; get; } = new CTest_1();
    }

    public class CTest_1
    {
        public string A1 { set; get; }
        public int B1 { set; get; }
    }
}
