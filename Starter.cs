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
                    Console.Clear();
                    Menu(ChooseMenuItem());
                    break;
                default:
                    Menu(ChooseMenuItem());
                    break;
            }
        }

        public static int ChooseMenuItem()
        {
            int menuItem;
            do
            {
                PrintMenu();
            } while (!int.TryParse(Console.ReadLine(), out menuItem));
                
            return menuItem;
        } 

        private static void PrintMenu()
        {
            Console.WriteLine("-- Выберите пункт меню, нажав нужный номер и Enter --");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1. Отобразить все услуги на экране");
            Console.WriteLine("2. Отобразить все услуги в файл .txt");
            Console.WriteLine("3. Добавить услугу");
            Console.WriteLine("4. Добавить клиента");
            Console.WriteLine("5. Отобразить список клиентов на экране");
            Console.WriteLine("6. Поиск клиента по номеру телефона");
            Console.WriteLine("7. Составить смету и сохранить ее в файл .txt");
            Console.WriteLine("0. Очистить консоль");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
