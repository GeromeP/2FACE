using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    abstract class Piece
    {
        /**
         * Classe mère des pieces d'échecs
         **/
        public Coordonnee XY { get; set; }
        public bool white {get; set;}

        public Piece(Coordonnee c , bool w)
        {
            XY = c;
            white = w;
        }

        public Piece() { }

        public override string ToString()
        {
            return "Je suis " + this.GetType() + " a la position :" + this.XY.toString();
        }

        public abstract int move(int _x, int _y);
        public abstract char letter();   
    }
}
