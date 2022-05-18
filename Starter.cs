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
            Console.WriteLine("1. Вывод всех цен на экран");
            Console.WriteLine("2. Вывод всех цен в файл .txt");
            Console.WriteLine("3. Составить смету");
            Console.WriteLine("4. Добавить услугу");
        } 
    }
}
