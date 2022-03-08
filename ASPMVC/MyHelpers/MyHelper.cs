using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPMVC.MyHelpers
{
    public static class MyHelper
    {
        public static string InsertImage(string path)
        {
            return String.Format("<img src=" + path + "/>");
        }
    }
}
