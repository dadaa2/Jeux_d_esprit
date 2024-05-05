using System;
using System.Diagnostics;

namespace Jeux_d_esprit
{
    public class PlusOuMoins : Jeux
    {
        private TimeSpan Temps_effectué;
        private Stopwatch chronometre;

        public PlusOuMoins(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
            : base(nom, principeDuJeu, nombreDeJoueurs, derniereConnexion)
        {
            chronometre = new Stopwatch();
        }

        private void DebuterChronometre()
        {
            chronometre.Start();
        }

        private void ArreterChronometre()
        {
            chronometre.Stop();
            Temps_effectué = chronometre.Elapsed;
        }

        public static void Jouer()
        {
            PlusOuMoins jeu = new PlusOuMoins("Nom", "Principe", 1, DateTime.Now);

            do
            {
                Console.Clear();
                Random random = new Random();
                int nombreSecret = random.Next(1, 101);
                Console.WriteLine("Bienvenue dans le jeu Plus ou Moins !");
                Console.WriteLine("Devinez le nombre secret entre 1 et 100.");
                jeu.DebuterChronometre();

                int nombreDevine;
                int nombreDeCoups = 0;
                bool trouve = false;

                while (!trouve)
                {
                    // Affichage du temps écoulé
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine($"Temps écoulé : {jeu.chronometre.Elapsed.TotalSeconds} secondes");

                    Console.Write("Entrez votre estimation : ");
                    if (!int.TryParse(Console.ReadLine(), out nombreDevine))
                    {
                        Console.WriteLine("Veuillez entrer un nombre valide.");
                        continue;
                    }

                    nombreDeCoups++;

                    if (nombreDevine == nombreSecret)
                    {
                        trouve = true;
                    }
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
                jeu.ArreterChronometre();
                Console.WriteLine($"Temps effectué : {jeu.Temps_effectué}");
                Console.Write("\nVoulez-vous rejouer à Plus ou Moins ? (O/N) : ");
            } while (string.Equals(Console.ReadLine(), "O", StringComparison.OrdinalIgnoreCase));
        }
    }
}
