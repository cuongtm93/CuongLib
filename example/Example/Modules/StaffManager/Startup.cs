using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.StaffManager
{
    public class Startup : Function
    {
        public Startup() : base()
        {

        }

        public override void Execute()
        {
            Console.WriteLine("Module StaffManger đã khởi động");
            var StaffManager_class = new Modules.StaffManager.StaffManager_class();
            StaffManager_class.AddEventHandler_func.Execute();
        }
    }
}
