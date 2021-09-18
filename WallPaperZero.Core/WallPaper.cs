using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;

namespace WallPaperZero.Core
{
    public abstract class WallPaper
    {
        public abstract void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget);
        public abstract void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime);
    }
}
