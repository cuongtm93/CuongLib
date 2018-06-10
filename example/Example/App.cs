using Bridge;
using Newtonsoft.Json;
using System;
using Retyped;
using Library;
using Bridge.jQuery2;
using static Retyped.jquery.Literals.Types;
using static Retyped.jquery.JQuery;

namespace Example
{
    public class App
    {

        public static void Main()
        {
            var x = new Modules.Module1.Class1();
            x.ClassOwnerFunction();

            //var f = new Ajax.Home.Find();
            //var tags = jquery.jQuery.parseHTML("<p>content</p>dfhfgh");
            //foreach (var item in tags)
            //{
            //    if (item.Value.Is<dom.HTMLParagraphElement>())
            //    {
            //        var p = item.Value.ToDynamic() as dom.HTMLParagraphElement;
            //        dom.alert(p.innerText);
            //    }
            //    else
            //    {
            //        dom.alert("F");
            //    }
            //}
            //var date = new DatePicker();
            //date.getFullWidth();
            //date.ReadOnly();
            //dynamic btns = Retyped.jquery.jQuery.select(".btnform");
            //btns.kendoButton();
            //foreach (dom.HTMLButtonElement btn in btns)
            //{
            //    var loadingIcon = new dom.HTMLSpanElement()
            //    {
            //        className = "glyphicon glyphicon-refresh glyphicon-refresh-animate",
            //    };
            //    string loading = " Loading";
            //    btn.onclick = (e) =>
            //    {
            //        var a = new Ajax.Admin.BankingTransaction().GetUser();
            //        dom.alert(a.Username);
            //        var evtTagretButton = e.srcElement as dom.HTMLButtonElement;
            //        if (evtTagretButton.innerHTML == loading)
            //        {
            //            return string.Empty;
            //        }
            //        evtTagretButton.setAttribute("old", evtTagretButton.innerText);
            //        evtTagretButton.clearInnerHtml();
            //        evtTagretButton.appendChild(loadingIcon);
            //        loadingIcon.plusText(loading);

            //        evtTagretButton.setAttribute("disabled", "");
            //        var user = new Ajax.Admin.BankingTransaction().GetUser();
            //        dom.alert(user.Username);
            //        evtTagretButton.innerHTML = evtTagretButton.getAttribute("old");
            //        evtTagretButton.setAttribute("disabled", "");
            //        return string.Empty;
            //    };

            //}
        }


    }
}