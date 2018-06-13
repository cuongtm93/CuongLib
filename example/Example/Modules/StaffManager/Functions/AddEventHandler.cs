using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Kernel;
using Ajax.Admin;
using Kernel.Attributes;

namespace Modules.StaffManager.Functions
{
    public class AddEventHandler : Function
    {
        #region "class"

        private Kernel.Browser.Data _data;
        #endregion

        #region "var"

       
        public SetKeywordForSearch ajax;
        public dom.HTMLButtonElement btnSearch;

        #endregion

        public AddEventHandler()
        {
            _data = new Kernel.Browser.Data();
        }
        public override void Execute()
        {
            VariablesInit();

            SetEventHandler();
        }

        [Tested]
        public override void VariablesInit()
        {
            btnSearch = _data.getElementById<dom.HTMLButtonElement>("btnSearch");
        }

        [Tested]
        public virtual void SetEventHandler()
        {
            btnSearch.onclick += btnSearchOnClick;
        }


        [Tested]
        public virtual void btnSearchOnClick(dom.MouseEvent ev)
        {
            Console.Write("Sự kiện btnSearch Click");
            new Functions.SetSearchKeyword().Execute();
        }
    }
}
