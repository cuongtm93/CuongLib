using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Library;
using Ajax.Admin;
namespace Modules.StaffManager.Functions
{
    public class AddEventHandler : Function
    {
        #region "class"

        //private StaffManager_class _class = new StaffManager_class();
        private Library.Browser.Data _data = new Library.Browser.Data();
        #endregion

        #region "var"

       
        public SetKeywordForSearch ajax;
        public dom.HTMLButtonElement btnSearch;

        #endregion

        public override void Execute()
        {
            base.Execute();

            SetEventHandler();
        }
        public override void VariablesInit()
        {
            btnSearch = _data.getElementById<dom.HTMLButtonElement>("btnSearch");
        }
        public virtual void SetEventHandler()
        {
            btnSearch.onclick += btnSearchOnClick;
        }

        public virtual void btnSearchOnClick(dom.MouseEvent ev)
        {
            //_class.SetSearchKeyword_func.Execute();
            Console.Write("Sự kiện btnSearch Click");
            new Functions.SetSearchKeyword().Execute();
        }
    }
}
