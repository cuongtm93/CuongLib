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
    public class Helper : Class
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
            return dom.document.getElementById(indentifer).As<dom.HTMLInputElement>().value.As<T>();
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
            return dom.document.getElementById(indentifer).As<T>();
        }


        public virtual void setValue(string indentifer, string value)
        {
            dom.document.getElementById(indentifer).As<dom.HTMLInputElement>().value = value;
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
        ///  Chuyển  kendo grid {grid} về trang {page} với page size là {pagesize}
        /// </summary>
        /// <param name="grid"></param>
        [Tested]
        public virtual void kendGridNavigatePage(dynamic grid, int page = 1, int pagesize = 20)
        {
            var navigate_page = new
            {
                page = page,
                pageSize = pagesize
            };

            grid.dataSource.query(navigate_page);
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

        public static void ShowMessage(string message, string status = "")
        {
            var popupNotification = query("#popupNotification").data("kendoNotification");
            popupNotification.show(message, status);
        }
    }
}
