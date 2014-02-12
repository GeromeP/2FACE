using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Pion : Piece
    {
        private bool firstMove = true;

        public Pion(Coordonnee c, Color w) : base(c, w) { }

        public override int move(int _x, int _y)
        {
            if (_y == this.XY.y) 
            {
                int d = _x - this.XY.x;

                if (Color.BLACK == color)
                {
                    d = -d;
                }

                if (firstMove)
                {   //verifie le deplacement en Y pour le premier coup
                    if (d < 3 && d > 0)
                    {
                        this.XY.x = _x;
                        firstMove = false;
                        return Code.Validation.PIECE_CAN_MOVE;
                    }
                }
                else
                {   //verifie le déplacement en Y pour les coups suivant
                    if (d < 2 && d > 0)
                    {
                        this.XY.x = _x;
                        return Code.Validation.PIECE_CAN_MOVE;
                    }
                }
            }   
            
            return Code.Erreur.PIECE_CANT_MOVE;
        }

        public override char letter()
        {
            return 'P';
        }
    }
}
