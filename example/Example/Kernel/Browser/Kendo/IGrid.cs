using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kendo.Grid
{
    interface IGrid
    {

        void refresh();
        void gotoPage(Navigation nav);

    }
}
