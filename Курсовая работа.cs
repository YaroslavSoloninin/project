using System.Xml.Linq;

namespace Application
{
    class Program
    {
        public const int COMMANDS_COUNT = 4;
        public const int USER_COMMANDS_COUNT = 3;
        static void Main()
        {
            int command;
            XDocument xdoc = XDocument.Load("Products.xml");
            List<User> users = new List<User>();


            Console.Clear();

            do // Выбор команды 
            {
                command = ShowInfo.DisplayMainMenu(); // Вывод меню
                if (command == 1) // Добавление пользователя
                {
                    do
                    {
                        ApplicationCommands.AddUser(users);
                    } while (!CheckData.IsAgree(users));
                }
                else if (command == 2) // Список пользователей
                {
                    ApplicationCommands.DisplayUsers(users);
                }
                else if (command == 3) // Список продуктов
                {
                    ApplicationCommands.DisplayProducts(xdoc.Element("products")!);
                }
            } while (command != COMMANDS_COUNT);
        }
    }
}
