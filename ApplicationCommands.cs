using System.Xml.Linq;

namespace Application
{
    public static class ApplicationCommands
    {
        public static void AddUser(List<User> users) => users.Add(User.SetUser());

        public static void DisplayUsers(List<User> users)
        {
            int selectedUser, command;

            if (users.Count == 0)
                Console.WriteLine("Вы пока не добавили ни одного пользователя...");
            else
            {
                selectedUser = ShowInfo.UserSelect(users);
                do
                {
                    command = ShowInfo.DisplayUserMenu();
                    if (command == 1)
                    {
                        UserCommands.DisplayUserDiet(users[selectedUser - 1]);
                    }
                    else if (command == 2)
                    {
                        UserCommands.DisplayUserData(users[selectedUser - 1]);
                    }
                } while (command != Program.USER_COMMANDS_COUNT);
            }
        }

        public static void DisplayProducts(XElement products)
        {
            Console.WriteLine($"\n{"Все продукты",22}\n");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"|{"Продукт",16}|{"Ккал/100 гр.",9} |");
            Console.WriteLine("--------------------------------");
            foreach (XElement product in products!.Elements("product"))
            {
                XAttribute? name = product.Attribute("name");
                XElement? calories = product?.Element("calories");
                Console.WriteLine($"|{name?.Value,-16}|{calories?.Value,11} |");
            }
        }
    }
}