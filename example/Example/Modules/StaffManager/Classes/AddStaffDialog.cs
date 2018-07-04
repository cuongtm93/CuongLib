using Kernel.Attributes;
using Modules.StaffManager.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Retyped;
using Kernel;
using Kernel.Http;
using AdvertisingOnline.AnonymousModel;
using Kernel.Data;

namespace Modules.StaffManager
{
    /// <summary>
    ///  dialog thêm mới nhân viên, kết thừa dialog AddorEditStaffDialog
    /// </summary>
    public class AddStaffDialog : AddorEditStaffDialog
    {

        /// <summary>
        ///  Khởi tạo dialog thêm mới nhân viên
        /// </summary>
        public override void InitDialog()
        {
            SetTitle("Thêm nhân viên mới");

            // Nút thêm nhân viên
            SetAction(Functions.Const.AddorEditDialog.dialogActionAdd);
        }

        public override void AddEventHandler()
        {
            base.AddEventHandler();
            dom.document.getElementById("name").onfocus = email_onchange;
        }


        public override void UnbindEvent()
        {
            base.UnbindEvent();
            dom.document.getElementById("dialog_closebutton").addEventListener("click", (evt) =>
             {
                 dom.document.getElementById("name").onfocus = null;
             });
        }
        public override void FillDialogData()
        {

            // Không điền dữ liệu vào form
            ResetDialogData();

            // cho điền  email; 
            // xử lý trường hợp trường email bị readonly sau khi cập nhật nhân viên xong
            getElementById<dom.HTMLInputElement>("email").readOnly = false;

        }


        public async void email_onchange(dom.FocusEvent ev)
        {
            dom.document.getElementById("name").addEventListener("onfocusout", (e) =>
            {
                dom.document.getElementById("name").onfocus = null;
            });

            var input_email = getValueById<string>("email");
            if (input_email.Length < 5 || ! input_email.Contains("@")) return;

            var GetUserInfo = new AjaxTask()
            {
                Method = HttpMethod.GET,

                data = new
                {
                    email = input_email

                }.ToDynamic(),

                Url = "/Admin/GetUserInfo"
            };
            await GetUserInfo.Execute();

            if (!GetUserInfo.requestError)
            {
                var userinfo = GetUserInfo.AjaxResult.ToDynamic();
                if (!string.IsNullOrWhiteSpace(userinfo.name))
                    setValue("name", userinfo.name);
            }
        }

        /// <summary>
        ///  Người dùng ấn nút thêm nhân viên
        /// </summary>
        /// <param name="evt"></param>
        [EventHandler]
        public override async void dialogAction_onClickAsync(dom.MouseEvent evt)
        {
            Console.WriteLine("Người dùng ấn Cập nhật - editOrCreateStaff dialog");
            var confirmed = dom.confirm("Bạn có thực sự muốn thêm nhân viên ? ");
            GetUserInputs();

            if (confirmed && InputOk())
            {
                var AddSale = new AjaxTask()
                {
                    Async = true,
                    Url = "/Admin/AddStaff",
                    Method = HttpMethod.POST,
                    data = new StaffManagerModelView
                    {
                        Email = edit_email,
                        PositionId = edit_positionid,
                        Name = edit_name,
                        Skype = edit_skype,
                        ChiefEmail = edit_chief_email
                    }.As<dynamic>()
                };

                var result = await AddSale.Execute();
                if (AddSale.requestError)
                    dom.alert("Lỗi ajax");
                else
                {
                    if (result.status == popupNotificationConst.Sucess)
                    {
                        kendGridReloadData(getKendoGrid("grid"));
                        ShowMessage("Thêm nhân viên thành công", popupNotificationConst.Sucess);
                    }
                    else
                    {
                        ShowMessage("Lỗi xảy ra", popupNotificationConst.Error);
                    }
                }
            }
        }

        

        /// <summary>
        ///  Kiểm tra nhập liệu
        /// </summary>
        /// <returns></returns>
        public override bool InputOk()
        {
            return true;
        }
    }
}
