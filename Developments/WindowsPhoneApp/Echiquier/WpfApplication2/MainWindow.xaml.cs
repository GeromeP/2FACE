using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chess.Resources;
using Chess.Model;

namespace WpfApplication2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Plateau p = new Plateau();
        string position = "";

        public MainWindow()
        {
            p.init();

            InitializeComponent();
            txtPlateau.Text = p.display();
        }

        private void Ok(object sender, RoutedEventArgs e)
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

                 erreur.Text = "piece présente";
                 Piece joueur = p.piece(origine);
                 Coordonnee fin = new Coordonnee(xa, ya);

                 if (p.movePiece(origine, fin) == Chess.Code.Validation.PIECE_MOVE)
                 {
                     txtPlateau.Text = p.display();

                 }
             }
             else
                 erreur.Text = "piece inexistante";

        }
    }
}
