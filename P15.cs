using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] sectors = { 6, 28, 15, 15, 17 };
            bool isOpen = true;

            while (isOpen)
            {
                Console.SetCursorPosition(0, 18);
                for (int i = 0; 4 < sectors.Length; i++)
                {
                    Console.WriteLine($"В секторе {i + 1} свободно {sectors[i]} мест.");
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регистрация рейса.");
                Console.WriteLine("\n \n1 - Забронировать места; \n \n 2 - выход из программы \n \n");
                Console.WriteLine("Введите номер команды: ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        int userSector, userPlaceAmout;
                        Console.WriteLine("В каком секторе хотите лететь?");
                        userSector= Convert.ToInt32(Console.ReadLine());

                        if(sectors.Length <= userSector || userSector < 0) 
                        {
                            Console.WriteLine("Такого сектора не существует.");
                            break;
                        }

                        Console.WriteLine("Сколько мест вы хотите забронировать?");
                        userPlaceAmout= Convert.ToInt32(Console.ReadLine());

                        if (sectors[userSector] < userPlaceAmout || userPlaceAmout < 0)
                        {
                            Console.WriteLine($"В секторе {userSector} недостаточно мест. " +
                                $"Остаток {sectors[userSector]}");
                            break;
                        }

                        sectors[userSector] -= userPlaceAmout;
                        break;
                    case 2:
                        isOpen= false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    } 
}
