using static System.Console;

namespace Application
{
    public static class ShowInfo
    {
        public static void DisplayError()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Ошибка ввода, попробуйте еще раз\n");
            ForegroundColor = ConsoleColor.Gray;
        }

        public static void DisplayData(User user)
        {
            WriteLine("Ваши данные:\n");
            WriteLine($"Имя: {user.Name}");
            WriteLine($"Пол: {user.Gender}");
            WriteLine($"Возраст: {user.Age}");
            WriteLine($"Рост: {user.Height}");
            WriteLine($"Текущий вес: {user.Weight}");
            WriteLine($"Физическая нагрузка: {user.Exercise}\n");
        }

        public static int DisplayMainMenu()
        {
            bool result;
            while (true)
            {
                WriteLine("\nВведите номер нужной вам команды:\n");
                WriteLine("1. Добавить пользователя");
                WriteLine("2. Пользователи");
                WriteLine("3. Продукты");
                WriteLine("4. Выход\n");
                result = int.TryParse(ReadLine(), out int command);
                if (result)
                {
                    if ((command < 1) || (command > Program.COMMANDS_COUNT))
                    {
                        DisplayError();
                    }
                    else
                    {
                        Clear();
                        return command;
                    }
                }
                DisplayError();
            }
        }

        public static int UserSelect(List<User> users)
        {
            bool result;
            while (true)
            {
                for (int i = 0; i < users.Count; i++)
                    WriteLine($"{i+1}. {users[i].Name}");
                
                WriteLine("\nВыберите пользователя:\n");
                result = int.TryParse(ReadLine(), out int selectedUser);
                if (result)
                {
                    if (selectedUser > users.Count || selectedUser < 1)
                    {
                        DisplayError();
                    }
                    else
                    {
                        Clear();
                        return selectedUser;
                    }
                }
                DisplayError();
            }
        }

        public static int DisplayUserMenu()
        {
            bool result;
            while (true)
            {
                WriteLine("\nВведите номер нужной вам команды:\n");
                WriteLine("1. Диета");
                WriteLine("2. Характеристики");
                WriteLine("3. Назад\n");
                result = int.TryParse(ReadLine(), out int command);
                if (result)
                {
                    if ((command < 1) || (command > Program.USER_COMMANDS_COUNT))
                    {
                        DisplayError();
                    }
                    else
                    {
                        Clear();
                        return command;
                    }
                }
                DisplayError();
            }
        }
    }
}