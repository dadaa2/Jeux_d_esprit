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
            Program program = new Program();
            program.ConnexionBaseDeDonnees(); // Appeler la méthode de connexion
            
            Console.WriteLine("Bienvenue dans Jeux d'esprit !");
            Console.WriteLine("Veuillez choisir un jeu :");
            Console.WriteLine("1. Plus ou Moins");
            Console.WriteLine("2. Pendu");
            Console.WriteLine("3. Cesar");
            Console.WriteLine("4. Vigenère");
            Console.Write(">> ");
            int choix = int.Parse(Console.ReadLine());


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
                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
    }
}
