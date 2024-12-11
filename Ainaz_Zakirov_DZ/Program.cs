// DZ 7
namespace Programm
{
    public class DZ7
    {
        // 1
        
        public static void Task1()
        {
            Console.WriteLine("Ответ на 1 задание: ");

            Console.WriteLine();
        }
        // 2
        public class Song
        {
            public string Name { get; set; } // Название песни
            public string Author { get; set; } // Автор песни
            public Song Prev { get; set; } // Связь с предыдущей песней

            public Song(string name, string author)
            {
                Name = name;
                Author = author;
                Prev = null;
            }

            public string Title()
            {
                return $"{Name} by {Author}";
            }

            public override bool Equals(object obj)
            {
                if (obj is Song otherSong)
                {
                    return Name == otherSong.Name && Author == otherSong.Author;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name, Author);
            }
        }
        public class Employee
        {
            public string Name { get; set; }
            public string Position { get; set; }
            public Employee Manager { get; set; } // Прямой руководитель

            public Employee(string name, string position, Employee manager = null)
            {
                Name = name;
                Position = position;
                Manager = manager;
            }

            public bool AssignTask(string task, Employee assigner)
            {
                if (assigner == Manager)
                {
                    Console.WriteLine($"{assigner.Name} даёт задачу \"{task}\" {Name}. Задача принята.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{assigner.Name} даёт задачу \"{task}\" {Name}. Задача отклонена.");
                    return false;
                }
            }
        }
        public static void Task2()
        {
            Console.WriteLine("Ответ на 2 задание: ");
            // Создаём иерархию сотрудников
            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор", timur);
            Employee ilham = new Employee("Ильхам", "Директор по автоматизации", timur);
            Employee lucas = new Employee("Лукас", "Главный бухгалтер", rashid);
            Employee orcady = new Employee("Оркадий", "Начальник ИТ", ilham);
            Employee volodya = new Employee("Володя", "Зам. начальника ИТ", ilham);
            Employee ilshat = new Employee("Ильшат", "Главный системщик", orcady);
            Employee sergey = new Employee("Сергей", "Главный разработчик", orcady);
            Employee lyaysan = new Employee("Ляйсан", "Зам. главного разработчика", sergey);
            Employee dina = new Employee("Дина", "Разработчик", lyaysan);

            // Пример назначения задач
            Console.WriteLine("Назначение задач:");
            lucas.AssignTask("Подготовить отчет", rashid); // Разрешено
            lucas.AssignTask("Подготовить отчет", ilham); // Отклонено
            dina.AssignTask("Написать модуль", lyaysan); // Разрешено
            dina.AssignTask("Проверить сети", orcady); // Отклонено
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Task1();
            Task2();
        }
    }
}
