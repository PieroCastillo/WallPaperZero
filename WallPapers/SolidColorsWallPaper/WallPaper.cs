using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using WallPaperZero.Core;

namespace SolidColorsWallPaper
{
    [WallPaper]
    public class SolidColorsWallPaper : WallPaper
    {
        public override void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget)
        {

        }

        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            renderTarget.BeginDraw();
            var r = new RectangleF(new(0, 0), renderTarget.Size);
            renderTarget.FillRectangle(in r, renderTarget.CreateSolidColorBrush(Color.Yellow));
            Console.WriteLine("rendered frame");
            renderTarget.EndDraw();
        }
    }
}
