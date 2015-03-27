using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.test.CodeToTest
{
    interface ICalc
    {
        Calc CreateCalc();
        int AddTwoInt(int a, int b);
        float SubstractTwoFloat(float a, float b);
        double DivisionTwoDouble(double a, double b);

    }
    class Calc:ICalc
    {
        public Calc CreateCalc()
        {
            //throw new NotImplementedException();
            
            return new Calc();
        }
        public int AddTwoInt(int a, int b)
        {
            //throw new NotImplementedException();
            return a + b;
        }
        public float SubstractTwoFloat(float a, float b)
        {
            //throw new NotImplementedException();
            return a - b;
        }
        public double DivisionTwoDouble(double a, double b)
        {
            //throw new NotImplementedException();
            return a / b;
        }
    }
}
