using IService2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service2
{
    public class TestService : ITestService
    {
        public int GetTest()
        {
            return 123;
        }
    }
}
