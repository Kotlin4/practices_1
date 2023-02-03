using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "11kotlink";
            string UserInput;

            Console.Write("Введите пароль: ");
            UserInput = Console.ReadLine();

            if (UserInput == password) 
            {
                Console.WriteLine("Пароль принят. Входте.");
            }
            else 
            {
                Console.WriteLine("Пароль неверен. Проваливайте..");

            }
            Console.ReadLine();
        }
    }
}
