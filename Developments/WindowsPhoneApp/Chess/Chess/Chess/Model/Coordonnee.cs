using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Coordonnee
    {
        public int x { get; set; }
        public int y { get; set; }

        public Coordonnee(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public string toString()
        {
            return "(" + this.x + ", " + this.y + ")";
        }
    }
}
