using Kernel.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel
{
    public class Function : IVoid
    {
        #region injections

        public Kernel.Browser.Helper data;

        #endregion

        /// <summary>
        ///  Gọi hàm này để thực thi một function class
        /// </summary>
        public virtual void Execute()
        {
            // Hàm này sẽ được định nghĩa lại trong từng Function
        }

        /// <summary>
        /// Khởi tạo các biến
        /// </summary>
        public virtual void VariablesInit()
        {
            // Hàm này sẽ được định nghĩa lại trong từng Function
        }

        public Function()
        {
            // Khởi tạo các thư viện hỗ trợ cho Function
            data = new Kernel.Browser.Helper();
        }
    }
}
