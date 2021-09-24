using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMarketProject.Controllers
{
    static public class Extension
    {
        public static bool NewContains(this string source,string ToCheck,StringComparison comp)
        {
            return source?.IndexOf(ToCheck, comp) >= 0;
        }
    }
}