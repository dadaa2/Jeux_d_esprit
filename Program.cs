using System;
using MySql.Data.MySqlClient;

namespace Jeux_d_esprit
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager dbManager = new DatabaseManager(); // Pas besoin de passer de chaîne de connexion ici

            // Authentifier le joueur et récupérer le joueur
            Joueur joueur = dbManager.AuthentifierJoueur();

            if (joueur != null)
            {
                int choix;
                do
                {
                    AfficherMenu();
                    choix = int.Parse(Console.ReadLine());
                
                    switch (choix)
                    {
                        case 1:
                            PlusOuMoins.Jouer();
                            break;
                        case 2:
                            Pendu.Jouer();
                            break;
                        case 3:
                            Cesar.Jouer();
                            break;
                        case 4:
                            Vigenere.Jouer();
                            break;
                        case 9:
                            Console.WriteLine("Merci d'avoir joué ! Au revoir !");
                            break;
                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                } while (choix != 9);
            }
            else
            {
                Console.WriteLine("Impossible de se connecter. Veuillez réessayer.");
            }
        }
        static void AfficherMenu()
        {
            Console.WriteLine("Bienvenue dans Jeux d'esprit !");
            Console.WriteLine("Veuillez choisir un jeu :");
            Console.WriteLine("1. Plus ou Moins");
            Console.WriteLine("2. Pendu");
            Console.WriteLine("3. Cesar");
            Console.WriteLine("4. Vigenère");
            Console.WriteLine("9. Quitter");
            Console.Write(">> ");
        }
    }
}
