using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 5, maxHealth = 10;
            int mana = 5, maxMana = 10;
            DrawBar(health, maxHealth, ConsoleColor.Green, 0, '|');
            DrawBar(mana, maxMana, ConsoleColor.Blue, 1);

            Console.ReadKey();
        }

        static void DrawBar (int value, int maxValue, ConsoleColor color, int position, char symbol = '_') 
        {
            ConsoleColor defoultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar) ;
            Console.BackgroundColor = defoultColor; 

            bar = "";

            for (int i = value; i<maxValue; i++)
            {
                bar+= symbol;
            }
            Console.Write(bar + ']');
        }
    }
}
