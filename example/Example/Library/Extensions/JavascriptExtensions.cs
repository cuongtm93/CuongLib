using Bridge;
using Bridge.Html5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Javascript
{
    /// <summary>
    ///  Gọi hàm này để đặt lệnh debugger;
    /// </summary>
    [Template("debugger;")]
    public static void debugger()
    {
        
    }

    [Template("typeof({variable}")]
    public static string @typeof(dynamic variable)
    {
        return string.Empty;
    }
}

