using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCounter
{
    internal static class Logic
    {

        internal static void PrintServices()
        {


            EndOfService();
        }

        internal static async Task DisplayServicesAsync()
        {
            Console.WriteLine("Список услуг:");

            await using (ventilUAContext db = new ventilUAContext())
            {
                var services = db.Works.ToList();
                foreach (Work service in services)
                {
                    Console.WriteLine($"{service.TheWork} - {service.Price}");
                }
            }

            EndOfService();
        }

        internal static void MakeEstimateInTxt()
        {
            string clientInfo = CreateFile();
            string path = $"{clientInfo}.txt";

            int count;
            do
                Console.WriteLine("How many services do you want to add?");
            while (!int.TryParse(Console.ReadLine(), out count));

            double amountPrice = 0.0;
            string resultString = " ";

            File.WriteAllText(path, clientInfo + "\n\n", Encoding.Unicode);

                for (int i = 0; i < count; i++)
                {
                    var serviceInfo = ReadServiceInfo();
                    resultString = $"{serviceInfo.Item1} - {serviceInfo.Item2} UAH - {serviceInfo.Item3} pcs. \n";
                    File.AppendAllText(path, resultString, Encoding.Unicode);

                    amountPrice += Calculate(serviceInfo.Item2, serviceInfo.Item3);
                }

            File.AppendAllText(path, $"\nTotal price = {amountPrice} UAH", Encoding.Unicode);
            EndOfService();
        }

        private static (string, double, double) ReadServiceInfo()
        {
            string nameOfService = "_";
            double price = 0.0;
            double quantity = 0.0;

            Console.WriteLine("Enter the name of the service to be provided:");
            nameOfService = Console.ReadLine();
            Console.WriteLine("Enter a price:");
            double.TryParse(Console.ReadLine(), out price);
            Console.WriteLine("Enter a quantity:");
            double.TryParse(Console.ReadLine(), out quantity);

            return (nameOfService, price, quantity);
        }

        internal static string CreateFile()
        {
            string clientInfo;
            Console.WriteLine("Enter a name of a client:");
            clientInfo = Console.ReadLine();
            Console.WriteLine($"Enter a phone of {clientInfo}:");
            clientInfo += "_" + Console.ReadLine();
            clientInfo += "_" + DateTime.Now.ToString("d");
            string path = $"{clientInfo}.txt";

            using (File.Create(path))

            return clientInfo;
        }

        internal static double Calculate(double price, double quantity) => price* quantity;

        internal static async Task AddServicesAsync()
        {
            await using (ventilUAContext db = new ventilUAContext())
            {
                Console.WriteLine("Enter name of new service:");
                string theWork = Console.ReadLine();
                Console.WriteLine("Enter a price of new service:");
                decimal price = 0;
                bool resultOfParse = decimal.TryParse(Console.ReadLine(), out price);

                var works = db.Works.ToList();

                db.Works.Add(new Work
                {
                    Id = works.Count,
                    TheWork = theWork,
                    Price = price,
                });

                db.SaveChanges();
            }

            EndOfService();
        }

        internal static async Task DisplayClientsAsync()
        {
            Console.WriteLine("Список клиентов:");

            await using (ventilUAContext db = new ventilUAContext())
            {
                var clients = db.Clients.ToList();
                foreach (Client client in clients)
                {
                    Console.WriteLine($"{client.Name} - {client.Phone} - {client.Address}");
                }
            }

            EndOfService();
        }

        internal static async Task FindClientByPhoneNumberAsync()
        {
            Console.WriteLine("Enter the phone number of the client you want to find:");
            string phoneNumber = Console.ReadLine();

            await using (ventilUAContext db = new ventilUAContext())
            {
                try
                {
                    var client = db.Clients.ToList()
                        .Where(client => client.Phone == phoneNumber)
                        .ToArray();

                    Console.WriteLine($"{client[0].Name} - {client[0].Phone} - {client[0].Address}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect number, or client not found!");
                }
            }

            EndOfService();
        }

        internal static async Task AddClientAsync()
        {
            await using (ventilUAContext db = new ventilUAContext())
            {
                Console.WriteLine("Enter a name of new client:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a phone of new client:");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter an adress of new client:");
                string address = Console.ReadLine();

                var clients = db.Clients.ToList();

                    db.Clients.Add(new Client
                    {
                        Id = clients.Count,
                        Name = name,
                        Phone = phone,
                        Address = address
                    });
                    db.SaveChanges();
            }

            EndOfService();
        }

        private static void EndOfService()
        {
            Console.WriteLine("To continue, press the enter key");
            Console.ReadLine();
            Starter.Menu(Starter.ChooseMenuItem());
        }
    }
}
