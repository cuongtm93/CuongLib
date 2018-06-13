using System;
/*
 * 
 *  
 * 
 * 
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Bridge;
namespace Kernel
{

    public class KendoDatePicker
    {
        /// <summary>
        /// kendo namespace
        /// </summary>
        public dynamic kendo = Script.Get("kendo");

        /// <summary>
        /// Jquery prefix
        /// </summary>
        public dynamic jquery = Script.Get("jQuery");

        public string _kendoDatePickerId;


        public dynamic datePicker { get; set; }
        public KendoDatePicker(string Id)
        {
            _kendoDatePickerId = Id;
            datePicker = jquery(_kendoDatePickerId.Id()).data("kendoDatePicker");
            jquery(_kendoDatePickerId.Id()).kendoDatePicker();

        }
        public string GetDateTime()
        {
            return datePicker.value();
        }

        public void SetDateTime(DateTime dateTime)
        {
            try
            {
                dynamic kendoTime = kendo.toString(kendo.parseDate(dateTime), "MM/dd/yyyy");
                datePicker.value(kendoTime);

            }
            catch (Exception err)
            {
                Console.WriteLine($"Error :{err.Message}");
            }

        }

        /// <summary>
        ///  Lấy ngày hiện tại và chọn ngày này
        /// </summary>
        public void SetToday()
        {
            var datePicker = new KendoDatePicker(_kendoDatePickerId);
            datePicker.SetDateTime(DateTime.Now);
        }

        /// <summary>
        ///  Truy cập @this khi đang trong hàm xử lý event
        /// </summary>
        public KendoDatePicker @this => new KendoDatePicker(_kendoDatePickerId);
        public dom.HTMLInputElement @object => dom.document.getElementById(_kendoDatePickerId.Id()) as dom.HTMLInputElement;


        /// <summary>
        /// Làm cho datepicker trở thành width 100%
        /// </summary>
        public void getFullWidth()
        {
            Bridge.This.Get("this");
            @this.@object.ToDynamic(); // full width
        }

        /// <summary>
        ///  Làm cho datepicker chỉ đọc , không ghi được
        /// </summary>
        public void ReadOnly()
        {
            jquery(_kendoDatePickerId.Id()).attr("readonly", true);
        }
    }
}
