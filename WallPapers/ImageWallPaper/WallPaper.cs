using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vortice;
using Vortice.Direct2D1;
using Vortice.WIC;
using WallPaperZero.Core;
using BitmapInterpolationMode = Vortice.Direct2D1.BitmapInterpolationMode;
using PixelFormat = Vortice.DCommon.PixelFormat;

namespace ImageWallPaper
{
    [WallPaper]
    public class ImageWallPaper : WallPaper
    {
        ID2D1Bitmap image;
        public override void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget)
        {
            var imgStream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream("ImageWallPaper.Assets.strelitzia_wallpaper.jpg");

            var wicFactory = new IWICImagingFactory();

            var decoder = wicFactory.CreateDecoderFromStream(imgStream);
           
            var frame = decoder.GetFrame(0);

            var formatConv = wicFactory.CreateFormatConverter();

            renderTarget.GetDpi(out float dpiX, out float dpiY);

            Console.WriteLine($"dpiX : {dpiX}");
            Console.WriteLine($"dpiY : {dpiY}");

            formatConv.Initialize(frame, Vortice.WIC.PixelFormat.Format32bppPBGRA, BitmapDitherType.DualSpiral8x8, null, 0f, BitmapPaletteType.Custom);

            var rawImg = wicFactory.CreateBitmapFromSource(formatConv, BitmapCreateCacheOption.CacheOnDemand);

            PixelFormat pixelFormat = new PixelFormat();

            image = renderTarget.CreateBitmapFromWicBitmap(rawImg, new(pixelFormat, 999,999));//renderTarget.Dpi.Width, renderTarget.Dpi.Height));
        }


        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            renderTarget.BeginDraw();
            var rect = new RawRectF(0, 0, renderTarget.Size.Width, renderTarget.Size.Height);
            renderTarget.DrawBitmap(image, rect, 1f, BitmapInterpolationMode.Linear, rect);
            renderTarget.DrawRectangle(in rect, renderTarget.CreateSolidColorBrush(Color.Blue));
            renderTarget.EndDraw();
        }
    }
}
