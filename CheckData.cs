
namespace Application
{
    public static class CheckData
    {
        public static bool IsAgree(List<User> users)
        {
            while (true)
            {
                ShowInfo.DisplayData(users[^1]);
                Console.WriteLine("\nВведенные данные верны? Д/Н");
                string? input = Console.ReadLine();
                if (input == null)
                {
                    ShowInfo.DisplayError();
                }
                else if (input.ToLower() is "д" or "да")
                {
                    Console.Clear();
                    return true;
                }
                else if (input.ToLower() is "н" or "нет")
                {
                    users.Remove(users[^1]);
                    return false;
                }
                else
                {
                    ShowInfo.DisplayError();
                }
            }
        }
    }
}