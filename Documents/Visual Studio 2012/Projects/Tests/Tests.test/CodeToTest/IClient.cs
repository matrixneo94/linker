using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.test.CodeToTest
{
    public interface IClient
    {
         string Login { get; set; }
         string Password { get; set; }
         bool Logged { get; set; }
         DateTime WhenLogged { get; set; }
    }
}
