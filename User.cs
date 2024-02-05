namespace Application
{
    public class User
    {
        public string? Name { get; set; }
        public double CaloriesPerDay { get; set; } = 0;
        public string? Exercise { get; set; }

        private string? _gender;
        public string? Gender
        {
            get { return _gender; }
            set 
            {
                if(value == null)
                {
                    ShowInfo.DisplayError();
                    return;
                }
                value = value.ToLower();
                if(value is "м" or "мужской" or "муж") _gender = "мужской";
                else if(value is "ж" or "женский" or "жен") _gender = "женский";
                else ShowInfo.DisplayError();
            }
        }

        private int? _age;
        public int? Age
        {
            get { return _age; }
            set 
            {
                if(value is >= 1 and <= 120) _age = value;
                else ShowInfo.DisplayError();
            }
        }

        private int? _height;
        public int? Height
        {
            get { return _height; }
            set
            {
                if(value is >= 100 and <= 300) _height = value;
                else ShowInfo.DisplayError();
            }
        }
        
        private int? _weight;
        public int? Weight
        {
            get { return _weight; }
            set
            {
                if(value is >= 30 and <= 400) _weight = value;
                else ShowInfo.DisplayError();
            }
        }

        private double? _exerciseStress;
        public double? ExerciseStress
        {
            get { return _exerciseStress; }
            set
            {
                switch(value)
                {
                    case 1: _exerciseStress = 1.2; break;
                    case 2: _exerciseStress = 1.37; break;
                    case 3: _exerciseStress = 1.55; break;
                    case 4: _exerciseStress = 1.7; break;
                    case 5: _exerciseStress = 1.9; break;
                }
            }
        }

        public static User SetUser()
        {
            User user = new();

            bool result;

            string[] activitiesLevels =
            {
                "Пассивный, малоподвижный образ жизни, абсолютное отсутствие спорта",
                "Малая активность, изредка упражнения, ходьба",
                "Средний уровень активности",
                "Высокая активность, ежедневные занятия спортом",
                "Экстремальная подвижность, тренировки с весом"
            };

            Console.Clear();
            
            do //Имя
            {
                Console.WriteLine("\nВведите свое имя: \n");
                user.Name = Console.ReadLine();
            } while (user.Name == null);
            
            Console.Clear();
            do //Пол
            {
                Console.WriteLine("\nВведите свой пол: мужской/женский\n");
                user.Gender = Console.ReadLine();
            } while (user.Gender == null);
            Console.Clear();
            
            do //Возраст
            {
                Console.WriteLine("\nВведите свой возраст:\n");
                result = int.TryParse(Console.ReadLine(), out int age);
                if (result) user.Age = age;
                else ShowInfo.DisplayError();
            } while (user.Age == null);
            Console.Clear();
            
            do //Рост
            {
                Console.WriteLine("\nВведите свой рост в см:\n");
                result = int.TryParse(Console.ReadLine(), out int height);
                if (result) user.Height = height;
                else ShowInfo.DisplayError();
            } while (user.Height == null);
            Console.Clear();
            
            do //Вес
            {
                Console.WriteLine("\nВведите свой вес:\n");
                result = int.TryParse(Console.ReadLine(), out int weight);
                if (result) user.Weight = weight;
                else ShowInfo.DisplayError();
            } while (user.Weight == null);
            Console.Clear();
            
            do //Уровень активности
            {
                Console.WriteLine("\nВыберите уровень вашей физической активности:\n");
                for (int i = 0; i < activitiesLevels.Length; i++) Console.WriteLine($"{i + 1}. {activitiesLevels[i]}");
                Console.WriteLine();
                result = int.TryParse(Console.ReadLine(), out int exerciseStress);
                if (result && exerciseStress is >= 1 and <= 5)
                {
                    user.ExerciseStress = exerciseStress;
                    user.Exercise = activitiesLevels[exerciseStress - 1];
                }
                else ShowInfo.DisplayError();
            } while (user.ExerciseStress == null);
            Console.Clear();
            return user;
        }


    }
}