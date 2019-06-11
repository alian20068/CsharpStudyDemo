using System;

namespace SimpleFactory1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("活字印刷" );
            Console.WriteLine("复制!=复用");
            Console.WriteLine("");

            Console.Write("请输入数字A：");
            string numberA = Console.ReadLine();
            Console.Write("请选择运算符号（+、-、*、/）：");
            string strOperate = Console.ReadLine();
            Console.Write("请输入数字B：");
            string numberB = Console.ReadLine();

            string strResult = string.Empty;
            double.TryParse(numberA, out var dA);
            double.TryParse(numberB, out var dB);

            switch (strOperate)
            {
                case "+":
                    strResult = (dA + dB).ToString();
                    break;
                case "-":
                    strResult = (dA - dB).ToString();
                    break;
                case "*":
                    strResult = (dA * dB).ToString();
                    break;
                case "/":
                    if (dB != 0)
                        strResult = (dA / dB).ToString();
                    else
                        strResult = "除数不能为0";
                    break;
                default:
                    strResult = "您的输入有误";
                    break;
            }

            Console.WriteLine("结果是：" + strResult);
            Console.ReadLine();
        }
    }
}
