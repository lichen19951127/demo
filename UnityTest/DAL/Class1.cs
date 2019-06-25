using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public static class Class1
    {
        public static string CutString(this string str)
        {
           return str.Substring(0, str.Length - 1);
        }
        public static int GetDouble(this int num)
        {
            return num * 2;
        }
    }
}
