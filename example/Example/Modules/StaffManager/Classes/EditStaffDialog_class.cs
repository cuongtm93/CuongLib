using Kernel;
using Kernel.Browser;
using Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
namespace Modules.StaffManager
{

    /// <summary>
    ///  Lớp EditStaffDialog
    /// </summary>
    public class EditStaffDialog_class : Dialog
    {
        public Model.View.StaffManagerModelView model;
        public EditStaffDialog_class()
        {
            dialogId = "editOrCreateStaff";
        }
        public override void CreateModalDialog(string CreateddialogId = "")
        {
            if (model == null)
                dom.alert("Chưa điền thông tin vào model");

            base.CreateModalDialog(CreateddialogId);
        }
        public override void FillDialogData()
        {
            setValue(GetChildId("name").Id(), model.Name);
            setValue(GetChildId("position").Id(), model.Position);
            setValue(GetChildId("email").Id(), model.Email);
        }

        public virtual void SetAction(string Action)
        {
            GetChild("dialogAction").html(Action);
        }
    }
}
