using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Models
{
    public class Axe
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAxeOnMap { get; set; }
        public Axe(int x, int y, bool isAxeOnMap)
        {
            X = x;
            Y = y;
            IsAxeOnMap = isAxeOnMap;
        }
    }
}
