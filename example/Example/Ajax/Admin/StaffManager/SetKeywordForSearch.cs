using System.Collections.Generic;
using Retyped;
using Library.Http;

namespace Ajax.Admin
{
    public class SetKeywordForSearch : Library.Ajax
    {
        public SetKeywordForSearch()
        {
            Url = "/Admin/SetKeywordForSearch";
            Method = HttpMethod.GET;
        }
    }
}