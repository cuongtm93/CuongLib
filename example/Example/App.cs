using System;
using Kernel.Dependecies;
using Kernel;
using Retyped;
using Modules;
using System.Threading.Tasks;
using Bridge.Html5;
using Bridge;
using Kernel.Http;
using Bridge.jQuery2;

namespace Esms
{
    public class App
    {

        /// <summary>
        ///  Set Main Method to be automatically called when all the JavaScript has been loaded and 
        ///  the Page is ready. If jQuery has been included in the Page, 
        ///  the jQuery ready handler is called, otherwise DOMContentLoaded is used.
        /// </summary>
        [Ready]
        public static void Main()
        {
            dom.document.getElementById("targetbtn").onclick += targetbtn_click;
        }
        private async static void targetbtn_click(dom.MouseEvent ev)
        {
            dom.alert("Chajy");
            var t = new AjaxTask();
            t.Url = "http://localhost:52084/home/TestGet";
            t.Method = HttpMethod.GET;
            t.data = new { }.ToDynamic();
            await t.GetResult();
            var message = t.AjaxResult.As<dynamic>();
            dom.alert(message.id);
        }
      
    }
}