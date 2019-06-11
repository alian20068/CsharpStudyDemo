using System;

namespace SimpleFactory2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("业务代码的封装");
            Console.WriteLine("新需求：增加开根运算怎么改？");
            Console.WriteLine("提示：假如让你维护薪资系统，已有经理、销售、技术人员的薪资算法，现在增加兼职人员算法。按现在的写法，公司必须把含3种算法的类给你，让你修改，你觉得工资低，把技术人员的算法修改，对于公司来说，是不是风险很大？");
            Console.WriteLine("");

            Console.Write("请输入数字A：");
            string numberA = Console.ReadLine();
            Console.Write("请选择运算符号（+、-、*、/）：");
            string strOperate = Console.ReadLine();
            Console.Write("请输入数字B：");
            string numberB = Console.ReadLine();

            double.TryParse(numberA, out var dA);
            double.TryParse(numberB, out var dB);

            string strResult = CalculateClass.GetResult(dA, dB, strOperate).ToString();

            Console.WriteLine("结果是：" + strResult);
            Console.ReadLine();
        }
    }
}
