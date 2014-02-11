using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Case
    {
        public Piece Piece { get; set; }

        public Case(Piece p)
        {
            Piece = p;
        }
    }
}
