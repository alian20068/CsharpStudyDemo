using System;

namespace SimpleFactory3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("简单工厂");
            Console.WriteLine(@"到底要实例化哪个运算对象，将来会不会增加实例化对象（比如开根运算），
这是很容易变化地方，应该考虑用一个单独类来做创建实例的过程");
            Console.WriteLine("");

            Console.Write("请输入数字A：");
            string numberA = Console.ReadLine();
            Console.Write("请选择运算符号（+、-、*、/）：");
            string strOperate = Console.ReadLine();
            Console.Write("请输入数字B：");
            string numberB = Console.ReadLine();

            double.TryParse(numberA, out var dA);
            double.TryParse(numberB, out var dB);

            CalculateBase calculate;
            calculate = CalculateFactory.CreateCalculate(strOperate);
            calculate.NumberA = dA;
            calculate.NumberB = dB;

            string strResult = calculate.GetResult().ToString();

            Console.WriteLine("结果是：" + strResult);
            Console.ReadLine();
        }
    }
}
