using System;
using System.IO;
using WallPaperZero.Core;

namespace WallPaperZero.BasicExecuting
{
    class Program
    {
        static void Main(string[] args)
        {
            //loads a dll with a WallPaper (should have an attribute)
            string solidColorWallPaperPath = Path.GetFullPath(@"..\..\..\..\WallPapers\SolidColorsWallPaper\bin\Debug\net5.0\SolidColorsWallPaper.dll");
            string imageWallPaperPath = Path.GetFullPath(@"..\..\..\..\\WallPapers\ImageWallPaper\bin\Debug\net5.0\ImageWallPaper.dll");
            string basicAnimationWallPaperPath = Path.GetFullPath(@"..\..\..\..\WallPapers\BasicAnimationWallPaper\bin\Debug\net5.0\BasicAnimationWallPaper.dll");
            WallPaperLoader.LoadAndRun(solidColorWallPaperPath);
        }
    }
}
