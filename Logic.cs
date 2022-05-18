using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCounter
{
    internal static class Logic
    {
        internal static void Calculate()
        {
            throw new NotImplementedException();
        }

        internal static void PrintPrices()
        {
            throw new NotImplementedException();
        }

        internal static void DisplayPrices()
        {
            throw new NotImplementedException();
        }

        internal static void AddServices()
        {
            throw new NotImplementedException();
        }

        internal static void DisplayClients()
        {
            using (ventilUAContext db = new ventilUAContext())
            {
               

                var clients = db.Clients.ToList();
                Console.WriteLine("Список клиентов:");
                foreach (Client client in clients)
                {
                    Console.WriteLine($"{client.Name} - {client.Phone} - {client.Address}");
                }
            }
        }

        internal static void AddClient()
        {
            Console.WriteLine("");
            using (ventilUAContext db = new ventilUAContext())
            {
                Console.WriteLine("Enter a name of new client:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter a phone of new client:");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter an adress of new client:");
                string address = Console.ReadLine();

                var clients = db.Clients.ToList();

                

                db.Clients.Add(new Client {
                    Id = clients.Count,
                    Name = name, 
                    Phone = phone, 
                    Address = address });
                db.SaveChanges();

            }
        }
    }
}
