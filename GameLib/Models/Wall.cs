using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Models
{
    public class Wall
    {
        public int StartX { get; private set; }
        public int StartY { get; private set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public Wall(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }
    }
}
