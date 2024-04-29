using System;
using System.Text.RegularExpressions;
using System.Windows; // Ajout de la référence

namespace Jeux_d_esprit
{
    public class Cesar : Jeux
    {
        // Constructeur
        public Cesar(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
            : base(nom, principeDuJeu, nombreDeJoueurs, derniereConnexion)
        {

        }

        // Méthode pour jouer au jeu du César
        public static void Jouer()
        {
            do
            {
                Console.WriteLine("Entrez votre commande (ex: /encrypt \"terme\" 5) :");
                Console.WriteLine("Autre exemple : /decrypt \"je suis à l'école\" 16 :");
                string commande = Console.ReadLine();
                string pattern = @"\/(encrypt|decrypt)\s+""(.+)""\s*(-?\d+)";
                Match match = Regex.Match(commande, pattern);

                if (match.Success)
                {
                    string operation = match.Groups[1].Value;
                    string terme = match.Groups[2].Value;
                    int decalage = int.Parse(match.Groups[3].Value);

                    string resultat = "";

                    if (operation.ToLower() == "encrypt")
                    {
                        resultat = Encrypt(terme, decalage);
                        Console.WriteLine($"Le terme crypté est : {resultat}");
                    }
                    else if (operation.ToLower() == "decrypt")
                    {
                        resultat = Decrypt(terme, decalage);
                        Console.WriteLine($"Le terme décrypté est : {resultat}");
                    }
                    else
                    {
                        Console.WriteLine("Opération invalide.");
                    }

                    // Copier le résultat dans le presse-papiers
                    //Clipboard.SetText(resultat);
                    //Console.WriteLine("Résultat copié dans le presse-papiers.");

                }
                else
                {
                    Console.WriteLine("Format de commande invalide.");
                }
                Console.Write("\nVoulez-vous crypter/décrypter un terme ? (O/N) : ");
            } while (string.Equals(Console.ReadLine(), "O", StringComparison.OrdinalIgnoreCase));
        }

        // Méthode pour crypter un terme
        private static string Encrypt(string terme, int decalage)
        {
            // Logique de cryptage
            string termeCrypte = "";

            foreach (char caractere in terme)
            {
                if (char.IsLetter(caractere))
                {
                    // Conversion du caractère en majuscule pour simplifier les calculs
                    char caractereMajuscule = char.ToUpper(caractere);
                    // Calcul du décalage dans l'alphabet
                    int decalageAlphabet = (caractereMajuscule - 'A' + decalage) % 26;
                    // Ajout du caractère crypté
                    termeCrypte += (char)('A' + decalageAlphabet);
                }
                else
                {
                    // Conserver les caractères qui ne sont pas des lettres intactes
                    termeCrypte += caractere;
                }
            }

            return termeCrypte;
        }

        // Méthode pour décrypter un terme
        private static string Decrypt(string terme, int decalage)
        {
            // Logique de décryptage
            string termeDecrypte = "";
            foreach (char caractere in terme)
            {
                if (char.IsLetter(caractere))
                {
                    // Conversion du caractère en majuscule pour simplifier les calculs
                    char caractereMajuscule = char.ToUpper(caractere);
                    // Calcul du décalage dans l'alphabet
                    int decalageAlphabet = (caractereMajuscule - 'A' - decalage + 26) % 26;
                    // Ajout du caractère décrypté
                    termeDecrypte += (char)('A' + decalageAlphabet);
                }
                else
                {
                    // Conserver les caractères qui ne sont pas des lettres intactes
                    termeDecrypte += caractere;
                }
            }

            return termeDecrypte;
        }
    }
}
