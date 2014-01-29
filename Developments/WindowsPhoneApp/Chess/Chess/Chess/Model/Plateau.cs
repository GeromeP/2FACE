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
                cases[i, 1] = new Case(new Pion(new Coordonnee(i, 1), true));
                cases[i, 6] = new Case(new Pion(new Coordonnee(i, 6), false));
            }

            //initilisation des tours blanches et noires
            cases[0, 0] = new Case(new Tour(new Coordonnee(0,0), true));
            cases[0, 7] = new Case(new Tour(new Coordonnee(0, 7), false));
            cases[7, 0] = new Case(new Tour(new Coordonnee(7, 0), false));
            cases[7, 7] = new Case(new Tour(new Coordonnee(7, 7), false));

            //initilisation des cavaliers
            cases[1, 0] = new Case(new Cavalier(new Coordonnee(1, 0), true));
            cases[6, 0] = new Case(new Cavalier(new Coordonnee(6, 0), true));
            cases[1, 7] = new Case(new Cavalier(new Coordonnee(1, 7), false));
            cases[6, 7] = new Case(new Cavalier(new Coordonnee(6, 7), false));

            //initialisation des foux
            cases[2, 0] = new Case(new Fou(new Coordonnee(2, 0), true));
            cases[5, 0] = new Case(new Fou(new Coordonnee(5, 0), true));
            cases[2, 7] = new Case(new Fou(new Coordonnee(2, 7), false));
            cases[5, 7] = new Case(new Fou(new Coordonnee(5, 7), false));

            //initialisation des Dames
            cases[3, 0] = new Case(new Dame(new Coordonnee(3, 0), true));
            cases[3, 7] = new Case(new Dame(new Coordonnee(7, 7), false));

            //initialisation des Rois
            cases[4, 0] = new Case(new Roi(new Coordonnee(4, 0), true));
            cases[4, 7] = new Case(new Roi(new Coordonnee(4, 7), false));
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
            if (cases[c.x, c.y] != null)
                return true;
            else
                return false;
        }

        /** verirife si une piece est presnete entre l'origine et la fin **/
        private bool isBlock(Coordonnee origine, Coordonnee fin)
        {
            int deltaX = origine.x - fin.x;
            int deltaY = origine.y - fin.y;

            if (deltaX == deltaY)
            {
                int incrementY = deltaY < 0 ? +1 : -1;
                int incrementX = deltaX < 0 ? +1 : -1;
                for (int i = origine.x + 1 ; i < fin.x -1 ;  i += incrementX)
                {
                    for (int j = origine.y + 1 ; j < fin.y -1 ; j += incrementY)
                    {
                        if (cases[i, j] != null)
                            return true; 
                    }
                }
            }
            else if (deltaX == 0)
            {
                int incrementY = deltaY < 0 ? +1 : -1;
                for (int j = origine.y + 1 ; j < fin.y -1 ; j += incrementY)
                {
                    if (cases[origine.x, j] != null)
                        return true;
                }
            }
            else if (deltaY == 0)
            {
                int incrementX = deltaX < 0 ? +1 : -1;
                for (int i = origine.x + 1 ; i < fin.x -1 ; i += incrementX)
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
