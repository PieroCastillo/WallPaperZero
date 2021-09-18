using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using Vortice.WIC;
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
            
        }


        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            
        }
    }
}
