using System;
using MySql.Data.MySqlClient;

namespace Jeux_d_esprit
{
    class Program
    {
        public void ConnexionBaseDeDonnees()
        {
            // Chaîne de connexion MySQL
            string connectionString = "server=localhost;user=root;database=jeu;password=root";
            // Créer une connexion MySQL
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Vérifier si la connexion est ouverte
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Connexion à la base de données réussie !");
                    }
                    else
                    {
                        Console.WriteLine("Échec de la connexion à la base de données.");
                    }
                    // Vous pouvez exécuter ici des requêtes SQL ou d'autres opérations sur la base de données
                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion
                    Console.WriteLine("Erreur lors de la connexion à la base de données : " + ex.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            // Authentification du joueur
            Joueur joueur = AuthentifierJoueur();

            if (joueur != null)
            {
                int choix;
                do
                {
                    Console.WriteLine("Bienvenue dans Jeux d'esprit !");
                    Console.WriteLine("Veuillez choisir un jeu :");
                    Console.WriteLine("1. Plus ou Moins");
                    Console.WriteLine("2. Pendu");
                    Console.WriteLine("3. Cesar");
                    Console.WriteLine("4. Vigenère");
                    Console.WriteLine("9. Quitter");
                    Console.Write(">> ");
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
            private static Joueur AuthentifierJoueur()
            {
                Console.Write("Entrez votre nom : ");
                string nomJoueur = Console.ReadLine();

                Joueur joueur = new Joueur();
                if (joueur.VerifierJoueur(nomJoueur))
                {
                    return joueur;
                }
                else
                {
                    Console.Write("Vous n'avez pas de compte inscrit encore");
                    Console.Write("Entrez votre adresse e-mail : ");
                    string mailJoueur = Console.ReadLine();
                    Console.Write("Entrez votre avatar : ");
                    string avatarJoueur = Console.ReadLine();
                    joueur.CreerJoueur(nomJoueur, mailJoueur, avatarJoueur);
                    return joueur;
                }
            }
    }
}

