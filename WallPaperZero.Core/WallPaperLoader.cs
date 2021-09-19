using DrawBehindDesktopIcons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Vortice.Direct2D1;

namespace WallPaperZero.Core
{
    public class WallPaperLoader
    {
        static Thread RenderThread;
        static bool ShouldContinue = true;
        public static long DeltaTime
        {
            get;
            private set;
        } = 0;

        public static WallPaperLoadingResult LoadAndRun(string path)
        {
            Console.WriteLine("run method called");

            if (!File.Exists(path))
            {
                Console.WriteLine("the file does not exists");
                return WallPaperLoadingResult.FileDoesNotExists;
            }

            try
            {
                AssemblyName.GetAssemblyName(path);
            }
            catch
            {
                Console.WriteLine("the file is not a valid .Net  assembly");
                return WallPaperLoadingResult.FileIsNotANetAssembly;
            }

            TryGetWallPapersFromAssembly(path, out List<WallPaper> wallpapers);

            if(wallpapers.Count == 0)
            {
                Console.WriteLine("Assembly does not constains any wallPaper");
                return WallPaperLoadingResult.AssemblyDoesNotConstainsAnyWallPaper;
            }


            var desktopPointer = Utils.GetDesktopWorkerPointer();
            var factory = D2D1.D2D1CreateFactory<ID2D1Factory>(FactoryType.MultiThreaded);

            W32.GetClientRect(desktopPointer, out RECT rect);

            HwndRenderTargetProperties wtp = new()
            {
                Hwnd = desktopPointer,
                PixelSize = new Size(rect.Width, rect.Height),
                PresentOptions = PresentOptions.Immediately
            };
            var renderTarget = factory.CreateHwndRenderTarget(new RenderTargetProperties(), wtp);

            wallpapers[0].Load(factory, renderTarget);

            Stopwatch sw = new();
            sw.Start();


            RenderThread = new(new ThreadStart(() =>
            {
                while (ShouldContinue)
                {
                    DeltaTime = sw.ElapsedMilliseconds;
                    Console.WriteLine($"app time: {DeltaTime}");
                    wallpapers[0].Render(renderTarget, DeltaTime);
                    Thread.Sleep(10);

                    if(sw.ElapsedMilliseconds > 1000)
                    {
                        DeltaTime = 0;
                        sw.Restart();
                        Console.WriteLine("time elapsed");
                    }
                }
            }));

            RenderThread.Start();

            return WallPaperLoadingResult.Successfully;
        }

        public static void Stop()
        {
            ShouldContinue = false;
        }

        public static void TryGetWallPapersFromAssembly(string path, out List<WallPaper> wallpapers)
        {
            var assembly = Assembly.LoadFile(path);

            var selectedTypes = from type in assembly.GetTypes()
                                where Attribute.IsDefined(type, typeof(WallPaperAttribute))
                                select type;

            wallpapers = new();

            foreach(var wp in selectedTypes)
            {
                var wpc = (WallPaper)Activator.CreateInstance(wp);
                wallpapers.Add(wpc);
            }
        }
    }

    public enum WallPaperLoadingResult
    {
        Successfully,
        FileIsNotANetAssembly,
        AssemblyDoesNotConstainsAnyWallPaper,
        FileDoesNotExists
    }
}
