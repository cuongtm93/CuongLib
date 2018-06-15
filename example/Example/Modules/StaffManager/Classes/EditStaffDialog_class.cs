using Kernel;
using Kernel.Browser;
using Model.View;
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
namespace Modules.StaffManager
{

    /// <summary>
    ///  Lớp EditStaffDialog
    /// </summary>
    public class EditStaffDialog_class : Dialog
    {
        public Model.View.StaffManagerModelView model;

        public static string _dialogId = "editOrCreateStaff";
        public static int _Id;
        public EditStaffDialog_class()
        {
            dialogId = _dialogId;
        }
        public virtual void InitDialog()
        {
            SetTitle("Cập nhật thông tin nhân viên");
            SetAction(Consts.dialogActionEdit);
        }
        public override void CreateModalDialog(string CreateddialogId = "")
        {
            InitDialog();

            if (model == null)
                dom.alert("Chưa điền thông tin vào model");

            AddEventHandler();
            base.CreateModalDialog(CreateddialogId);
        }
        public override void FillDialogData()
        {
            setValue(GetChildId("name").Id(), model.Name);
            getElementById<dom.HTMLSelectElement>(GetChildId("position")).value = model.PositionId.ToString();
            setValue(GetChildId("email").Id(), model.Email);
        }

        public virtual void SetAction(string Action)
        {
            GetChild("dialogAction").html(Action);
        }

        public virtual void AddEventHandler()
        {

            Console.WriteLine("Đang thêm các sự kiện - editOrCreateStaff dialog");
            GetChild("dialogAction").on("click", This.Get("dialogAction_onClick"));

            query(dialogId.Id()).on("hidden.bs.modal", This.Get("UnbindEvent"));
        }

        [EventHandler]
        public virtual void UnbindEvent()
        {
            Console.WriteLine("Đang hủy các sự kiện - editOrCreateStaff dialog");
            var dialogAction = query($"{_dialogId}_dialogAction".Id());
            dialogAction.unbind("click");
            query(dialogId.Id()).unbind("hidden.bs.modal");
        }

        [EventHandler]
        public virtual async void dialogAction_onClick()
        {
            Javascript.debugger();
            // this bây giờ là button dialogAction rồi !!! 
            var dialogAction = this.As<dom.HTMLButtonElement>();
            var @this = new EditStaffDialog_class();

            Console.WriteLine("Người dùng ấn Cập nhật - editOrCreateStaff dialog");
            Javascript.debugger();
            var name = @this.getValueById<string>(@this.GetChildId("name"));
            var email = @this.getValueById<string>(@this.GetChildId("email"));
            var positionId = @this.getValueById<int>(@this.GetChildId("position"));
            var confirmed = dom.confirm("Bạn có thưc sự muốn cập nhật ? ");

            if (confirmed)
            {
                var updateSale = new AjaxTask()
                {
                    Async = true,
                    Url = "/Admin/UpdateStaff",
                    Method = HttpMethod.POST,
                    data = new Model.View.StaffManagerModelView
                    {
                        Id = _Id,
                        Email = email,
                        PositionId = positionId,
                        Name = name
                    }.As<dynamic>()
                };
                var result = await updateSale.Execute();
                if (updateSale.requestError)
                    dom.alert("Lỗi ajax");
                else
                {
                    if (result.status == popupNotificationConst.Sucess)
                    {
                        @this.kendGridReloadData(@this.getKendoGrid("grid"));
                        ShowMessage("Cập nhật thành công", popupNotificationConst.Sucess);
                    }
                    else
                    {
                        ShowMessage("Lỗi xảy ra khi cập nhật", popupNotificationConst.Erorr);
                    }
                }
            }
        }
    }
}
