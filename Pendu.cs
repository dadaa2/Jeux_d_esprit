using System;

namespace Jeux_d_esprit
{
    public class Pendu : Jeux
    {
        // Constructeur
        public Pendu(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
            : base(nom, principeDuJeu, nombreDeJoueurs, derniereConnexion)
        {

        }

        // Méthode pour jouer au jeu Pendu
        public static void Jouer()
        {
            do
            {
                // Logique du jeu Pendu
                string[] mots = { "ordinateur", "programmation", "developpement", "algorithmique", "intelligence" };
                Random random = new Random();
                string motSecret = mots[random.Next(0, mots.Length)].ToLower();
                char[] motAffiche = new char[motSecret.Length];

                // Initialiser le mot à deviner avec des tirets
                for (int i = 0; i < motAffiche.Length; i++)
                {
                    motAffiche[i] = '_';
                }

                int coupsRestants = 11;
                bool trouve = false;

                Console.WriteLine("Bienvenue dans le jeu du Pendu !");
                Console.WriteLine("Le mot à deviner contient {0} lettres.", motSecret.Length);

                while (coupsRestants > 0 && !trouve)
                {
                    Console.WriteLine("Mot à deviner : {0}", new string(motAffiche));
                    Console.WriteLine("Il vous reste {0} coups.", coupsRestants);
                    Console.Write("Entrez une lettre : ");

                    char lettre;

                    // Vérification de la saisie de l'utilisateur
                    do
                    {
                        lettre = Console.ReadKey(true).KeyChar;
                    } while (!char.IsLetter(lettre));

                    lettre = char.ToLower(lettre); // Convertir en minuscule

                    bool lettreTrouvee = false;

                    for (int i = 0; i < motSecret.Length; i++)
                    {
                        if (motSecret[i] == lettre)
                        {
                            motAffiche[i] = lettre;
                            lettreTrouvee = true;
                        }
                    }

                    if (!lettreTrouvee)
                    {
                        coupsRestants--;
                    }

                    if (new string(motAffiche) == motSecret)
                    {
                        trouve = true;
                    }
                }

                if (trouve)
                {
                    Console.WriteLine("\nFélicitations ! Vous avez trouvé le mot secret : {0}", motSecret);
                }
                else
                {
                    Console.WriteLine("\nDommage ! Le mot secret était : {0}", motSecret);
                }
                Console.WriteLine("\nVoulez-vous rejouer au Pendu ? (O/N)");
            } while (Console.ReadKey(true).Key == ConsoleKey.O);
        }
    }
}
