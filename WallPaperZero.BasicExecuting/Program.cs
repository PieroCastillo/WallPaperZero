using System;
using WallPaperZero.Core;

namespace WallPaperZero.BasicExecuting
{
    class Program
    {
        static void Main(string[] args)
        {
            //loads a dll with a WallPaper (should have an attribute)
            WallPaperLoader.LoadAndRun(@"D:\My Projects\WallPaperZero\WallPapers\SolidColorsWallPaper\bin\Debug\net5.0\SolidColorsWallPaper.dll");
        }
    }
}
