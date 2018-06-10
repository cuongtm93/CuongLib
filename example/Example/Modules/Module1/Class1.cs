using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Module1
{
    public class Class1 : Class
    {
        /// <summary>
        ///  Khởi tạo các hàm cần dùng ở đây
        /// </summary>
        public Class1()
        {
            getUserInfo = new getUserInfo();
            exampleFunc = new ExampleFunc();
        }
        public getUserInfo getUserInfo;
        public ExampleFunc exampleFunc;

        public void ClassOwnerFunction()
        {
            getUserInfo.Execute();
            exampleFunc.Execute();
        }
    }
}
