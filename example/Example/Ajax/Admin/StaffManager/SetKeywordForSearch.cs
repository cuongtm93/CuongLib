using System.Collections.Generic;
using Retyped;
using Kernel.Http;

namespace Ajax.Admin
{
    public class SetKeywordForSearchStaff : Kernel.Ajax
    {
        public SetKeywordForSearchStaff()
        {
            Url = "/Admin/SetKeywordForSearchStaff";
        }
    }
}