namespace Homework8;
using System;

class FieldOfMiracles
{
    static void Main()
    {
        //Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Давайте пограємо в гру в слова? <y/n>");
        string start = Console.ReadLine();

        if (start.ToLower() == "y")
        {
            string[] words = { "кіт", "собака", "будинок" };
            Random random = new Random();
            string secretWord = words[random.Next(words.Length)];
            string guessedWord = new string('_', secretWord.Length);
            int remainingGuesses = secretWord.Length;

            Console.WriteLine("Вгадай моє таємне слово. Містить " + remainingGuesses + " букв.");
            Console.WriteLine("Причому вгадувати можна по одній букві за раз.");
            Console.WriteLine("Вам дано " + remainingGuesses + " неправильних здогадок.");

            while (remainingGuesses > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Ваше слово: " + guessedWord);


                Console.Write("Вгадайте букву: ");
                char guess = Console.ReadLine().ToLower()[0];

                if (!Char.IsLetter(guess))
                {
                    Console.WriteLine("Неправильний символ. Введіть букву.");
                    continue;
                }

                bool letterFound = false;

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord = guessedWord.Substring(0, i) + guess + guessedWord.Substring(i + 1);
                        letterFound = true;
                    }
                }

                if (letterFound)
                {
                    Console.WriteLine("Правильно!");
                }
                else
                {
                    Console.WriteLine("Неправильно!");
                    Console.WriteLine("Неправильні варіанти: " + guess);

                    remainingGuesses--;
                    Console.WriteLine("Залишилося " + remainingGuesses + " неправильних варіантів.");
                }

                if (guessedWord == secretWord)
                {
                    Console.Clear();
                    Console.WriteLine("Ваше слово: " + secretWord);
                    Console.WriteLine("Все вірно!");

                    break;
                }

                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
                Console.Clear();
            }

            if (remainingGuesses == 0)
            {
                Console.WriteLine("Гра закінчена! Ваше слово: " + secretWord);
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Можливо наступного разу! До побачення!");

        }
    }
}
