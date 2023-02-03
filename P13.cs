using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int lower, higer;
            int triesCount = 5;
            int userInput;
            Random rand = new Random();

            number = rand.Next(0, 101);
            lower = rand.Next(number, number - 10);
            higer = rand.Next(number + 1, number + 10);

            Console.WriteLine($"Есть число. Больше {lower}, но меньшн {higer}. Гадайте.");
            Console.WriteLine($"У вас {triesCount} попыток.");

            while(triesCount-- > 0) 
            {
                Console.WriteLine("Ваш ответ: ");
                userInput = Convert.ToInt32(Console.ReadLine());

                if(userInput == number) 
                {
                    Console.WriteLine("Число верное. Поздравляю.");
                    break;
                }
                else
                {
                    Console.WriteLine("Число неверное. Поздравляю.");
                }
            }
        }
    }
}
