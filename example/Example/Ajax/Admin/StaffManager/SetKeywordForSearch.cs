using System.Collections.Generic;
using Retyped;
using Kernel.Http;

namespace Ajax.Admin
{
    public class SetKeywordForSearch : Kernel.Ajax
    {
        public SetKeywordForSearch()
        {
            Url = "/Admin/SetKeywordForSearch";
            Method = HttpMethod.GET;
        }
    }
}