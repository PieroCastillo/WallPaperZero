using System;
using System.Diagnostics;
using System.Drawing;
using Vortice.Direct2D1;
using static WallPaperZero.Core.Utils;

namespace WallpaperZero.Core.Direct2DSample
{
    class Program
    {
        static ID2D1Factory Factory;
        static ID2D1HwndRenderTarget RenderTarget;

        static void Main(string[] args)
        {
            Factory = D2D1.D2D1CreateFactory<ID2D1Factory>(FactoryType.MultiThreaded);
            HwndRenderTargetProperties wtp = new()
            {
                Hwnd = GetDesktopWorkerPointer(),
                PixelSize = new(300, 300),
                PresentOptions = PresentOptions.Immediately
            };
            RenderTarget = Factory.CreateHwndRenderTarget(new RenderTargetProperties(), wtp);

            Color color = Color.SkyBlue;
            Color color2 = Color.White;

            double green = 0;
            while (true)
            {
                green = green + 0.0001;
                if(green >= 1)
                {
                    green = 0;
                }
                var phi = Math.Clamp((int)(green * 255),0,255);
                color = Color.FromArgb(100, phi, 130);
                color2 = Color.FromArgb(phi, 140, 200);
                Console.WriteLine($"color : {color}");

                RenderTarget.BeginDraw();
                RenderTarget.Clear(color);
                Ellipse ellipse = new(new PointF(150,150), 60, 100);
                RectangleF rect = new(20, 20, 200, 400);
                RoundedRectangle rr = new(rect, 20, 20);

                //RenderTarget.DrawRectangle(in rect, RenderTarget.CreateSolidColorBrush(Color.SkyBlue));
                //RenderTarget.FillRectangle(in rect, RenderTarget.CreateSolidColorBrush(color2));
                RenderTarget.FillRoundedRectangle(rr, RenderTarget.CreateSolidColorBrush(Color.LightGreen));
                RenderTarget.FillEllipse(ellipse, RenderTarget.CreateSolidColorBrush(color2));
                RenderTarget.EndDraw();
            }
        }
    }
}
