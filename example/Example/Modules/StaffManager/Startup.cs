using Kernel;
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
            try
            {
                var StaffManager_class = new StaffManager_class();
                StaffManager_class.AddEventHandler_func.Execute();
                Console.WriteLine("Module StaffManger đã khởi động");
            }
            catch
            {
                Console.Write("Lỗi xảy ra khi khởi động StaffManager");
            }
            
        }
    }
}
