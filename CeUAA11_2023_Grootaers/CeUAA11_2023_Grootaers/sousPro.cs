using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA11_2023_Grootaers
{
    class sousPro
    {
        /// <summary>
        /// phClaire et phClef sont non vide, phClef contient moins de caractères que phClaire, phClef contient plus d’une lettre
        /// Créer la matrice de cryptage de la phrase phClaire grâce à la clef phClef avec la méthode de Vigenère
        /// </summary>
        /// <param name="phClaire">phrase à crypter</param>
        /// <param name="phClef">clef de cryptage</param>
        /// <param name="matVigenere">Matrice de cryptage de Vigenère</param>
        public void CryptVigenere(string phClaire, string phClef, out string[,] matVigenere)
        {
            int codeAscii;
            matVigenere = new string[4, phClaire.Length];
            int j = 0;
            for (int i = 0; i <= phClaire.Length - 1; i++)
            {
                matVigenere[0, i] = phClaire[i].ToString();
                if (j == phClef.Length)
                {
                    j = 0;
                }
                matVigenere[1, i] = phClef[j].ToString();
                matVigenere[2, i] = ((int)phClef[j] - 65).ToString();
                if ((int)phClaire[i] + int.Parse(matVigenere[2, i]) <= 90)
                {
                    codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]);
                }
                else
                {
                    codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]) - 26;
                }
                matVigenere[3, i] = Convert.ToChar(codeAscii).ToString();
                j++;
            }
        }
        /// <summary>
        /// a, b, phClaire non vides
        ///b est dans l'intervalle [0;25]
        ///Les seules valeurs pour a sont 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25
        ///Créer la matrice de cryptage de phClaire avec la méthode affine
        /// </summary>
        /// <param name="phClaire">phrase à crypter</param>
        /// <param name="a">1° coefficient du cryptage</param>
        /// <param name="b">2° coefficient du cryptage</param>
        /// <param name="matAffine">matrice de cryptage affine</param>
        public void CryptAffine(string phClaire, int a, int b, out string[,] matAffine)
        {
            matAffine = new string[4, phClaire.Length];
            for (int i = 0; i <= phClaire.Length - 1; i++)
            {
                matAffine[0,i] = phClaire[i].ToString();
                int x = ((int)phClaire[i] - 65);
                matAffine[2, i] = x.ToString();
                int y = (a * x + b) % 26;
                matAffine[2, i] = y.ToString();
                matAffine[3, i] = (y + 65).ToString();
            }
        }
        /// <summary>
        /// nUser est vide et question est non vide
        /// faire une procédure qui permet d'empêcher le crash du programme si l'utilisateur ne repond pas correctement
        /// </summary>
        /// <param name="question">consigne donnée à l'utilisateur</param>
        /// <param name="n">reponse de l'utilisateur en entier</param>
        public void TryParse(string question, out int n)
        {
            string nUser = "";
            Console.WriteLine(question);
            while (!int.TryParse(nUser, out n))
            {
                nUser = Console.ReadLine();
                Console.WriteLine("Ecris un nombre");
            }
        }
        /// <summary>
        /// chaineSSEsp est vide et chaine est non vide
        /// faire un programme qui permet d'enlever les espace d'une chaine de caractere
        /// </summary>
        /// <param name="chaine"> chaine de caractere avec espace</param>
        /// <param name="chaineSSEsp">chaine de caractere sans espace</param>
        public void RetirEspacesString(string chaine, out string chaineSSEsp)
        {
            chaineSSEsp = "";
            int lg = chaine.Length;
            for (int i = 0; i <= lg - 1; i++)
            {
                if (chaine[i] != ' ')
                {
                    chaineSSEsp += chaine[i];
                }
            }
        }

    }
}
