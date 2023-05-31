using System;
using System.Threading;
namespace Projet_Quiz;
class Quiz
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        // Animation du titre
        string title = "Bonjour et bienvenue dans notre agence de recrutement !";
        for (int i = 0; i < title.Length; i++)
        {
            Console.Write(title[i]);
            Thread.Sleep(100); // Délai de 100 millisecondes entre chaque caractère
        }
        //affichage de l'énoncé
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nVoici un QUIZ sur le C# qui nous servira à évaluer vos compétences.");
        Console.WriteLine("10 Questions mais ATTENTION ! Une seule réponse est possible par question !");
        Console.WriteLine("Alors appuyer sur la touche ENTRÉE et allons-y !\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();

        //déclaration du tableau des questions
        string[] questions = new string[10] {
            "Quelle est l'année de création du langage C# ?",
            "C# est un...",
            "Quelle est la variable correcte ?",
            "Quelle est l'expression utilisée pour conditionner une instruction ?",
            "Parmi les types de données proposés ci-dessous en langage C#, lesquels permettent de stocker des nombres décimaux ?",
            "Vous souhaitez déclarer une variable capable de contenir le nombre 375 456 756. Quel est le type de données de base le plus approprié ?",
            "Si la valeur de A est FALSE et celle de B est TRUE, quelle sera la valeur de A && B ?",
            "Quel élément du langage C# permet de créer des objets pointant vers un bloc d'instructions ?",
            "Quelle méthode est utilisée pour convertir une chaîne de caractères en un entier en utilisant C# ?",
            "Quelle méthode est utilisée pour arrondir un nombre décimal à l'entier le plus proche en utilisant C# ?",
        };

        //déclaration du tableau des réponses possible
        string[,] answers = new string[10, 4] {
            { "1971", "1981", "1991", "2001" },
            { "Language", "Framework", "Librairie", "CMS" },
            { "string = 3;", "int = x = \"3\";", "string = '3';", "int x = 3;" },
            { "(x == true);", "x == true;", "x &= true;", "x =< true;" },
            { "Float", "Long", "Int", "Byte" },
            { "Int", "Long", "Short", "Byte" },
            { "True", "La console se met en erreur.", "False", "Les trois premières fonctionnent." },
            { "Les énumérations", "Les types nullables", "Les délégués", "L'inférence de type" },
            { "Convert.ToInt32()", "Parsse()", "TryeParse()", "Convert.ToInt16()" },
            { "Math.Round()", "Math.Ceiling()", "Math.Floor()", "Math.Truncate()" }
        };

        //déclaration du tableau des numéros des bonnes réponses possible
        int[] correctAnswers = new int[10] {
            4, 1, 4, 1, 1, 2, 3, 3, 1, 1
        };

        //déclaration du tableau du text des réponses possible
        string[] correctAnswerDetails = new string[] {
            "2001", "Language", "int x = 3;", "(x == true);", "Float", "Long", "False", "Les délégués", "Convert.ToInt32()", "Math.Round()"
        };

        // initialisation du score
        int score = 0;

        // déclaration de la liste des réponses donné par le candidat
        List<string> answerCandidat = new List<string> {};

        // début de la boucle qui parcours toutes les questions
        for (int i = 0; i < 10; i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Question {i + 1}: {questions[i]}\n");
            Console.ForegroundColor = ConsoleColor.White;

            // affichage des réponse possible
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"{j + 1}. {answers[i, j]}");
            }

            // début de la boucle pour vérification de l'entré par le candidat
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nVotre réponse (entrez le numéro de votre réponse):");
                Console.ForegroundColor = ConsoleColor.White;

                // récupération de ce qui est entré par le candidat
                string saisie = Console.ReadLine();

                // vérification si l'entré est un int ou un string
                int userAnswer;
                if (int.TryParse(saisie, out userAnswer))
                {

                    // ajout de la reponse donnée dans la liste des réponses donné
                    answerCandidat.Add(answers[i,userAnswer-1]);

                    // vérification si la réponse est bonne ou non avec sortie de la boucle des verifications des entrés
                    if (userAnswer == correctAnswers[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Bonne réponse !\n");
                        score++;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Mauvaise réponse :(\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    };
                }
                else
                {
                    Console.WriteLine("veuillez entrer un chiffre\n");
                };
            } while (true);

        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Appuyez sur la touche ENTRÉE pour connaître votre résultat");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();


        // affichage du résultat du questionnaire
        Console.WriteLine("Récapitulatif de votre résultat:\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Votre score est de: {score} sur 10\n");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Les bonnes réponses étaient:\n");

        // affichage des bonnes réponse et comparaison si l'entré été la bonne réponse
        for (int i = 0; i < 10; i++)
        {
            // délcaration des variables local
            string reponseCorret = correctAnswerDetails[i];
            string reponseDonne = answerCandidat[i];
            if (reponseCorret == reponseDonne)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Question {i + 1}: {reponseCorret}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Question {i + 1}: {reponseCorret}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nMerci d'avoir répondu au test.");
        Console.WriteLine("Notre agence reprendra contact avec vous dans un délai de 48h.");
        Console.WriteLine("Au revoir.");
        Console.ReadLine();
    }
}