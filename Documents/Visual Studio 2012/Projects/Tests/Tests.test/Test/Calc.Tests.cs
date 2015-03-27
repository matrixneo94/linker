using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tests.test.CodeToTest;

namespace Tests.test.Test
{
      [TestFixture]
    class CalcTest
    {
          [Test]
          public void CalcIsNotNull()
          {
              Calc calc = new Calc();
              Assert.IsNotNull(calc.CreateCalc());
          }
        
          [TestCase(3, 4, 7)]
          [TestCase(9, 12, 21)]
          [TestCase(21, 5, 26)]
          public void CalcAddIntsTest(int a, int b, int result)
          {
              Calc calc = new Calc();
              Assert.IsInstanceOfType(typeof(int),calc.AddTwoInt(a,b));
              Assert.AreEqual(result,calc.AddTwoInt(a,b));
          }
          [TestCase(3, 4, -1)]
          [TestCase(9f, 12f, -3f)]
          [TestCase(21f, 5f, 16f)]
          public void CalcSubstractTwoFloatTest(float a, float b, float result)
          {
              Calc calc = new Calc();
              Assert.IsInstanceOfType(typeof(float), calc.SubstractTwoFloat(a, b));
              Assert.AreEqual(result, calc.SubstractTwoFloat(a, b));
          }
          [TestCase(8, 4, 2)]
          [TestCase(12, 9, 0.333d)]
          [TestCase(14, 3.5, 4)]   
          public void CalcDivisonTwoDoubleTest(double a, double b, double result)
          {
              Calc calc = new Calc();
              Assert.IsInstanceOfType(typeof(double), calc.DivisionTwoDouble(a, b));
              Assert.AreEqual(result, calc.DivisionTwoDouble(a, b));
          }
         

    }
}
