using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Http;
using Library.Attributes;

namespace Library.Browser
{
    /// <summary>
    ///  Xử lý dữ liệu trên trình duyệt
    /// </summary>
    public class Data
    {
        /// <summary>
        ///  Lấy giá trị của element
        /// </summary>
        /// <typeparam name="T"> Kiểu đối tượng trong lớp Retyped.dom </typeparam>
        /// <param name="indentifer"> Id </param>
        /// <returns></returns>
        /// 
        [Tested]
        public T getValueById<T>(string indentifer)
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
        public T getElementById<T>(string indentifer)
        {
            return jquery.jQuery.select(indentifer.Id()).first()[0].Cast<T>();
        }


        public void setValue(string indentifer, string value)
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
        public dynamic getKendoGrid(string indentifer)
        {
            return jquery.jQuery.select(indentifer.Id()).data("kendoGrid");
        }

        /// <summary>
        ///   Refresh lại dữ liệu cho kendogrid
        /// </summary>
        /// <param name="grid"> grid được lấy từ hàm getKendoGrid</param>
        /// 

        [Tested]
        public void kendGridReloadData(dynamic grid)
        {
            grid.dataSource.read();
        }


        /// <summary>
        ///  Jquery selector
        /// </summary>
        /// <param name="jquerySelector"></param>
        /// <returns></returns>
        /// 
        [Tested]
        public dynamic select(string jquerySelector)
        {
            return jquery.jQuery.select(jquerySelector).As<dynamic>();
        }
    }
}
