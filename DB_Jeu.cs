using System;
using MySql.Data.MySqlClient;

namespace Jeux_d_esprit
{
    public class DatabaseManager
    {
        private string connectionString = "server=localhost;user=root;database=jeu;password=root";

        public Joueur AuthentifierJoueur()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Tente d'ouvrir la connexion
                    connection.Open();
                    Console.WriteLine("Connexion à la base de données réussie !");

                    // Demande au joueur de saisir son nom
                    Console.Write("Entrez votre nom : ");
                    string nomJoueur = Console.ReadLine();

                    // Vérifie si le joueur existe dans la base de données
                    string query = $"SELECT * FROM Joueur WHERE Nom = '{nomJoueur}'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Le joueur '{nomJoueur}' existe dans la base de données.");
                            // Ici vous pouvez récupérer les informations du joueur et les stocker dans un objet Joueur
                            return new Joueur(); // Retourne un joueur fictif pour le moment
                        }
                        else
                        {
                            Console.WriteLine($"Le joueur '{nomJoueur}' n'existe pas dans la base de données.");
                            reader.Close();

                            // Demande au joueur de s'inscrire
                            Console.Write("Entrez votre adresse e-mail : ");
                            string mailJoueur = Console.ReadLine();
                            Console.Write("Entrez votre avatar : ");
                            string avatarJoueur = Console.ReadLine();

                            // Insère le nouveau joueur dans la base de données
                            string insertQuery = $"INSERT INTO Joueur (Nom, Mail, Avatar) VALUES ('{nomJoueur}', '{mailJoueur}', '{avatarJoueur}')";
                            using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                            {
                                insertCommand.ExecuteNonQuery();
                                Console.WriteLine("Inscription réussie !");
                                // Retourne un objet Joueur avec les informations nouvellement saisies
                                return new Joueur(); // Retourne un joueur fictif pour le moment
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la connexion à la base de données : " + ex.Message);
                return null;
            }
        }
    }
}


