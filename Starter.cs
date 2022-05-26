using System.Diagnostics;

namespace PriceCounter
{
    public static class Starter
    {
        public static void Run()
        {
            Menu(ChooseMenuItem());
        }
        public static void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:
                    Logic.DisplayServicesAsync();
                    break;
                case 2:
                    Logic.PrintServicesAsync();
                    break;
                case 3:
                    Logic.AddServicesAsync();
                    break;
                case 4:
                    Logic.AddClientAsync();
                    break;
                case 5:
                    Logic.DisplayClientsAsync();
                    break;
                case 6:
                    Logic.FindClientByPhoneNumberAsync();
                    break;
                case 7:
                    Logic.MakeEstimateInTxt();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Menu(ChooseMenuItem());
                    break;
            }
        }

        public static int ChooseMenuItem()
        {
            int menuItem;
            bool isItem = false;
            do
            {
                if (isItem == false)
                    Console.Clear();
                PrintMenu();
                isItem = int.TryParse(Console.ReadLine(), out menuItem);
                
            } while (!isItem);
                
            return menuItem;
        } 

        private static void PrintMenu()
        {
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("[1] Display all services on the screen");
            Console.WriteLine("[2] Display all services in a .txt file");
            Console.WriteLine("[3] Add service");
            Console.WriteLine("[4] Add a client");
            Console.WriteLine("[5] Display a list of clients on the screen");
            Console.WriteLine("[6] Searching for a customer by phone number");
            Console.WriteLine("[7] Make an estimate and save it as a .txt file");
            Console.WriteLine("[0] Close the program");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
