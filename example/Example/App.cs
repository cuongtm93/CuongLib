using System;
using Library.Dependecies;
namespace Example
{
    public class App
    {

        public static void Main()
        {
            var F1 = new EnsureLibrariesInstalledCorrectly_func();
            var F2 = new DI();
            var F = F2.As<Library.Function>();

            F.Execute();
        }
    }
}