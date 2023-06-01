using System;

namespace CeUAA11_2023_Grootaers
{
    class Program
    {
        static void Main(string[] args)
        {
            sousPro tools = new sousPro();
            string question = "";
            int n;
            string chaine;
            string reponse;
            string phClaire;
            string phClef;
            string[,] matVigenere;
            int a;
            int b;
            string[,] matAffine;

            Console.WriteLine("Quelle phrase voulez-vous crypter ?(Ecris en majuscule !)");
            string phClair = Console.ReadLine();
            tools.RetirEspacesString(phClair, out phClaire);
            Console.WriteLine("Quelle méthode de cryptage voulez-vous utiliser ?Tapez Vigenère/Affine ");
            reponse = Console.ReadLine();
            if (reponse == "Vigenère")
            {
                Console.WriteLine("Quelle clef voulez-vous utiliser pour le cryptage ?");
                phClef = Console.ReadLine();
                tools.CryptVigenere(phClaire, phClef, out matVigenere);
            }
            else if (reponse == "Affine")
            {
                question = "Choisissez un entier dans l'intervalle [0;25]";
                tools.TryParse(question, out b);
                while (b > 25 || b < 0)
                {
                    Console.WriteLine("Respectez la consigne !!");
                    tools.TryParse(question, out b);
                }
                question = "Choisissez un entier dans l'intervalle [0;25] et qui est impair";
                tools.TryParse(question, out a);
                do
                {
                    question = "Pourquoi ne pas juste mettre un entier qui respecte les consignes ?";
                    tools.TryParse(question, out a);
                } while (a < 25 || a > 0);
                tools.CryptAffine(phClaire, a, b, out matAffine);
            }
        }
    }
}
