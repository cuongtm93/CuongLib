using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Http;
using Kernel.Attributes;
namespace Kernel.Browser
{
    /// <summary>
    ///  Xử lý dữ liệu trên trình duyệt
    /// </summary>
    public class Data : Class
    {
        /// <summary>
        ///  Lấy giá trị của element
        /// </summary>
        /// <typeparam name="T"> Kiểu đối tượng trong lớp Retyped.dom </typeparam>
        /// <param name="indentifer"> Id </param>
        /// <returns></returns>
        /// 
        [Tested]
        public virtual T getValueById<T>(string indentifer)
        {
            return jquery.jQuery.select(indentifer.Id()).val().As<T>();
        }

        /// <summary>
        ///  Hàm document.getElementbyId
        /// </summary>
        /// <typeparam name="T"> Kiểu đối tượng trong lớp Retyped.dom </typeparam>
        /// <param name="indentifer"> Id </param>
        /// <returns></returns>
        /// 
        [Tested]
        public virtual T getElementById<T>(string indentifer)
        {
            return jquery.jQuery.select(indentifer.Id()).first()[0].Cast<T>();
        }


        public virtual void setValue(string indentifer, string value)
        {
            jquery.jQuery.select(indentifer).val(value);
        }

        /// <summary>
        ///  Lấy kendo grid để xử lý
        /// </summary> dom.alert("Đã chạy");
        /// <param name="indentifer"> Id </param>
        /// <returns></returns>
        /// 
        [Tested]
        public virtual dynamic getKendoGrid(string indentifer)
        {
            return jquery.jQuery.select(indentifer.Id()).data("kendoGrid");
        }

        /// <summary>
        ///   Refresh lại dữ liệu cho kendogrid
        /// </summary>
        /// <param name="grid"> grid được lấy từ hàm getKendoGrid</param>
        /// 

        [Tested]
        public virtual void kendGridReloadData(dynamic grid)
        {
            grid.dataSource.read();
        }


        /// <summary>
        ///  Jquery selector
        /// </summary>
        /// <param name="jquerySelector"></param>
        /// <returns></returns>
        /// 

        [EventHandler]
        public static dynamic query(string jquerySelector)
        {
            return jquery.jQuery.select(jquerySelector).As<dynamic>();
        }

        public static void ShowMessage(string message, string status="")
        {
            var popupNotification = query("#popupNotification").data("kendoNotification");
            popupNotification.show(message, status);
        }
    }
}
