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
            btnClickEvent();
            //jQuery.Ajax(new AjaxOptions()
            //{
            //    Url = "/home/testget",
            //    Cache = false,
            //    Success = delegate (object data, string str, jqXHR jqXHR)
            //    {
            //        dom.alert("PL");
            //    }
            //});
        }
        public static void btnClickEvent()
        {
            var getu = new Kernel.Ajax();
            getu.Async = true;

            getu.Method = HttpMethod.POST;
            getu.Url = "/home/testpost";
            getu.data = new Model.View.User()
            {
                Id = 3,
                Name = "ab"
            }.ToDynamic();
            getu.success = _s;
            getu.error = _e;
            getu.Request();
        }

        private static void _e(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            Javascript.debugger();
            //dom.alert("e");
        }

        private static void _s(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {

            dom.alert(data.ToDynamic().id);
        }

        public static void TestFunc()
        {
            var F1 = new EnsureLibrariesInstalledCorrectly_func();
            var F2 = new DI();

            var F = F2.As<Kernel.Function>();

            F.Execute();
        }

        public static async Task FadeOut(HTMLDivElement div)
        {
            double opacity = 1;

            while (opacity > 0)
            {
                div.Style.Opacity = opacity.ToString();
                opacity -= 0.01;
                await Task.Delay(13);
            }

            div.Style.Visibility = Visibility.Hidden;
        }

    }
}