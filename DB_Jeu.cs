using System;
using MySql.Data.MySqlClient;

namespace Jeux_d_esprit
{
    public class DatabaseManager
    {
        private string connectionString;
        private Joueur joueur; // Déclarer une instance de la classe Joueur

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
            this.joueur = new Joueur(); // Initialiser l'instance de Joueur
        }

        public void ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                }
            }
        }

        public MySqlDataReader ExecuteSelectQuery(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                return null;
            }
        }

        public Joueur Joueur // Propriété pour accéder à l'instance de Joueur
        {
            get { return joueur; }
        }
    }
}
