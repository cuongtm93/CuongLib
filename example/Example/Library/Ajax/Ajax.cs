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
        public Type ValidDataType;

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

            if (ValidDataType != null)
            {
                _isValidRequest &= data.GetType() == ValidDataType;
            }
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
            // Request không có data
            if (data == null)
                data = new object().ToDynamic();


            switch (Method)
            {
                case HttpMethod.GET:

                    if (!data.Is<string>())
                    {
                        var JsonData = data.As<dynamic>().toJSON();
                        data = jquery.jQuery.param(JsonData);
                    }
                    break;
                case HttpMethod.POST:

                    data = data.As<dynamic>().toJSON();
                    break;

                default:
                    ShowNotSupportMethod();
                    break;
            }
        }
    }
}
