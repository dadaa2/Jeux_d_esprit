using System;
using MySql.Data.MySqlClient;

namespace Jeux_d_esprit
{
    public class Joueur
    {
        private int id_joueur;
        private string nom;
        private string mail;
        private string avatar;

        // Constructeur
        public Joueur()
        {
        }

        // Méthode pour vérifier si un joueur existe dans la base de données
        public bool VerifierJoueur(string nom)
        {
            string connectionString = "server=localhost;user=root;database=jeu;password=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM joueur WHERE Nom = @Nom";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nom", nom);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Le joueur existe, récupérer ses informations
                        id_joueur = reader.GetInt32("id_joueur");
                        this.nom = reader.GetString("Nom");
                        mail = reader.GetString("Mail");
                        avatar = reader.GetString("Avatar");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la vérification du joueur : " + ex.Message);
                }
            }
            return false;
        }

        // Méthode pour créer un nouveau joueur dans la base de données
        public void CreerJoueur(string nom, string mail, string avatar)
        {
            string connectionString = "server=localhost;user=root;database=jeu;password=root";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO joueur (Nom, Mail, Avatar) VALUES (@Nom, @Mail, @Avatar)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nom", nom);
                    command.Parameters.AddWithValue("@Mail", mail);
                    command.Parameters.AddWithValue("@Avatar", avatar);
                    command.ExecuteNonQuery();

                    // Récupérer l'id_joueur du nouveau joueur
                    query = "SELECT LAST_INSERT_ID()";
                    command = new MySqlCommand(query, connection);
                    id_joueur = Convert.ToInt32(command.ExecuteScalar());
                    this.nom = nom;
                    this.mail = mail;
                    this.avatar = avatar;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la création du joueur : " + ex.Message);
                }
            }
        }

        // Méthode pour récupérer les informations d'un joueur à partir de son nom
        public Joueur ObtenirJoueur(string nom)
        {
            Joueur joueur = new Joueur();
            if (joueur.VerifierJoueur(nom))
            {
                return joueur;
            }
            return null;
        }
    }
}
