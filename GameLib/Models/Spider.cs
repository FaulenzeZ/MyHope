using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Models
{
    public class Spider
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Spider(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
