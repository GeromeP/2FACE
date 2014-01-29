using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Fou: Piece
    {
        public Fou(Coordonnee c, bool w) : base(c, w) { }

        public override int move(int _x, int _y)
        {   //verifie si les positions d'arrive 
            //sont sur la diagonale de la piece de depart
            if (Math.Abs(this.XY.x - _y) != Math.Abs(this.XY.y - _x))
                return Code.Erreur.PIECE_CANT_MOVE;
            else 
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
        }

        public override char letter()
        {
            return 'F';
        }
    }
}
