using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using Vortice.WIC;

namespace WallPaperZero.Core
{
    public static class D2DUtils
    {
        public static ID2D1Bitmap LoadBitmapFromStream(this ID2D1HwndRenderTarget renderTarget, Stream data)
        {
            var wicFactory = new IWICImagingFactory();

            var decoder = wicFactory.CreateDecoderFromStream(data);

            var frame = decoder.GetFrame(0);

            var formatConv = wicFactory.CreateFormatConverter();

            formatConv.Initialize(frame, PixelFormat.Format32bppPBGRA, BitmapDitherType.None, null, 0f, BitmapPaletteType.Custom);

            var rawImg = wicFactory.CreateBitmapFromSource(formatConv, BitmapCreateCacheOption.CacheOnDemand);

            return renderTarget.CreateBitmapFromWicBitmap(rawImg, null);
        }
    }
}
