using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Kernel;
using Ajax.Admin;
using Kernel.Attributes;
using Kernel.Http;
using Model.Common;

namespace Modules.StaffManager.Functions
{
    public class AddEventHandler : Function
    {
        #region "class"

        private Kernel.Browser.Data _data;
        #endregion

        #region "var"


        public SetKeywordForSearchStaff ajax;
        public dom.HTMLButtonElement btnSearchStaff;
        public dom.HTMLButtonElement btnAddStaff;
        public dom.HTMLInputElement txtEmail1;
        public dom.HTMLInputElement txtEmail2;
        #endregion

        public AddEventHandler()
        {
            _data = new Kernel.Browser.Data();
        }
        public override void Execute()
        {
            VariablesInit();

            SetEventHandler();
        }

        [Tested]
        public override void VariablesInit()
        {
            btnSearchStaff = _data.getElementById<dom.HTMLButtonElement>("btnSearchStaff");
            btnAddStaff = _data.getElementById<dom.HTMLButtonElement>("btnAddStaff");
            txtEmail1 = _data.getElementById<dom.HTMLInputElement>("Email1");
            txtEmail2 = _data.getElementById<dom.HTMLInputElement>("Email2");
        }

        [Tested]
        public virtual void SetEventHandler()
        {
            btnSearchStaff.onclick += btnSearch_onClick;
            btnAddStaff.onclick += btnAddStaff_onClick;
            //txtEmail1.onkeypress += setSearchKeyword;
            //txtEmail2.onkeypress += setSearchKeyword;
        }

        /// <summary>
        /// Gán từ khóa tìm kiếm vào session
        /// </summary>
        /// <param name="ev"></param>
        private async void setSearchKeyword(dom.KeyboardEvent ev)
        {
            //Trong hàm async thì từ khóa this vẫn giữ nguyên ý nghĩa.
            string requestUrl = string.Empty;
            dom.HTMLInputElement sourceTextBox = ev.srcElement.As<dom.HTMLInputElement>();


            if (sourceTextBox.value.Length < Const.Search.MinKeywordLength)
                return;

            switch (sourceTextBox.id)
            {
                case Const.StaffManager.txtEmail1Id : case Const.StaffManager.txtEmail2Id :

                    requestUrl = "/Admin/SetKeywordForSearchStaff";
                    break;

                default:
                    return;
            }

            //Chờ người dùng thêm 0.2 giây
            await Task.Delay(200);

            if (ev.type == "keypress" || ev.keyCode == Functions.Const.Keyboard.Enter)
            {
                var SetKeywordFortxtEmailAutoComplete = new AjaxTask()
                {
                    Url = requestUrl,
                    Method = HttpMethod.POST,
                    data = new Search()
                    {
                        Keyword = sourceTextBox.value
                    }.ToDynamic()
                };
                await SetKeywordFortxtEmailAutoComplete.Execute();
            }

        }

        [EventHandler]
        private void btnAddStaff_onClick(dom.MouseEvent ev)
        {
            var addNewStaffDialog = new AddStaffDialog();
            addNewStaffDialog.CreateModalDialog();
        }

        [EventHandler]
        [Tested]
        public virtual void btnSearch_onClick(dom.MouseEvent ev)
        {
            Console.Write("Sự kiện btnSearchStaff Click");
            new Functions.SetSearchKeyword().Execute();
        }
    }
}