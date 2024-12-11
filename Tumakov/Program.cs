// Tumakov

namespace Programm
{
    public class Tumakov
    {
        // 1
        enum AccountType
        {
            Savings,
            Checking,
            Business
        }
        class BankAccount
        {
            private string accountNumber;
            private decimal balance;
            private AccountType accountType;

            public BankAccount(string accountNumber, decimal initialBalance, AccountType accountType)
            {
                this.accountNumber = accountNumber;
                this.balance = initialBalance;
                this.accountType = accountType;
            }

            public void DisplayAccountInfo()
            {
                Console.WriteLine("Информация о счете:");
                Console.WriteLine($"Номер счета: {accountNumber}");
                Console.WriteLine($"Баланс: {balance:C}");
                Console.WriteLine($"Тип счета: {accountType}");
            }

            public void Deposit(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма депозита должна быть больше нуля.");
                    return;
                }

                balance += amount;
                Console.WriteLine($"Вы успешно положили на счет {amount:C}. Новый баланс: {balance:C}");
            }

            public void Withdraw(decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма для снятия должна быть больше нуля.");
                    return;
                }

                if (amount > balance)
                {
                    Console.WriteLine("Недостаточно средств на счете для снятия.");
                    return;
                }

                balance -= amount;
                Console.WriteLine($"Вы успешно сняли со счета {amount:C}. Новый баланс: {balance:C}");
            }

            public decimal GetBalance()
            {
                return balance;
            }

            public AccountType GetAccountType()
            {
                return accountType;
            }

            public void ChangeAccountType(AccountType newType)
            {
                accountType = newType;
                Console.WriteLine($"Тип счета изменен на: {accountType}");
            }

            public void TransferFunds(BankAccount targetAccount, decimal amount)
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Сумма перевода должна быть больше нуля.");
                    return;
                }

                if (amount > balance)
                {
                    Console.WriteLine("Недостаточно средств на счете для перевода.");
                    return;
                }

                this.Withdraw(amount);
                targetAccount.Deposit(amount);
                Console.WriteLine($"Вы успешно перевели {amount:C} на счет {targetAccount.accountNumber}.");
            }
        }
        public static void Task1()
        {
            Console.WriteLine("Ответ на 1 задание: ");
            Console.WriteLine("Ответ на 3 задание: ");
            BankAccount account = new BankAccount("1234567890", 1000.50m, AccountType.Savings);
            BankAccount targetAccount = new BankAccount("0987654321", 500.00m, AccountType.Checking);

            account.DisplayAccountInfo();
            targetAccount.DisplayAccountInfo();

            Console.WriteLine("Перевод средств...");
            account.TransferFunds(targetAccount, 300.00m);

            Console.WriteLine("Обновленная информация о счетах:");
            account.DisplayAccountInfo();
            targetAccount.DisplayAccountInfo();
            Console.WriteLine();
        }
        // 2
        // Метод для переворота строки
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static void Task2()
        {
            Console.WriteLine("Ответ на 2 задание: ");
            Console.WriteLine("Тестирование метода ReverseString:");

            string original = "Hello, World!";
            string reversed = ReverseString(original);

            Console.WriteLine($"Оригинальная строка: {original}");
            Console.WriteLine($"Перевернутая строка: {reversed}");

            // Дополнительные тесты
            string test1 = "12345";
            string test2 = "abcde";
            string test3 = "";
            string test4 = null;

            Console.WriteLine($"Тест 1: {test1}, Перевернутая: {ReverseString(test1)}");
            Console.WriteLine($"Тест 2: {test2}, Перевернутая: {ReverseString(test2)}");
            Console.WriteLine($"Тест 3: (пустая строка), Перевернутая: {ReverseString(test3)}");
            Console.WriteLine($"Тест 4: (null), Перевернутая: {ReverseString(test4)}");
            Console.WriteLine();
        }
        // 3
        public static void Task3()
        {
            Console.WriteLine("Ответ на 3 задание: ");

            Console.WriteLine();
        }
        // 4
        // Метод для проверки, реализует ли объект интерфейс IFormattable
        public static void CheckIfIFormattable(object input)
        {
            if (input is IFormattable)
            {
                Console.WriteLine($"Объект типа {input.GetType().Name} реализует интерфейс IFormattable.");

                // Используем оператор 'as' для безопасного приведения
                IFormattable formattable = input as IFormattable;
                if (formattable != null)
                {
                    Console.WriteLine("Форматирование значения в строку: " + formattable.ToString(null, null));
                }
            }
            else
            {
                Console.WriteLine($"Объект типа {input.GetType().Name} не реализует интерфейс IFormattable.");
            }
        }
        public static void Task4()
        {
            Console.WriteLine("Ответ на 4 задание: ");

            object obj1 = 123.45m; // decimal реализует IFormattable
            object obj2 = "Hello, World!"; // string не реализует IFormattable
            object obj3 = DateTime.Now; // DateTime реализует IFormattable
            object obj4 = new object(); // Обычный object не реализует IFormattable

            CheckIfIFormattable(obj1);
            CheckIfIFormattable(obj2);
            CheckIfIFormattable(obj3);
            CheckIfIFormattable(obj4);
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
    }
}

