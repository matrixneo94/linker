using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Tests.test.CodeToTest;
/* Testy Tdd testy jednostkowe mające za zadanie sprawdzanie działania implementacji części kodu jednej metody przeważnie. 
 * Red light test - test po którym oczekujemy że się nie powiedzie, ponieważ piszemy go do nie zaimplementowanej klasy
 * Green light test - testy które mają się powieść piszemy najpierw implementacje metody/klasy a następnie testujemy 
 * Przy dokonywaniu testów korzystam z biblioteki NUnit, oraz Asercji.
 * 
 */
namespace Tests.test.Test
{
      [TestFixture]
    class Calc_Test
    {
          [Test]
          public void Calc_Is_Not_Null()
          {
              Calc calc = new Calc();

              //sprawdza czy został zainicjalizowany obiekt
              Assert.IsNotNull(calc.CreateCalc());              
          }
        //test wykonuje się dla wielu przypadków wcześniej zainicjalizowany
          [TestCase(3, 4, 7)]
          [TestCase(9, 12, 21)]
          [TestCase(21, 5, 26)]
          public void Calc_Add_Ints_Test(int a, int b, int result)
          {
              Calc calc = new Calc();

              //sprawdzam typ zwracanego obiektu 
              Assert.IsInstanceOfType(typeof(int),calc.AddTwoInt(a,b));
              //sprawdzam wynik czy jest taki jak oczeiwaliśmy
              Assert.AreEqual(result,calc.AddTwoInt(a,b));              
          }
          [TestCase(3, 4, -1)]
          [TestCase(9f, 12f, -3f)]
          [TestCase(21f, 5f, 16f)]
          public void Calc_Substract_Two_Float_Test(float a, float b, float result)
          {
              Calc calc = new Calc();
              Assert.IsInstanceOfType(typeof(float), calc.SubstractTwoFloat(a, b));
              Assert.AreEqual(result, calc.SubstractTwoFloat(a, b));
          }
          [TestCase(8, 4, 2)]          
          [TestCase(14, 3.5, 4)]
          [TestCase(10, 4, 2.5)]  
          public void Calc_Divison_Two_Double_Test(double a, double b, double result)
          {
              Calc calc = new Calc();
              Assert.IsInstanceOfType(typeof(double), calc.DivisionTwoDouble(a, b));
              Assert.AreEqual(result, calc.DivisionTwoDouble(a, b));
          }
         

    }
}
