﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Roi : Piece
    {
        public Roi(Coordonnee c, Color w) : base(c, w) { }

        public override int move(int _x, int _y)
        {   //verifie si la piece ne se deplace pas plus d'une case autour d'elle.
            if (Math.Abs(this.XY.x - _x) == 1 && Math.Abs(this.XY.y - _y) == 1 || Math.Abs(this.XY.x - _x) == 1 && Math.Abs(this.XY.y - _y) == 0 || Math.Abs(this.XY.x - _x) == 0 && Math.Abs(this.XY.y - _y) == 1)
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
            return 'R';
        }
    }
}
