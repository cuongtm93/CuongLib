using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Http
{
    public class HttpMethod
    {
        [InlineConst]
        public const string POST = nameof(POST);

        [InlineConst]
        public const string GET = nameof(GET);

        [InlineConst]
        public const string PUT = nameof(PUT);

        [InlineConst]
        public const string PATCH = nameof(PATCH);

        [InlineConst]
        public const string DELETE = nameof(DELETE);
    }
}
