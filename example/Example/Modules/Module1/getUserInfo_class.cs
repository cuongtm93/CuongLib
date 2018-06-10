using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Library;
namespace Modules.Module1
{
    public class getUserInfo : Function
    {
        private string _value;

        public GetUserInfoAjax ajax;
        public override void Execute()
        {
            Step1();
        }
        public virtual void Step1()
        {
            ajax = new Module1.GetUserInfoAjax
            {
                success = Step1_ok,
                error = Step1_error
            };

            ajax.Request();
        }

        private void Step1_error(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            throw new NotImplementedException();
        }

        private void Step1_ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var value = data.As<WebExample.User>();
            Step2(value.Name);
        }

        public virtual void Step2(string name)
        {
            dom.alert($"call anthoer ajax here {name}");
        }
    }
}
