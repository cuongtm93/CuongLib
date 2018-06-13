using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Http;
using Kernel.Browser;

namespace Kernel
{
    public partial class AjaxTask : Ajax
    {
        public object AjaxResult { get; set; }
        public AjaxTask()
        {
            Async = true;
            success = _sucessTask;
            error = _errorTask;
        }

        public Task<string> GetResult()
        {
            return Task.Run(() =>
            {

                this.Request();
                return "running";
            });
        }
        private void _errorTask(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            Javascript.debugger();
            dom.alert("Lỗi mất tiêu");
            // Lỗi xảy ra
            AjaxResult = "Lỗi";
        }

        private void _sucessTask(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            Javascript.debugger();
            Console.Write(data);
            AjaxResult = data;
        }
    }
}
