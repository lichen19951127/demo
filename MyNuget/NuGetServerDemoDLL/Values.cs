using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetServerDemoDLL
{
    public static class Values
    {
        public static string GetValue(this string str)
        {
            return str + "000000000";
        }
    }
}
