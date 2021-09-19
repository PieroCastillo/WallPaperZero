using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using WallPaperZero.Core;

namespace BasicAnimationWallPaper
{
    [WallPaper]
    public class BasicAnimationWallPaper : WallPaper
    {
        Point center;
        public override void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget)
        {
            center = new Point((int)(renderTarget.Size.Width / 2), (int)renderTarget.Size.Height / 2);
        }

        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            Ellipse ellipse = new Ellipse(center, 100, 100);

            renderTarget.BeginDraw();
            renderTarget.Clear(Color.White);
            renderTarget.CreateLayer().
            renderTarget.FillEllipse(ellipse, renderTarget.CreateSolidColorBrush(Color.LightGreen));
            renderTarget.EndDraw();
        }
    }
}
