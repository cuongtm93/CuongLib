using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
///  Định nghĩa này để gọi 1 số hàm json sẵn có của browser
/// </summary>
public class JSON
{
    public extern static string stringify(dynamic data);

    public extern static object parse(string jsonString);
}

