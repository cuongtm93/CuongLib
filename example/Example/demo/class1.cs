using Kernel;
using Kernel.Http;
using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public class class1
    {

        public void test2()
        {
            var add = new Modules.StaffManager.AddStaffDialog();
            add.model = new Model.View.StaffManagerModelView()
            {
                ChiefName = "C",
                DailyId = 1,
                Email = "dev@gmail.com",
                Id = 23,
                Name = "cuong",
                Position = "Chức",
                PositionId = 2,
                Skype = "dev"
            };
            add.CreateModalDialog();
        }
        public void test1()
        {
            dom.document.getElementById("targetbtn").onclick = Targetbtn_clickAsync;
        }

        private static async void Targetbtn_clickAsync(dom.MouseEvent ev)
        {
            // ajax thứ nhất
            var GetTest = new AjaxTask
            {
                Url = "http://localhost:52084/home/TestGet",
                Method = HttpMethod.GET,
                data = new { }.ToDynamic()
            };
            dynamic Test1 = await GetTest.Execute();
            if (!GetTest.requestError)
                dom.document.getElementById("targetbtn").innerHTML += ("get" + Test1.id);

            // ajax thứ 2
            var PostTest = new AjaxTask
            {
                Url = "http://localhost:52084/home/TestPost",
                Method = HttpMethod.POST,
                data = new { }.ToDynamic()
            };
            dynamic Test2 = await PostTest.Execute();


            if (!PostTest.requestError)
                dom.document.getElementById("targetbtn").innerHTML += ("post " + Test2.id);
        }
    }
}
