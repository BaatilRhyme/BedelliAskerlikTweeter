using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedelliAskerlikTweeter
{
    public static class Extensions
    {
        public static bool HasValue(this object obj)
        {
            if (obj == null)
                return false;
            else
                return !string.IsNullOrEmpty(obj.ToString());
        }
    }
}
