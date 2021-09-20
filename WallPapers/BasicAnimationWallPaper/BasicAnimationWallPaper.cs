using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;
using Vortice.Mathematics;
using WallPaperZero.Core;
using Color = System.Drawing.Color;

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

        float delta = 0f;
        int omega = 0;

        public override void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {
            Ellipse ellipse = new Ellipse(center, 100, 100);

            renderTarget.BeginDraw();
            renderTarget.Clear(Color.White);

            delta = 0.5f * (1f - MathF.Cos((deltaTime / 100 ) * MathF.PI)) * 100;

            Console.WriteLine($"delta : {delta}");

            renderTarget.Transform = Matrix3x2.CreateTranslation(delta, delta);
            renderTarget.FillEllipse(ellipse, renderTarget.CreateSolidColorBrush(Color.LightGreen));
            renderTarget.EndDraw();
        }
    }
}
