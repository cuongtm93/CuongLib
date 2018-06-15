using Kernel.Attributes;
using Modules.StaffManager.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Retyped;
namespace Modules.StaffManager
{
    /// <summary>
    ///  AddStaffDialog giống EditStaffDialog_class, chỉ khác ở hàm initDialog và dialogAction_onClick
    /// </summary>
    public class AddStaffDialog : EditStaffDialog_class
    {
        public override void InitDialog()
        {
            SetTitle("Thêm nhân viên mới");
            SetAction(Consts.dialogActionAdd);
        }

        [EventHandler]
        public override void dialogAction_onClick()
        {
            dom.alert("đang thêm nhân viên mới");
        }
    }
}
