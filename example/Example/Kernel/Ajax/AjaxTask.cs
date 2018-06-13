using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Http;
using Kernel.Browser;
using Kernel.Attributes;

namespace Kernel
{
    [Tested]
    public partial class AjaxTask : Ajax
    {

        public bool requestError { get; set; }
        /// <summary>
        /// Thời gian chờ dữ liệu tối đa, tính bằng mili giây
        /// </summary>
        public int TimeCanWait { get; set; }
        public object AjaxResult { get; set; }
        public AjaxTask()
        {
            Async = true;
            success = _sucessTask;
            error = _errorTask;
        }

        [Tested]
        public async Task<dynamic> Execute()
        {
            PrepareAjaxOptions();
            var Ajax = jquery.jQuery.ajax(new jquery.JQuery.AjaxSettings<object>
            {
                data = data,
                async = Async,
                method = Method,
                url = Url,
                success = _sucessTask,
                error = _errorTask
            }).ToTask();

            // Chờ khi thực hiện xong ajax thì trả về chuỗi thông báo
            await Task.WhenAll(Ajax);
            return AjaxResult;

        }
        private void _errorTask(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            requestError = true;
        }

        [Tested]
        private void _sucessTask(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            requestError = false;
            AjaxResult = data;
        }
    }
}
