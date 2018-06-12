using System.Collections.Generic;
using Retyped;
using Library.Http;
using Model.Common;

namespace Ajax.Admin
{
    
    public class GetStaffById : Library.Ajax
    {

        // Định nghĩa lại kiểu dữ liệu cho ajax GetStaffById ;
        //public new Identifier data;
        public GetStaffById()
        {
            Url = "/Admin/GetStaffById";
            Method = HttpMethod.GET;
        }
    }
}