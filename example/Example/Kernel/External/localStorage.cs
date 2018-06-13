using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class localStorage
{
    public static extern void setItem(string key, dynamic value);
    public static extern dynamic getItem(string key);
    public static extern void removeItem(string key);
}

