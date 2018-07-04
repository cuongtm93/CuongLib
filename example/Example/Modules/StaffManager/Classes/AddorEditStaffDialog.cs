using Kernel;
using Kernel.Browser;
using AdvertisingOnline.AnonymousModel;
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
using Modules.StaffManager.Functions.Const;
using static Retyped.dom;
namespace Modules.StaffManager
{
    public class AddorEditStaffDialog : Dialog
    {

        public string edit_name;
        public string edit_email;
        public int edit_positionid;
        public string edit_skype;
        public string edit_chief_email;


        public StaffManagerModelView model;

        public static string _dialogId = "editOrCreateStaff";
        public static int _Id;
        public AddorEditStaffDialog()
        {
            dialogId = _dialogId;
        }


        /// <summary>
        ///  Hàm khởi tạo dialog
        /// </summary>
        public virtual void InitDialog()
        {
            SetTitle("Cập nhật thông tin nhân viên");
            SetAction(AddorEditDialog.dialogActionEdit);
        }

        /// <summary>
        /// Hiển thị dialog
        /// </summary>
        /// <param name="CreateddialogId"></param>
        public override void CreateModalDialog(string CreateddialogId = "")
        {
            InitDialog();
            AddEventHandler();
            base.CreateModalDialog(CreateddialogId);
        }

       
        /// <summary>
        ///  Điền thông tin lên dialog
        /// </summary>
        public override void FillDialogData()
        {
            
        }


        /// <summary>
        ///  Gán Tiêu đề cho nút bấm trên dialog
        /// </summary>
        /// <param name="Action"> Tiêu đề của nút bấm </param>
        public virtual void SetAction(string Action)
        {
            document.getElementById("dialogAction").innerHTML=(Action);
        }

        /// <summary>
        ///  Khởi tạo các hàm bắt sự kiện trên dialog
        /// </summary>
        public virtual void AddEventHandler()
        {

            System.Console.WriteLine("Đang thêm các sự kiện - editOrCreateStaff dialog");
            document.getElementById("dialogAction").onclick =dialogAction_onClickAsync;
            document.getElementById("dialog_closebutton").onclick = dialog_close;

            document.getElementById("dialog_closebutton2").onclick = dialog_close;

        }
        public virtual void dialog_close(MouseEvent ev)
        {
            UnbindEvent();
            ResetDialogData();
        }
        /// <summary>
        ///  hàm xử lý sự kiện khi ấn vào nút có child Id là dialogAction
        /// </summary>
        [EventHandler]
        public virtual async void dialogAction_onClickAsync(MouseEvent ev)
        {

        }
               
        /// <summary>
        ///  Hủy các hàm băt sự kiện trên dialog
        /// </summary>
        public virtual void UnbindEvent()
        {
            System.Console.WriteLine("Đang hủy các sự kiện - editOrCreateStaff dialog");
            var dialogAction = query($"{_dialogId}_dialogAction".Id());
            document.getElementById("dialog_closebutton").onclick = null;
            document.getElementById("dialogAction").onclick = null;
            document.getElementById("name").onfocus = null;
            dialogAction.unbind("click");
            query(dialogId.Id()).unbind("hidden.bs.modal");
        }

        public virtual void GetUserInputs()
        {
            edit_name = getValueById<string>("name");
            edit_email = getValueById<string>("email");
            edit_positionid = getValueById<int>("position");
            edit_skype = getValueById<string>("skype");
            edit_chief_email = getValueById<string>("Email2");
        }
        /// <summary>
        ///  Kiểm tra input
        /// </summary>
        /// <returns></returns>
        public virtual bool InputOk()
        {
            return true;
        }

        public virtual void ResetDialogData()
        {
            model = new StaffManagerModelView(); // xóa toàn bộ thông tin trong model

            getElementById<HTMLInputElement>("name").value = model.Name;
            getElementById<HTMLSelectElement>("position").value = model.PositionId.ToString();
            getElementById<HTMLInputElement>("email").value = model.Email;
            getElementById<HTMLInputElement>("skype").value = model.Skype;
            getElementById<HTMLInputElement>("Email2").value = model.ChiefEmail;
        }
    }
}
