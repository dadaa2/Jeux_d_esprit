using System;

namespace Jeux_d_esprit
{
    public class PlusOuMoins : Jeux
    {
        // Constructeur
        public PlusOuMoins(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
            : base(nom, principeDuJeu, nombreDeJoueurs, derniereConnexion)
        {

        }

        // Méthode pour jouer au jeu Plus ou Moins
        public static void Jouer()
        {
            do
            {
                // Génération d'un nombre aléatoire entre 1 et 100 inclus
                Random random = new Random();
                int nombreSecret = random.Next(1, 101);

                Console.WriteLine("Bienvenue dans le jeu Plus ou Moins !");
                Console.WriteLine("Devinez le nombre secret entre 1 et 100.");

                int nombreDevine;
                int nombreDeCoups = 0;
                bool trouve = false;

                while (!trouve)
                {
                    Console.Write("Entrez votre estimation : ");
                    Console.Write(">> ");


                    // Vérification de la saisie de l'utilisateur
                    if (!int.TryParse(Console.ReadLine(), out nombreDevine))
                    {
                        Console.WriteLine("Veuillez entrer un nombre valide.");
                        continue;
                    }

                    // Incrémenter le nombre de coups
                    nombreDeCoups++;

                    // Vérifier si le nombre deviné est égal au nombre secret
                    if (nombreDevine == nombreSecret)
                    {
                        trouve = true;
                    }
                    // Sinon, donner un indice à l'utilisateur
                    else if (nombreDevine < nombreSecret)
                    {
                        Console.WriteLine("Le nombre secret est plus grand.");
                    }
                    else
                    {
                        Console.WriteLine("Le nombre secret est plus petit.");
                    }
                }

                Console.WriteLine($"Bravo ! Vous avez trouvé le nombre secret en {nombreDeCoups} coups.");
                Console.Write("\nVoulez-vous rejouer à Plus ou Moins ? (O/N) : ");
            } while (string.Equals(Console.ReadLine(), "O", StringComparison.OrdinalIgnoreCase));
        }
    }
}
