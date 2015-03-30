using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.test.CodeToTest
{
    public class MocClass 
    {
        private readonly ILogin ilogin;
        public MocClass(ILogin ilogin)
        {
            this.ilogin = ilogin;
        }   
        public IClient getClient(string log)
        {
            return ilogin.getClient(log);
        }
    }
}
