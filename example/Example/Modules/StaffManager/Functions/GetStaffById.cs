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
    public class GetStaffById : Function
    {
        #region "var"

        public Ajax.Admin.GetStaffById ajax;
        public int Id;
        #endregion

        public GetStaffById(int Id) : base()
        {
            this.Id = Id;
        }

        public override void VariablesInit()
        {

        }

        public override void Execute()
        {
            VariablesInit();
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
                },
            };

            ajax.success = GetStaffById_ok;
            ajax.error = GetStaffById_error;
            ajax.Request();
        }


        private void GetStaffById_error(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            
        }

       
        
        private void GetStaffById_ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
           
        }

    }
}
