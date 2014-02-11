using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chess.Resources;
using Chess.Model;

namespace Chess
{
    public partial class MainPage : PhoneApplicationPage
    {

        Plateau p = new Plateau();
        string position = "";

        public MainPage()
        {
            p.init();
            
            InitializeComponent();
            txtPlateau.Text = p.display();
        }

        private void move(object sender, RoutedEventArgs e)
        {
            position = saisie.Text;
            if (position.Length < 4 || position.Length > 5)
            {
                erreur.Text = "erreur de saisie";
                return;
            }

            int xo = int.Parse(position.Substring(0, 1));
            int yo = int.Parse(position.Substring(1, 1));
            int xa = int.Parse(position.Substring(2, 1));
            int ya = int.Parse(position.Substring(3, 1));

            Coordonnee origine = new Coordonnee(xo, yo);
            if (p.isBusy(origine))
            {
                Piece joueur = p.piece(origine);
                Coordonnee fin = new Coordonnee(xa, ya);

                if (p.movePiece(origine, fin) == Code.Validation.PIECE_MOVE)
                {

                }
            }
            else
                erreur.Text = "piece inexistante";

        }
    }
}