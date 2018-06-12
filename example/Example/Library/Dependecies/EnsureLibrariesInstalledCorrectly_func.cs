using System;
using System.Collections.Generic;
using Bridge;
using Newtonsoft.Json;

namespace Library.Dependecies
{
    class EnsureLibrariesInstalledCorrectly_func : Library.Function
    {
        public List<string> dependencies;
        public EnsureLibrariesInstalledCorrectly_func() : base()
        {
            PrepareDependenciesList();
        }
        public virtual void PrepareDependenciesList()
        {
            dependencies = new List<string>{
                "jquery.jQuery"
            };
        }

        public virtual void Success(string lib)
        {
            Console.WriteLine($"- <p style='color:green;'> {lib} đã ok </p>");
        }
        public virtual void Error(string lib)
        {
            Console.WriteLine($" <p style='color:red;'>Chưa thêm thư viện {lib} vào dự án</p>");
        }
        public virtual Action<string> CheckifLibraryInstalled(string lib)
        {
            try
            {
                Script.Write("debugger;");
                var x = Script.Get(lib).As<object>();
                var k = x.IsPrototypeOf(Retyped.Primitive.Undefined.Value);
                return new Action<string>(Success);
            }
            catch
            {
                return new Action<string>(Error);
            }
        }
        public override void Execute()
        {
            foreach (var lib in dependencies)
            {
                Console.Write($"Kiểm tra thư viện {lib} tồn tại?");
                CheckifLibraryInstalled(lib)(lib);
            }
        }
    }
}
