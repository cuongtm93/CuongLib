﻿using System;
using Library.Dependecies;
using Library;
using Retyped;
using Modules;
using System.Threading.Tasks;
using Bridge.Html5;
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

            var F = F2.As<Library.Function>();

            F.Execute();
        }

        public static async Task FadeOut(HTMLDivElement div)
        {
            double opacity = 1;

            while (opacity > 0)
            {
                div.Style.Opacity = opacity.ToString();
                opacity -= 0.01;
                await Task.Delay(13);
            }

            div.Style.Visibility = Visibility.Hidden;
        }

    }
}