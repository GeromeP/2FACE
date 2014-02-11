using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Code
{
    class Erreur
    {
        public static int PLATFORM_PIECE_NOT_FOUND       = 0;
        public static int PLATFORM_CANT_MOVE_IN_THE_CASE = 1;
        public static int PLATFORM_CANT_KILL_YOUR_PIECE = 2;
        public static int PIECE_CANT_MOVE = 3;
        public static int PIECE_ACCROSS_MOVE = 4;
    }

    class Validation
    {
        public static int PIECE_MOVE = -1;
        public static int PIECE_CAN_MOVE = -2;
    }

    class Piece
    {
        public static bool DIE = false;
        public static bool ALIVE = true;
    }
}
