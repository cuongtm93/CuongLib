using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Library;
using Ajax.Admin;
using Library.Attributes;
using Model.Common;

namespace Modules.StaffManager.Functions
{
    /// <summary>
    ///  Lấy thông tin nhân viên dựa vào Id
    ///  Gán vào dialog để hiển thị
    /// </summary>
    public class ShowDialogEditStaffById : Function
    {
        #region "var"

        public Ajax.Admin.GetStaffById ajax;
        public int Id;
        #endregion

        public ShowDialogEditStaffById(int Id) : base()
        {
            this.Id = Id;
        }

        public override void Execute()
        {
               ajaxRequest();
        }

        public virtual void ajaxRequest()
        {
            ajax = new Ajax.Admin.GetStaffById()
            {
                Async = true,
                data = new Identifier()
                {
                    Id = Id
                }.ToDynamic(),
            };

            ajax.success = data_ok;
            ajax.error = data_eror;
            ajax.Request();
        }


        private void data_eror(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {

        }

        private void data_ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            var model = data.As<Model.View.StaffManagerModelView>();
            var editDialog = new EditStaffDialog_class();
            editDialog.model = model;
            editDialog.SetTitle("Cập nhật thông tin nhân viên");
            editDialog.SetAction("Cập nhật");
            editDialog.CreateModalDialog();
        }

    }
}
