using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.test.CodeToTest
{
   public interface ILogin
    {     
        IClient getClient(string log);
    }
}
