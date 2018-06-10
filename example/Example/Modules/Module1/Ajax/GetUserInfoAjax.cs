using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajax;
using Retyped;

namespace Modules.Module1
{
    public class GetUserInfoAjax : Ajax.Home.GetUserInfo
    {
        public GetUserInfoAjax()
        {
            //_method = "POST";
            //_data = new WebExample.User()
            //{
            //    Id = 1
            //}.ToDynamic();
        }
        public override void GetFirst_Fail(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            base.GetFirst_Fail(jqXHR, textStatus, errorThrown);
        }
        public override void GetFirst_OK(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var value = data.As<WebExample.User>();
            dom.alert(value.Name);
            base.GetFirst_OK(data, textStatus, jqXHR);
        }
    }
}
