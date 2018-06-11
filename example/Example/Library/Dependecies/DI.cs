using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Dependecies
{
    class DI : EnsureLibrariesInstalledCorrectly_func
    {
        // Thêm một thư viện TestLib2 để kiểm tra
        public override void PrepareDependenciesList()
        {
            base.PrepareDependenciesList();
            dependencies.Add("TestLib2");
        }
        public override void Error(string lib)
        {
            Console.WriteLine($"Kiểu thông báo lỗi thứ 2 : Lỗi " + lib);
        }
        public override void Success(string lib)
        {
            Console.WriteLine($"Ờ chạy được rồi nhé : {lib}");
        }
    }
}
