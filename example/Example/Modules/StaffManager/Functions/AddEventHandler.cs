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
        public dom.HTMLButtonElement btnSearchStaff;
        public dom.HTMLButtonElement btnAddStaff;

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
            btnSearchStaff = _data.getElementById<dom.HTMLButtonElement>("btnSearchStaff");
            btnAddStaff = _data.getElementById<dom.HTMLButtonElement>("btnAddStaff");
        }

        [Tested]
        public virtual void SetEventHandler()
        {
            btnSearchStaff.onclick += btnSearch_onClick;
            btnAddStaff.onclick += btnAddStaff_onClick;
        }

        [EventHandler]
        private void btnAddStaff_onClick(dom.MouseEvent ev)
        {
            dom.alert("ok");
        }

        [EventHandler]
        [Tested]
        public virtual void btnSearch_onClick(dom.MouseEvent ev)
        {
            Console.Write("Sự kiện btnSearchStaff Click");
            new Functions.SetSearchKeyword().Execute();
        }
    }
}
