namespace PriceCounter
{
    public static class Starter
    {
        public static void Run()
        {
            Menu(ChooseMenuItem());
        }
        private static void Menu(int menuItem)
        {
            switch (menuItem)
            {
                case 1:
                    Logic.DisplayPrices();
                    break;
                case 2:
                    Logic.PrintPrices();
                    break;
                case 3:
                    Logic.Calculate();
                    break;
                case 4:
                    Logic.AddServices();
                    break;
                case 5:
                    Logic.AddClient();
                    break;
                case 6:
                    Logic.DisplayClients();
                    break;
                default:
                    Menu(ChooseMenuItem());
                    break;
            }
        }

        private static int ChooseMenuItem()
        {
            int menuItem;
            do
            {
                Console.Clear();
                PrintMenu();
            } while (!int.TryParse(Console.ReadLine(), out menuItem));
                
            return menuItem;
        } 

        private static void PrintMenu()
        {
            Console.WriteLine("-- Выберите пункт меню, нажав нужный номер и Enter --");
            Console.WriteLine("1. Отобразить все услуги на экране");
            Console.WriteLine("2. Отобразить все услуги в файл .txt");
            Console.WriteLine("3. Составить смету");
            Console.WriteLine("4. Добавить услугу");
            Console.WriteLine("5. Добавить клиента");
            Console.WriteLine("6. Отобразить список клиентов на экране");
        }
    }
}
