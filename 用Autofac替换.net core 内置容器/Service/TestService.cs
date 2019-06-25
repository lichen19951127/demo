using IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class TestService : ITestService
    {
        public int GetTest()
        {
            return 123;
        }
    }
}
