using System;

namespace Jeux_d_esprit
{
    public class Jeux
    {
        private string nom;
        private string principeDuJeu;
        private int nombreDeJoueurs;
        private DateTime derniereConnexion;

        // Constructeur
        public Jeux(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
        {
            this.nom = nom;
            this.principeDuJeu = principeDuJeu;
            this.nombreDeJoueurs = nombreDeJoueurs;
            this.derniereConnexion = derniereConnexion;
        }

        // Méthode d'affichage de tous les attributs
        public void affichageInfoJeu()
        {
            Console.WriteLine("Nom du jeu : " + nom);
            Console.WriteLine("Principe du jeu : " + principeDuJeu);
            Console.WriteLine("Nombre de joueurs : " + nombreDeJoueurs);
            Console.WriteLine("Dernière connexion : " + derniereConnexion);
        }
    }
}
