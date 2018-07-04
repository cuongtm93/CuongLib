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

    /// <summary>
    ///  Cách sử dụng :  var x = Javascript.@typeof(var);
    /// </summary>
    /// <param name="variable"></param>
    /// <returns> Trả về chuỗi chứa kiểu của biến </returns>
    [Template("typeof({variable})")]
    public static string @typeof(dynamic variable)
    {
        // dòng lệnh này chỉ là để cho hàm @typeof là hợp lệ
        return string.Empty;
    }
}

