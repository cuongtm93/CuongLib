using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Http;
namespace Ajax.Home
{
    public class Find : Library.Ajax
    {
        public Find()
        {
            Url = "http://localhost:56995/home/Find";
            base.Method = HttpMethod.POST;
            var _test = new WebExample.User()
            {
                Id = 1,
                Name = "sdfsdf"
            };

            data = _test.ToDynamic();
            success = Find_Ok;
            error = Find_Fail;
            Request();
        }
        private void Find_Fail(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            throw new NotImplementedException();
        }

        private void Find_Ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            //var _data = data as string;
            dom.alert(data);
        }
    }
}
