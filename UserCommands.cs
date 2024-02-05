namespace Application
{
    public class UserCommands
    {
        public static void DisplayUserDiet(User user)
        {   
            if(user.CaloriesPerDay == 0)
            {
                int DietDifference = 5;
                
                if (user.Gender == "женский")
                {
                    DietDifference = -161;
                }
                
                user.CaloriesPerDay = Convert.ToDouble(Math.Ceiling((decimal)((9.99 * user.Weight + 6.25 * user.Height - 4.92 * user.Age + DietDifference) * user.ExerciseStress * 0.87)!));
            }

            Console.WriteLine($" За день вам следует потреблять не больше {user.CaloriesPerDay} калорий");
            Console.WriteLine($" Завтрак: {Math.Ceiling(user.CaloriesPerDay * 0.35)} калорий");
            Console.WriteLine($"  Обед:   {Math.Ceiling(user.CaloriesPerDay * 0.40)} калорий");
            Console.WriteLine($"  Ужин:   {Math.Ceiling(user.CaloriesPerDay * 0.25)} калорий");
        }

        public static void DisplayUserData(User user) => ShowInfo.DisplayData(user);
    }
}