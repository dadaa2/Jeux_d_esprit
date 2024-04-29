using System;

namespace Jeux_d_esprit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans Jeux d'esprit !");
            Console.WriteLine("Veuillez choisir un jeu :");
            Console.WriteLine("1. Plus ou Moins");
            Console.WriteLine("2. Pendu");
            Console.WriteLine("3. Cesar");
            Console.WriteLine("4. Vigenère");
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
