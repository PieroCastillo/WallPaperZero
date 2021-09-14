using SkiaSharp;
using System;
using static WallPaperZero.Core.Utils;

namespace WallpaperZero.Core.SkiaSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var surface = SKSurface.Create(new SKImageInfo(300, 300), GetDesktopWorkerPointer());

            var canvas = surface.Canvas;

            using(var paint = new SKPaint())
            {
                paint.Shader = SKShader.CreateColor(SKColors.SkyBlue);
                canvas.DrawPaint(paint);
            };
        }
    }
}
