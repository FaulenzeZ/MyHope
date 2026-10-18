using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Models
{
    public class Axe : Entity
    {
        public bool IsAxeOnMap { get; set; }
        public Axe(int x, int y) : base(x, y)
        {
            IsAxeOnMap = true;
        }
    }
}
