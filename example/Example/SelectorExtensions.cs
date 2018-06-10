using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class SelectorExtensions
    {
        public static string Id(this string name)
        {
            return "#" + name;
        }

        public static string Class(this string name)
        {
            return "#" + name;
        }
        public static string Tag(this string name)
        {
            return name;
        }

    }
}
