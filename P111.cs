using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters =
                {
                new Fighter("Джон", 500, 50, 0),
                new Fighter("Марк", 250, 25, 20),
                new Fighter("Алекс", 150, 100, 10),
                new Fighter("Джек", 300, 75, 5)
                };

                int fighterwumber;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + 1 + " ");
                fighters[i].ShowStats();
            }

            Console.WriteLine("\n** " + new string('—', 25) + " **");
            Console.Write("\nВыберите номер первого бойца: ");
            fighterwumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter firtsFighter = fighters[fighterwumber];

            Console.Write("Выберите номер второго бойца: ");
            fighterwumber = Convert.ToInt32(Console.ReadLine()) - 1;
            Fighter secondFighter = fighters[fighterwumber];
            Console.WriteLine("\n** " + new string('-', 25) + " #*");

            while (firtsFighter.Healt > 0 && secondFighter.Healt > 0)
            {
                firtsFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firtsFighter.Damage);
                firtsFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();
            }
        }
    }
    class Fighter
    {
        private string _name;
        private int _healt;
        private int _damage;
        private int _armor;

        public int Healt { get { return _healt; } }
        public int Damage { get { return _damage; } }   
        public Fighter(string name, int healt, int damage, int armor)
        {
            _name = name;
            _healt = healt;
            _damage = damage;
            _armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Boen — {_name}, smoposne: {_healt}, sasocmert ypou: {_damage}, Gpona: {_armor}");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"{_name} sqoposse: {_healt}");
        }
        public void TakeDamage(int damage)
        {
            _healt -= damage - _armor;
        }
    }
}
