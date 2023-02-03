using System;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    internal class Program
    {
        static void Main (string[] args)
        {
            float healht;
            int armor;
            int damage;
            int precentConvert = 100;

            Console.Write("Введите количество здоровья: ");
            healht = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество брони: ");
            armor = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество атаки: ");
            damage = Convert.ToInt32(Console.ReadLine());

            healht -= Convert.ToSingle(damage) * armor / precentConvert;

            Console.WriteLine($"Вам нанесено: {damage} урона");

            Console.ReadLine();
        }
    }
}