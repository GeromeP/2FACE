using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Cavalier : Piece
    {
        public Cavalier(Coordonnee c, bool w) : base(c, w) { }

        public override int move(int _x, int _y)
        {   //verifie les positionn d'arrive et de depart du cavalier 
            //selon la valeur absolue de la difference des positons
            if (Math.Abs(this.XY.x - _x) == 1 && Math.Abs(this.XY.y - _y) == 2)
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else if (Math.Abs(this.XY.x - _x) == 2 && Math.Abs(this.XY.y - _y) == 1)
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else if (Math.Abs(this.XY.y - _y) == 1 && Math.Abs(this.XY.x - _x) == 2)
            {
                this.XY.x = _x;
                this.XY.y = _y;
                return Code.Validation.PIECE_CAN_MOVE;
            }
            else if (Math.Abs(this.XY.y - _y) == 2 && Math.Abs(this.XY.x - _x) == 1)
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
            return 'C';
        } 
    }
}
