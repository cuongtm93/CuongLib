using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.StaffManager.Functions;
namespace Modules.StaffManager
{
    public class StaffManager_class : Class
    {
        public StaffManager_class()
        {
            SetSearchKeyword_func = new Functions.SetSearchKeyword();
            AddEventHandler_func = new Functions.AddEventHandler();
        }

        public SetSearchKeyword SetSearchKeyword_func;

        public AddEventHandler AddEventHandler_func;
    }
}
