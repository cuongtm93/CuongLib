using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    /// <summary>
    ///  Trạng thái của kết quả thực hiện ajax
    /// </summary>
    public class AjaxStatus
    {
        /// <summary>
        ///  Thành công
        /// </summary>
        public const string success = nameof(success);

        /// <summary>
        ///  Thành công
        /// </summary>
        public const string error = nameof(error);

    }

    /// <summary>
    ///  Kết quả thực hiện ajax
    /// </summary>
    class AjaxResult
    {
        /// <summary>
        ///  Trạng thái của kết quả
        /// </summary>
        public string status;
        //public string message;
    }
}
