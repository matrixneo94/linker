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
    [TestFixture]
    class MocClassToTest
    {
        private ILogin login;

       
        [Test]
        public void MocTestInterface()
        {
            var mock = new Mock<IClient>();
            mock.Setup(client => client.Login).Returns("blabla");
            mock.Setup(client => client.Login).Returns("innedane");
            mock.Setup(client => client.WhenLogged).Returns(DateTime.Now);
            mock.Setup(client => client.Logged).Returns(true);
            var mockLogin = new Mock<ILogin>();
            mockLogin.Setup(log => log.getClient("log")).Returns(mock.Object);
            var testMoc = new MocClass(mockLogin.Object);
            IClient iclient = testMoc.getClient("log");
            mockLogin.Verify(verify => verify.getClient("log"), Times.Once());
            Assert.AreEqual(mock.Object.Logged, iclient.Logged);
            Assert.AreEqual(mock.Object.Login, iclient.Login);
            Assert.AreEqual(mock.Object.Password, iclient.Password);
            Assert.AreEqual(mock.Object.WhenLogged, iclient.WhenLogged);


        }
    }
}
