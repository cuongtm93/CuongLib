using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
namespace Modules.Module1
{
    public class ExampleFunc : getUserInfo
    {
        public override void Step1()
        {
            ajax = new GetUserInfoAjax();
            ajax.success = my_news;
            ajax.Request();
        }

        private void my_news(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var value = data.As<WebExample.User>();
            Step2(value.Id.ToString());
        }
       
    }
}
