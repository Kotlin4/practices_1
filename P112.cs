using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComuterClub comuterClub = new ComuterClub(8);
        }

        class ComuterClub
        {
            private int _money = 0;
            private List<Computer> _computers = new List<Computer>();
            private Queue<Client> _clients = new Queue<Client>();

            public ComuterClub(int coumputersCount)
            {

                Random random = new Random();

                for (int i = 0; i < coumputersCount; i++)
                {
                    _computers.Add(new Computer(random.Next(5, 15)));
                }
                CreateNewClients(25, random);
            }
            public void CreateNewClients(int count, Random random)
            {
                for (int i = 0; i < count; i++)
                {
                    _clients.Enqueue(new Client(random.Next(100, 251), random));
                }
            }

            public void Work()
            {
                while (_clients.Count > 0)
                {
                    Client newClient = _clients.Dequeue();
                    Console.WriteLine($"Баланс комютерного клуба {_money} руб. Ждем нового клиента.");
                    Console.WriteLine($"У вас новый клиент, он хочет купить {newClient.DiserdMinutes} минут.");
                    ShowAllComputesState();

                    Console.Write("\nВы предлогаете ему компютер под номером: ");
                    string userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int computerNumper))
                    {
                        computerNumper -= 1;
                        if (computerNumper >= 0 && computerNumper < _computers.Count) 
                        {
                            if (_computers[computerNumper].IsTeken)
                            {
                                Console.WriteLine("Вы пытаетесь посадить клиента за занятый компютер.");
                            }
                            else
                            {
                                if (newClient.CheckSolvency(_computers[computerNumper]))
                                {
                                    Console.WriteLine("Клиент сел за компютер " + computerNumper + 1);
                                    _money += newClient.Pay();
                                    _computers[computerNumper].BecomeTaken(newClient);
                                }
                                else
                                {
                                    Console.WriteLine("У клиента нет денег");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы не знаете за какой компютер его посадить.");
                        }
                    }
                    else
                    {
                        CreateNewClients(1, new Random());
                        Console.WriteLine("Неверный ввод! Попробуйте снова.");
                    }

                    Console.WriteLine("Чтобы перейти к следующему клиенту, кажмите кнопку");
                    Console.ReadKey();
                    Console.Clear();
                    SpendOneMinute();
                }
            }

            private void ShowAllComputesState()
            {
                Console.WriteLine("\nСписок всех компютеров");
                for (int i = 0; i < _computers.Count; i++)
                {
                    Console.Write(i + 1 + " - ");
                    _computers[i].ShowState();
                }
            }

            private void SpendOneMinute()
            {
                foreach (var computer in _computers)
                {
                    computer.SpendOneMinute;
                }
            }
        }

        class Computer
        {
            private Client _client;
            private int _MinutesRemaining;

            public bool IsTeken
            {
                get
                {
                    return _MinutesRemaining > 0;
                }
            }
            public int PricePerMinute { get; private set; }

            public Computer(int pricePerMinute)
            {
                PricePerMinute = pricePerMinute;
            }

            public void BecomeTaken(Client client)
            {
                _client= client;
                _MinutesRemaining = _client.DiserdMinutes;
            }

            public void BecomeEmpty()
            {
                _client = null;
            }

            public void SpendOneMinute()
            {
                _MinutesRemaining--;
            }

            public void ShowState()
            {

                if (IsTeken)
                    Console.WriteLine($"Компютер занят, осталось минут: {_MinutesRemaining}");
                else
                    Console.WriteLine($"Компютер свободен, цена за минуту: {PricePerMinute}");
            }
        }

        class Client
        {
            private int _money;

            private int _moneyToPay;

            public int DiserdMinutes{ get; private set; }

            public Client (int Money, Random random)
            {
                _money = Money;
                DiserdMinutes = random.Next(10, 30);
            }

            public bool CheckSolvency(Computer computer)
            {
                _moneyToPay = DiserdMinutes * computer.PricePerMinute;
                if (_money >= _moneyToPay)
                {
                    return true;
                }
                else
                {
                    _moneyToPay= 0;
                    return false;
                }
            }

            public int Pay()
            {
                _money -= _moneyToPay;
                return _moneyToPay;
            }
        }
    }
}
