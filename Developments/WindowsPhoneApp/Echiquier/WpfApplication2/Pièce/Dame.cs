using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Dame : Piece
    {
        public Dame(Coordonnee c, Color w) : base(c, w) { }

        public override int move(int _x, int _y)
        {
            //test d'une position sur diagonale
            if (Math.Abs(this.XY.x - _x) == Math.Abs(this.XY.y - _y))
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }//test d'une position autour d'elle
            else if ((this.XY.x != _x && _y == this.XY.y) ^ (this.XY.x == _x && _y != this.XY.y))
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else
                return Code.Erreur.PIECE_CANT_MOVE;
        }

        public override char letter()
        {
            return 'D';
        }

    }
}
