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
    public partial class Ajax
    {
        /// <summary>
        ///  Hàm sẽ gọi khi thực gọi ajax thành công
        /// </summary>
        public virtual jquery.JQuery.Ajax.SuccessCallback<object> success { get; set; }

        /// <summary>
        ///  Hàm sẽ gọi khi thực gọi ajax thất bại
        /// </summary>
        public virtual jquery.JQuery.Ajax.ErrorCallback<object> error { get; set; }

        /// <summary>
        ///  relative or absolute url
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        ///  ajax data
        /// </summary>
        public virtual Bridge.Union<jquery.JQuery.PlainObject<object>, string> data { get; set; }

        /// <summary>
        ///  Asynchronous
        /// </summary>
        public virtual bool Async { get; set; }

        /// <summary>
        ///  Http Method
        /// </summary>
        public virtual string Method { get; set; }

        /// <summary>
        /// Nếu ValidDataType khác null thì
        ///  : Kiểm tra kiểu dữ liệu trước khi gửi ajax.
        /// Nếu nó bằng null thì không kiểm tra. 
        /// </summary>

        private bool _isValidRequest = true;
        public Ajax()
        {
            // Mặc định
            SetDefaultParameters();
        }

        /// <summary>
        ///  Thiết lập tham số mặc định
        /// </summary>
        public virtual void SetDefaultParameters()
        {
            Async = true;
            Method = HttpMethod.GET;
        }
        /// <summary>
        ///  Gọi ajax
        /// </summary>
        public virtual void Request()
        {
            ValidateRequest();
            PrepareAjaxOptions();
            Javascript.debugger();
            if (_isValidRequest)
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

        public virtual void ValidateRequest()
        {
            _isValidRequest = !string.IsNullOrWhiteSpace(Url);

            if (!_isValidRequest)
                ShowMessageForNotValidRequest();
        }

        public virtual void ShowMessageForNotValidRequest()
        {
            dom.alert("Request không hợp lệ");
            var ajaxRequestParams = new
            {
                Url,
                data,
                Method,
                Async
            }.ToDynamic();
            Console.WriteLine("Request không hợp lệ : ");
            Console.WriteLine(ajaxRequestParams);
        }
        public virtual void ShowNotSupportMethod()
        {
            Console.WriteLine("Hiện tại thư viện chưa hỗ trợ phương thức này");
        }
        public virtual void PrepareAjaxOptions()
        {
            Javascript.debugger();
            // Request không có data
            if (data == null)
            {
                data = new { }.As<dynamic>(); // object json string
            }

            switch (data.GetType().Name)
            {
                case "String":
                    // đã test
                    // truyền trực tiếp data vào url
                    Url += data;
                    data = new { }.ToDynamic();
                    break;
                case "Object" when Method == HttpMethod.GET  :
                    // đã test
                    // chính là json
                    data = jquery.jQuery.param(data.As<dynamic>());
                    break;
                case "Object" when Method == HttpMethod.POST:
                    // khi post thì dữ liệu kiểu json
                    break;
                default :
                    // đã test
                    // Kiểu dữ liệu model
                    data = jquery.jQuery.param(data.As<dynamic>().toJSON());
                    break;
            }
        }
    }
}
