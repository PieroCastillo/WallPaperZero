using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vortice.Direct2D1;

namespace WallPaperZero.Core.Components
{
    public class Component
    {
        public Component()
        {

        }

        public virtual void Load(ID2D1Factory factory, ID2D1HwndRenderTarget renderTarget)
        {

        }

        public virtual void Render(ID2D1HwndRenderTarget renderTarget, long deltaTime)
        {

        }
    }
}
