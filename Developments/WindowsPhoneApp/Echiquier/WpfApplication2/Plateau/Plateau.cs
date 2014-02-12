using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    class Plateau
    {
        Case[,] cases = new Case[8, 8];

        /** initialise le plateau **/
        public void init()
        {
            //initialisation des pion noirs et blancs
            for (int i = 0; i < 8; i++)
            {
                cases[1, i] = new Case(new Pion(new Coordonnee(1, i), Piece.Color.WHITE));
                cases[6, i] = new Case(new Pion(new Coordonnee(6, i), Piece.Color.BLACK));
            }

            //initilisation des tours blanches et noires
            cases[0, 0] = new Case(new Tour(new Coordonnee(0,0), Piece.Color.WHITE));
            cases[7, 0] = new Case(new Tour(new Coordonnee(7, 0), Piece.Color.BLACK));
            cases[0, 7] = new Case(new Tour(new Coordonnee(0, 7), Piece.Color.WHITE));
            cases[7, 7] = new Case(new Tour(new Coordonnee(7, 7), Piece.Color.BLACK));

            //initilisation des cavaliers
            cases[0, 1] = new Case(new Cavalier(new Coordonnee(0, 1), Piece.Color.WHITE));
            cases[0, 6] = new Case(new Cavalier(new Coordonnee(0, 6), Piece.Color.WHITE));
            cases[7, 1] = new Case(new Cavalier(new Coordonnee(7, 1), Piece.Color.BLACK));
            cases[7, 6] = new Case(new Cavalier(new Coordonnee(7, 6), Piece.Color.BLACK));

            //initialisation des foux
            cases[0, 2] = new Case(new Fou(new Coordonnee(0, 2), Piece.Color.WHITE));
            cases[0, 5] = new Case(new Fou(new Coordonnee(0, 5), Piece.Color.WHITE));
            cases[7, 2] = new Case(new Fou(new Coordonnee(7, 2), Piece.Color.BLACK));
            cases[7, 5] = new Case(new Fou(new Coordonnee(7, 5), Piece.Color.BLACK));

            //initialisation des Dames
            cases[0, 3] = new Case(new Dame(new Coordonnee(0, 3), Piece.Color.WHITE));
            cases[7, 3] = new Case(new Dame(new Coordonnee(7, 3), Piece.Color.BLACK));

            //initialisation des Rois
            cases[0, 4] = new Case(new Roi(new Coordonnee(0, 4), Piece.Color.WHITE));
            cases[7, 4] = new Case(new Roi(new Coordonnee(7, 4), Piece.Color.BLACK));
        }

        /**affiche le plateau d'echecs **/
        public string display()
        {
            string platform = " \t0\t1\t2\t3\t4\t5\t6\t7\n";
            for (int x = 0; x < 8; x++)
            {
                platform += (x + "\t");
                for (int y = 0; y < 8; y++)
                {
                    
                    if (cases[x, y] != null)
                        platform += cases[x, y].Piece.letter() + "\t";
                    else
                        platform += ".\t";
                }
                platform += "\n";
            }
            return platform;
        }

        /** deplace une piece du plateau **/
        public int movePiece(Coordonnee origine, Coordonnee fin)
        {
            if(isBlock(origine, fin))
                return Code.Erreur.PIECE_ACCROSS_MOVE;

            if (cases[origine.x, origine.y].Piece.move(fin.x, fin.y) == Code.Validation.PIECE_CAN_MOVE)
            {
                cases[fin.x, fin.y] = cases[origine.x, origine.y];
                cases[origine.x, origine.y] = null;
                return Code.Validation.PIECE_MOVE;
            }
            else
                return Code.Erreur.PIECE_CANT_MOVE;            
        }

        /** verifie la presence d'une piece sur une case **/
        public bool isBusy(Coordonnee c)
        {
                return cases[c.x, c.y] != null;
        }

        /** verirife si une piece est presente entre l'origine et la fin **/
        private bool isBlock(Coordonnee origine, Coordonnee fin)
        {
            int deltaX = origine.x - fin.x;
            int deltaY = origine.y - fin.y;

            if (Math.Abs(deltaX) == Math.Abs(deltaY))
            {
                int incrementY = deltaY < 0 ? +1 : -1;
                int incrementX = deltaX < 0 ? +1 : -1;
                for (int i = origine.x + 1 ; i <= fin.x -1 ;  i += incrementX)
                {
                    for (int j = origine.y + 1 ; j <= fin.y -1 ; j += incrementY)
                    {
                        if (cases[i, j] != null)
                            return true; 
                    }
                }
            }
            else if (deltaX == 0)
            {
                int incrementY = deltaY < 0 ? +1 : -1;
                for (int j = origine.y + 1 ; j <= fin.y -1 ; j += incrementY)
                {
                    if (cases[origine.x, j] != null)
                        return true;
                }
            }
            else if (deltaY == 0)
            {
                int incrementX = deltaX < 0 ? +1 : -1;
                for (int i = origine.x + 1 ; i <= fin.x -1 ; i += incrementX)
                {
                    if (cases[i, origine.y] != null)
                        return true;
                }
            }
            return false;
        }

        /** retourne la piece presente sur la case**/
        public Piece piece(Coordonnee c)
        {
            Piece p = cases[c.x, c.y].Piece;
            if(p != null)
                return p;
            else 
                return null;
        }
    }
}
