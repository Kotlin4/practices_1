using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            string[,] books =
            {
                {"Александр Пушкин", "Михаил Лермонтов", "Сергей Есенин" },
                { "Роберт Мартин", "Джесси Шелл", "Сергей Тепляков" },
                { "Свивен Кинг", "Говард Лавкрафт", "Брем Стокер" }
            };

            while (isOpen)
            {

                Console.SetCursorPosition(0, 20);
                Console.WriteLine("\nВесь список авторов: \n");
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    for (int j = 0; j < books.GetLength(1); j++)
                    {
                        Console.Write(books[i, j] + " | ");
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Библиотека");
                Console.WriteLine("\n1 — Узнать имя автора по индексу книги." +
                    "\n\n2 — Найти книгу по автору.\n\n3 — Выход.");
                Console.Write("\nВыберите пункт в меню: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int line, column;
                        Console.Write("Введите номер полки: ");
                        line = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.Write("Введите номер столбца: ");
                        column = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("Это автор: " + books[line, column]);
                        break;
                    case 2:
                        string author;
                        bool autorsFound = false;
                        Console.Write("Введите автора: ");
                        author = Console.ReadLine();

                        for (int i = 0; 4 < books.GetLength(0); i++)
                        {
                            for (int j = 0; j < books.GetLength(1); j++)
                            {
                                if (author.ToLower() == books[i, j].ToLower())
                                {
                                    Console.Write($"Автор {books[i, j]} находится по адресу полки " +
                                        $"{i + 1}, uecro {j + 1}");
                                    autorsFound = true;
                                }
                            }
                        }
                        if (autorsFound == false)
                        {
                            Console.WriteLine("Такого автора нет.");
                        }

                        break;
                    case 3:
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Введена неверная команда.");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("Нажмите любую кнопку.");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
