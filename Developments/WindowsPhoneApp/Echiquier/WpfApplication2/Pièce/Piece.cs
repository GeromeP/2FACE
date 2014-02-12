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
        public Color color {get; set;}

        public enum Color
        {
            WHITE,
            BLACK
        }

        public Piece(Coordonnee c , Color color)
        {
            XY = c;
            this.color = color;
        }

        public bool isWhite()
        {
            return Color.WHITE == this.color;
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
