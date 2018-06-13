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
            dom.document.getElementById("targetbtn").onclick = targetbtn_clickAsync;
        }

        private static async void targetbtn_clickAsync(dom.MouseEvent ev)
        {
            dynamic messageget, messagepost;


            // ajax thứ nhất
            var GetTest = new AjaxTask
            {
                Url = "http://localhost:52084/home/TestGet",
                Method = HttpMethod.GET,
                data = new { }.ToDynamic()
            };
            await GetTest.GetResult();
            messageget = GetTest.AjaxResult.As<dynamic>();
            dom.document.getElementById("targetbtn").innerHTML += ("get" + messageget.id);


            // ajax thứ 2
            var PostTest = new AjaxTask
            {
                Url = "http://localhost:52084/home/TestPost",
                Method = HttpMethod.POST,
                data = new { }.ToDynamic()
            };
            await PostTest.GetResult();
            messagepost = PostTest.AjaxResult.As<dynamic>();
            dom.document.getElementById("targetbtn").innerHTML += ("post " + messagepost.id);

        }

    }
}