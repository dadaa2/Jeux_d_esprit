using System;
using System.Text.RegularExpressions;

namespace Jeux_d_esprit
{
    public class Vigenere : Jeux
    {
        public Vigenere(string nom, string principeDuJeu, int nombreDeJoueurs, DateTime derniereConnexion)
            : base(nom, principeDuJeu, nombreDeJoueurs, derniereConnexion)
        {

        }

        // Méthode pour crypter un message avec le chiffre de Vigenère
        public static string Encrypt(string message, string key)
        {
            string encryptedMessage = "";
            int keyIndex = 0;

            foreach (char letter in message)
            {
                if (char.IsLetter(letter))
                {
                    int shift = char.ToUpper(key[keyIndex]) - 'A';
                    encryptedMessage += ShiftLetter(letter, shift);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    encryptedMessage += letter;
                }
            }

            return encryptedMessage;
        }

        // Méthode pour décrypter un message crypté avec le chiffre de Vigenère
        public static string Decrypt(string encryptedMessage, string key)
        {
            string decryptedMessage = "";
            int keyIndex = 0;

            foreach (char letter in encryptedMessage)
            {
                if (char.IsLetter(letter))
                {
                    int shift = char.ToUpper(key[keyIndex]) - 'A';
                    decryptedMessage += ShiftLetter(letter, -shift);
                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    decryptedMessage += letter;
                }

            }
            return decryptedMessage;
        }

        // Méthode utilitaire pour décaler une lettre dans l'alphabet
        private static char ShiftLetter(char letter, int shift)
        {
            char shiftedLetter = (char)(letter + shift);

            if (char.IsLower(letter))
            {
                if (shiftedLetter > 'z')
                {
                    return (char)(letter + shift - 26);
                }
                else if (shiftedLetter < 'a')
                {
                    return (char)(letter + shift + 26);
                }
            }
            else if (char.IsUpper(letter))
            {
                if (shiftedLetter > 'Z')
                {
                    return (char)(letter + shift - 26);
                }
                else if (shiftedLetter < 'A')
                {
                    return (char)(letter + shift + 26);
                }
            }

            return shiftedLetter;
        }

        // Méthode pour interagir avec l'utilisateur
        public static void Jouer()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans le programme de chiffrement Vigenère !");
            Console.WriteLine("Entrez votre commande (ex: /encrypt \"message\" cle) :");
            Console.WriteLine("Exemple pour crypter : /encrypt \"message\" cle");
            Console.WriteLine("Exemple pour décrypter : /decrypt \"message crypté\" cle");
            Console.Write(">> ");
            string command = Console.ReadLine();

            string pattern = @"\/(encrypt|decrypt)\s+""(.+)""\s+(\w+)";
            Match match = Regex.Match(command, pattern);

            if (match.Success)
            {
                string operation = match.Groups[1].Value;
                string message = match.Groups[2].Value;
                string key = match.Groups[3].Value;

                if (operation.ToLower() == "encrypt")
                {
                    string encryptedMessage = Encrypt(message, key);
                    Console.WriteLine($"Message crypté : {encryptedMessage}");
                }
                else if (operation.ToLower() == "decrypt")
                {
                    string decryptedMessage = Decrypt(message, key);
                    Console.WriteLine($"Message décrypté : {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Opération invalide.");
                }
            }
            else
            {
                Console.WriteLine("Format de commande invalide.");
            }
        }
    }
}
