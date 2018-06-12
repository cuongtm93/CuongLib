using System;
using Library.Dependecies;
using Library;
using Retyped;
using Modules;
namespace Esms
{
    public class App
    {

        public static void Main()
        {

        }

        public static void TestFunc()
        {
            var F1 = new EnsureLibrariesInstalledCorrectly_func();
            var F2 = new DI();

            var F = F2.As<Function>();

            F.Execute();
        }
    }
}