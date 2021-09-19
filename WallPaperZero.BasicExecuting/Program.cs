using System;
using WallPaperZero.Core;

namespace WallPaperZero.BasicExecuting
{
    class Program
    {
        static void Main(string[] args)
        {
            //loads a dll with a WallPaper (should have an attribute)

            string solidColorWallPaperPath = @"D:\My Projects\WallPaperZero\WallPapers\SolidColorsWallPaper\bin\Debug\net5.0\SolidColorsWallPaper.dll";
            string imageWallPaperPath = @"D:\My Projects\WallPaperZero\WallPapers\ImageWallPaper\bin\Debug\net5.0\ImageWallPaper.dll";
            WallPaperLoader.LoadAndRun(imageWallPaperPath);
        }
    }
}
