using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Tests.test.CodeToTest;
namespace Tests.test.Test
{

    /*Testy mock - testy na nie zaimplementowanej klasie abstrakcyjnej lub interfejsie. Pozwala on nam na sprawdzenie zachowania się 
     * danego interfejsu lub klasy gdy nie mamy przygotowanej implementacji, ile razy zostanie wywołana, jakie metody zostały wywołane 
     * przy testach mock możemy wyspecjalizować parametry dla których ma zostać dana metoda wywołana.
     * Testy Stub - służą do sprawdzenia wartości danego obiektu, najpierw zajmujemy się wywołaniem jakiejś metody  po czym sprawdzamy 
     * rezultat tego wykonania, czy doszło do modyfikacji danych pól w danej klasie. Niestety testy Stub wymagają od nas częściowej 
     * implementacji interfejsu, bądź klasy abstrakcyjnej. 
     */
    [TestFixture]
    class MocClassToTest
    {
       
        [Test]
        public void MocTestInterface()
        {
            //Tworzymy obiekt mock z interfejsu IClient
            var mock = new Mock<IClient>();
            //inicjalizujemy parametry
            mock.Setup(client => client.Login).Returns("blabla");
            mock.Setup(client => client.Login).Returns("innedane");
            mock.Setup(client => client.WhenLogged).Returns(DateTime.Now);
            mock.Setup(client => client.Logged).Returns(true);
            var mockLogin = new Mock<ILogin>();
            mockLogin.Setup(log => log.getClient("log")).Returns(mock.Object);
           
            var testMoc = new MocClass(mockLogin.Object);
            IClient iclient = testMoc.getClient("log");
           //weryfikjemy czy dana metoda została wykonana, ile razy oraz czy zwróciła oczekiwany przez nas wynik
            
            mockLogin.Verify(verify => verify.getClient("log"), Times.Once());
            Assert.AreEqual(mock.Object.Logged, iclient.Logged);
            Assert.AreEqual(mock.Object.Login, iclient.Login);
            Assert.AreEqual(mock.Object.Password, iclient.Password);
            Assert.AreEqual(mock.Object.WhenLogged, iclient.WhenLogged);


        }
    }
}
