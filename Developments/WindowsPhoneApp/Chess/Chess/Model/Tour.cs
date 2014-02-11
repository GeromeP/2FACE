using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Tour : Piece
    {
        public Tour(Coordonnee c, bool w) : base(c, w) { }

        public override int move(int _x, int _y)
        {
            if (this.XY.x != _x && _y == this.XY.y)
            {
                this.XY.x = _x;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else if (this.XY.y != _y && this.XY.x == _x)
            {
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else
            {
                return Code.Erreur.PIECE_CANT_MOVE;
            }
        }

        public override char letter()
        {
            return 'T';
        }
    }
}
