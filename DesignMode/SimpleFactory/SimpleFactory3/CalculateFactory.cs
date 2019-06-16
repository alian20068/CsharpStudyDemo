using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory3
{
    class CalculateFactory
    {
        public static CalculateBase CreateCalculate(string operate)
        {
            CalculateBase calculate = null;

            switch (operate)
            {
                case "+":
                    calculate = new CalculateAdd();
                    break;
                case "-":
                    calculate = new CalculateSub();
                    break;
                case "*":
                    calculate = new CalculateMul();
                    break;
                case "/":
                    calculate = new CalculateDiv();
                    break;
            }

            return calculate;
        }
    }
}
