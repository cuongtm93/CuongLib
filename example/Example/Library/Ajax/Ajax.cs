using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Http;
namespace Library
{
    public partial class Ajax
    {

        public virtual jquery.JQuery.Ajax.SuccessCallback<object> success { get; set; }
        public virtual jquery.JQuery.Ajax.ErrorCallback<object> error { get; set; }
        public virtual string Url { get; set; }
        public virtual Bridge.Union<jquery.JQuery.PlainObject<object>, string> data { get; set; }

        public virtual bool Async { get; set; }

        public virtual string Method { get; set; }

        public Ajax()
        {
            // Mặc định
            Async = true;
            Method = HttpMethod.GET;
        }
        public virtual void Request()
        {
            prepareAjaxOptions();

            jquery.jQuery.ajax(new jquery.JQuery.AjaxSettings<object>
            {
                data = data,
                async = Async,
                method = Method,
                url = Url,
                success = success,
                error = error
            });
        }

        public virtual void prepareAjaxOptions()
        {
            switch (Method)
            {
                case "GET":

                    if (!data.Is<string>())
                        data = jquery.jQuery.param(data.As<object>());

                    break;
                case "POST":

                    data = data.As<dynamic>().toJSON();
                    break;

                default:
                    break;
            }
        }
    }
}
