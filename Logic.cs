﻿using System;
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

            EndOfService();
        }

        internal static void PrintServices()
        {

            EndOfService();
        }

        internal static void DisplayServices()
        {
            Console.WriteLine("Список услуг:");

            using (ventilUAContext db = new ventilUAContext())
            {
                var services = db.Works.ToList();
                foreach (Work service in services)
                {
                    Console.WriteLine($"{service.TheWork} - {service.Price}");
                }
            }
            EndOfService();
        }

        internal static void AddServices()
        {
            using (ventilUAContext db = new ventilUAContext())
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

        internal static void DisplayClients()
        {
            Console.WriteLine("Список клиентов:");

            using (ventilUAContext db = new ventilUAContext())
            {
                var clients = db.Clients.ToList();
                foreach (Client client in clients)
                {
                    Console.WriteLine($"{client.Name} - {client.Phone} - {client.Address}");
                }
            }

            EndOfService();
        }

        internal static void FindClientByPhoneNumber()
        {
            Console.WriteLine("Enter the phone number of the client you want to find:");
            string phoneNumber = Console.ReadLine();

            using (ventilUAContext db = new ventilUAContext())
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

        internal static void AddClient()
        {
            using (ventilUAContext db = new ventilUAContext())
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
