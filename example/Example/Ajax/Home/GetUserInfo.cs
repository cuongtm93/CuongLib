using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Retyped;
using Library.Http;
namespace Ajax.Home
{
    public class GetUserInfo : Library.Ajax
    {
        public GetUserInfo()
        {
            Async = true;
            data = "";
            Url = "http://localhost:56995/home/getuserinfo";
            base.Method = HttpMethod.GET;

        }
        public void GetFirst()
        {
            Async = true;
            Url = "http://localhost:56995/home/getuserinfo";
            data = "";
            success = GetFirst_OK;
            error = GetFirst_Fail;

            Request();
        }


        public virtual void GetFirst_Fail(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            dom.alert("Lỗi rồi");
        }

        public virtual void  GetFirst_OK(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var user = data.As<WebExample.User>();
            dom.alert(user.Name);
        }
      
    }
}
