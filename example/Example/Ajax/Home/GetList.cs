using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using static Retyped.jquery.Literals.Types;

namespace Ajax.Home
{
    public class GetList : Library.Ajax
    {
        public GetList()
        {
            data = new
            {
                name = "abc",
                value = 10,
                bo = true
            }.As<dynamic>();
            data = "abc=5";
            Url = "/home/getlist";
            success = Ok;
            error = err;
            Request();
        }

        private void err(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            throw new NotImplementedException();
        }

        private void Ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var list = data.As<List<WebExample.User>>();


            dom.HTMLTableElement table = new dom.HTMLTableElement()
            {
                id = "tblUser",
                className = "table"
            };
            foreach (var item in list)
            {
                dom.HTMLTableRowElement tr = new dom.HTMLTableRowElement();
                table.appendChild(tr);
                var cid = $"<td>{item.Id}</td>";
                var cname = $"<td>{item.Name}</td>";
                tr.innerHTML = cid + cname;
            }
            dom.alert(jquery.jQuery.select("#tblUser").html());
            dom.document.write(jquery.jQuery.select("#tblUser").html());
        }
    }
}
