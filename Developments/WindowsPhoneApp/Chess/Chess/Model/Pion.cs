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

        public Pion(Coordonnee c, bool w) : base(c, w) { }

        public override int move(int _x, int _y)
        {
            //verifie si la piece n'as pas bouger en X
            if (_x != this.XY.x)
                return Code.Erreur.PIECE_CANT_MOVE;
            else
            {   //test si c'est son premier coup
                if (firstMove)
                {   //verifie le deplacement en Y pour le premier coup
                    if (_y > this.XY.y + 2)
                        return Code.Erreur.PIECE_CANT_MOVE;
                }
                else
                {   //verifie le déplacement en Y pour les coups suivant
                    if (_y > this.XY.y + 1)
                        return Code.Erreur.PIECE_CANT_MOVE;
                }
                //met a jour la position du pion.
                this.XY.y = _y;
                firstMove = false;
                return Code.Validation.PIECE_CAN_MOVE;
            }
        }

        public override char letter()
        {
            return 'P';
        }
    }
}
