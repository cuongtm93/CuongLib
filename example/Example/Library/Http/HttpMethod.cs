using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Http
{
    public class HttpMethod
    {
        [InlineConst]
        public const string POST = "POST";

        [InlineConst]
        public const string GET = "GET";

        [InlineConst]
        public const string PUT = "PUT";

        [InlineConst]
        public const string PATCH = "PATCH";

        [InlineConst]
        public const string DELETE = "DELETE";
    }
}
