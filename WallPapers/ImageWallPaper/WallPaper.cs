using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vortice;
using Vortice.Direct2D1;
using WallPaperZero.Core;

namespace ImageWallPaper
{
    [WallPaper]
    public class ImageWallPaper : WallPaper
    {
        ID2D1Bitmap image;

        public override void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget)
        {
            var imgStream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream("ImageWallPaper.Assets.strelitzia_wallpaper.jpg");
            image = renderTarget.LoadBitmapFromStream(imgStream);
        }

        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            renderTarget.BeginDraw();
            var rect = new RawRectF(0, 0, renderTarget.Size.Width, renderTarget.Size.Height);
            var srcRect = new RectangleF(new(0, 0), image.PixelSize);
            renderTarget.DrawBitmap(image, rect, 1f, BitmapInterpolationMode.NearestNeighbor, srcRect);
            renderTarget.EndDraw();
        }
    }
}
