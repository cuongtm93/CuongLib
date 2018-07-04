using Kernel;
using Kernel.Attributes;
using Kernel.Browser;
using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Retyped.dom;
using static Retyped.jquery;

namespace Kendo.Grid
{
    class KendoGrid : Helper , IGrid
    {
        private dynamic _grid;
        public KendoGrid(string gridId)
        {
            _grid = jQuery.select(gridId.Id()).data("kendoGrid");
        }

       
        /// <summary>
        ///  Đến trang
        /// </summary>
        /// <param name="nav"> Navigation </param>
        public void gotoPage(Navigation nav)
        {
            _grid.dataSource.query(nav);
        }

       
        /// <summary>
        ///  Tải lại grid
        /// </summary>
        [Tested]
        public void refresh()
        {
            _grid.dataSource.read();
        }
    }
}
