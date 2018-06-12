﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Library;
using Ajax.Admin;
using Library.Attributes;

namespace Modules.StaffManager.Functions
{
    /// <summary>
    ///  Gán session keyword để phục vụ cho tìm kiếm
    /// </summary>
    public class SetSearchKeyword : Function
    {
        #region "class"

        

        #endregion

        #region "var"

        public SetKeywordForSearch ajax;
        public string keyword;
        #endregion

        public SetSearchKeyword() : base()
        {
            
        }

        [Tested]
        public override void VariablesInit()
        {
            keyword = data.getValueById<string>("Email");
        }

        public override void Execute()
        {
            VariablesInit();
            ajaxRequest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Tested]
        public virtual void ajaxRequest()
        {
            ajax = new SetKeywordForSearch()
            {
                Async = true,
                data = new
                {
                    keyword = keyword
                }.ToDynamic()
            };

            ajax.success = setSearchKeyword_ok;
            ajax.error = setSearchKeyword_error;
            ajax.Request();
        }

        /// <summary>
        ///  Lỗi xảy ra khi gán session keyword
        /// </summary>
        /// <param name="jqXHR"></param>
        /// <param name="textStatus"></param>
        /// <param name="errorThrown"></param>
        private void setSearchKeyword_error(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            dom.alert("Bị lỗi rồi");
        }

        /// <summary>
        ///  Nạp lại grid danh sách nhân viên mỗi khi đã gán session keyword thành công
        /// </summary>
        /// <param name="data"></param>
        /// <param name="textStatus"></param>
        /// <param name="jqXHR"></param>
        /// 
        [Tested]
        private void setSearchKeyword_ok(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            //dom.alert("Ok");
            //var try_dialog = new Library.Browser.Dialog("editOrCreateStaff");
            //System.Threading.Thread.Sleep(3000);
            //try_dialog.HideModalDialog();

            var KendoGrid = this.data.getKendoGrid("grid");

            this.data.kendGridReloadData(KendoGrid);
        }

    }
}
