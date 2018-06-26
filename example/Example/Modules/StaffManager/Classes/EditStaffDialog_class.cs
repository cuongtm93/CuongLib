using Kernel;
using Kernel.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Modules.StaffManager.Functions;
using Kernel.Attributes;
using Kernel.Http;
using Kernel.Data;
using AdvertisingOnline.AnonymousModel;

namespace Modules.StaffManager
{

    /// <summary>
    ///  Dialog cập nhật thông tin nhân viên, kết thừa dialog AddorEditStaffDialog ( dialog dùng chung )
    /// </summary>
    public class EditStaffDialog : AddorEditStaffDialog
    {

        

        /// <summary>
        ///  Khởi tạo dialog cập nhật thông tin nhân viên
        /// </summary>
        public override void InitDialog()
        {
            SetTitle("Cập nhật thông tin nhân viên");
            SetAction(Functions.Const.AddorEditDialog.dialogActionEdit);

            if (model == null)
                dom.alert("Chưa điền thông tin vào model");
        }

        public override void FillDialogData()
        {
            getElementById<dom.HTMLInputElement>("name").value = model.Name;
            getElementById<dom.HTMLSelectElement>("position").value = model.PositionId.ToString();
            getElementById<dom.HTMLInputElement>("email").value = model.Email;

            // không cho đổi email;
            getElementById<dom.HTMLInputElement>("email").readOnly = true;

            getElementById<dom.HTMLInputElement>("skype").value = model.Skype;
            getElementById<dom.HTMLInputElement>("Email2").value = model.ChiefEmail;
        }

        /// <summary>
        ///  Xử lý sự kiện người dùng ấn vào nút cập nhật
        /// </summary>
        [EventHandler]
        public override async void dialogAction_onClickAsync(dom.MouseEvent evt)
        {
            Console.WriteLine("Người dùng ấn Cập nhật - editOrCreateStaff dialog");
            var confirmed = dom.confirm("Bạn có thưc sự muốn cập nhật ? ");
            GetUserInputs();

            if (confirmed && InputOk())
            {
                var updateSale = new AjaxTask()
                {
                    Async = true,
                    Url = "/Admin/UpdateStaff",
                    Method = HttpMethod.POST,
                    data = new StaffManagerModelView
                    {
                        Id = _Id,
                        Email = edit_email,
                        PositionId = edit_positionid,
                        Name = edit_name,
                        Skype = edit_skype,
                        ChiefEmail = edit_chief_email
                    }.As<dynamic>()
                };

                var result = await updateSale.Execute();
                if (updateSale.requestError)
                    dom.alert("Lỗi ajax");
                else
                {
                    if (result.status == popupNotificationConst.Sucess)
                    {
                        kendGridReloadData(getKendoGrid("grid"));
                        ShowMessage("Cập nhật thành công", popupNotificationConst.Sucess);
                    }
                    else
                    {
                        ShowMessage("Lỗi xảy ra khi cập nhật", popupNotificationConst.Erorr);
                    }
                }
            }
        }
        public override void dialog_close(dom.MouseEvent ev)
        {
            base.dialog_close(ev);
            getElementById<dom.HTMLInputElement>("name").onfocus = null;

        }
        public override bool InputOk()
        {
            return true;
        }
    }
}
