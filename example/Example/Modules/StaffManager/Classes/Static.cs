using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel;
using Kernel.Http;
using Model.Common;
using Kernel.Browser;
using Kendo.Grid;
using static Retyped.jquery;
using static Retyped.dom;
namespace Static
{
    class StaffManager : Helper
    {
        
        /// <summary>
        ///  Xóa nhân viên khỏi danh sách nhân viên.
        /// </summary>
        /// <param name="StaffId"> Mã nhân viên </param>
        /// <returns></returns>
        private  static async Task<bool> DeleteStaff(int StaffId)
        {
            var delete = new AjaxTask()
            {
                Async = true,
                Method = HttpMethod.DELETE,
                Url = "/Admin/DeleteStaff",
                data = new Identifier()
                {
                    Id = StaffId
                }.As<dynamic>()
            };
            

            await delete.Execute();

            if (delete.requestError)
                return false;

            var delete_result = delete.AjaxResult.As<AjaxResult>();

            return (delete_result.status == AjaxStatus.success);
        }

        /// <summary>
        ///  Người dùng nhấn nút xóa nhân viên
        /// </summary>
        /// <param name="StaffId"></param>
        public static async void AdminDeleteStaff(int StaffId)
        {
            var confirmed = confirm("Bạn có thực sự muốn xóa nhân viên này ?");

            if (!confirmed)
                return;

            bool deleted = await DeleteStaff(StaffId);
            if (deleted)
            {
                ShowMessage("Xóa nhân viên thành công", AjaxStatus.success);
                var grid = new KendoGrid("grid");
                grid.refresh();

                //grid.gotoPage(new Navigation()
                //{
                //    page = 1,
                //    pageSize = 20
                //});
            }
        }
    }
}
