using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Attributes
{
    public class TestedAttribute : System.Attribute
    {
        public TestedAttribute(string msg="")
        {
            if (!string.IsNullOrWhiteSpace(msg))
                Console.WriteLine(msg);
        }
    }

    public class EventHandlerAttribute : System.Attribute
    {
        public EventHandlerAttribute(string msg = "")
        {
            if (!string.IsNullOrWhiteSpace(msg))
                Console.WriteLine(msg);
        }
    }
}
