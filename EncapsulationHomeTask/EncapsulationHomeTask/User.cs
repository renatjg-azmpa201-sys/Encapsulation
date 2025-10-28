using System.Text.RegularExpressions;

namespace EncapsulationHomeTask
{
    internal class User
    {
        private static int _lastId;
        private string _name;
        private string _surname;
        private int _age;
        private string _email;
        private string _password;

        public int ID { get; private set; }

        public string Name
        {
            get => _name;
            set
            {
                while (true)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.Write("Name cannot be empty! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    if (value.Length < 3)
                    {
                        Console.Write("Name must be at least 3 characters! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    if (value.Any(char.IsDigit))
                    {
                        Console.Write("Name cannot contain numbers! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    _name = value;
                    break;
                }
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                while (true)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.Write("Surname cannot be empty! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    if (value.Length < 3)
                    {
                        Console.Write("Surname must be at least 3 characters! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    if (value.Any(char.IsDigit))
                    {
                        Console.Write("Surname cannot contain numbers! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    _surname = value;
                    break;
                }
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                while (true)
                {
                    if (value < 0 || value > 120)
                    {
                        Console.Write("Age must be between 0 and 120! Enter again: ");
                        int.TryParse(Console.ReadLine(), out value);
                        continue;
                    }
                    _age = value;
                    break;
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                while (true)
                {
                    if (!Regex.IsMatch(value ?? "", pattern))
                    {
                        Console.Write("Invalid email format! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    _email = value;
                    break;
                }
            }
        }

        public string Password
        {
            get => _password;
            private set
            {
                while (true)
                {
                    if (string.IsNullOrEmpty(value)
                        || value.Length < 8
                        || !value.Any(char.IsUpper)
                        || !value.Any(char.IsLower)
                        || !value.Any(char.IsDigit))
                    {
                        Console.Write("Password must be at least 8 chars, contain upper, lower, and digit! Enter again: ");
                        value = Console.ReadLine();
                        continue;
                    }
                    _password = value;
                    break;
                }
            }
        }

        public User(string name, string surname, int age, string email, string password = null)
        {
            ID = Interlocked.Increment(ref _lastId);
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;

            if (!string.IsNullOrEmpty(password))
                Password = password;
        }

        public User()
        {
            ID = Interlocked.Increment(ref _lastId);
        }

        public void PassChecker()
        {
            Console.Write("Please enter your password: ");
            string inputPassword = Console.ReadLine() ?? string.Empty;
            Password = inputPassword;
        }

        public void AccessPassword()
        {
            while (true)
            {
                Console.Write("Please re-enter your password: ");
                string inputPassword = Console.ReadLine() ?? string.Empty;

                if (inputPassword == Password)
                {
                    Console.WriteLine("Access granted.");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"\nID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }

        public void SetName()
        {
            Console.Write("Enter new name: ");
            Name = Console.ReadLine() ?? string.Empty;
        }

        public void SetSurname()
        {
            Console.Write("Enter new surname: ");
            Surname = Console.ReadLine() ?? string.Empty;
        }

        public void SetAge()
        {
            Console.Write("Enter new age: ");
            if (int.TryParse(Console.ReadLine(), out int newAge))
                Age = newAge;
            else
                Console.WriteLine("Invalid age input!");
        }

        public void SetEmail()
        {
            Console.Write("Enter new email: ");
            Email = Console.ReadLine() ?? string.Empty;
        }
    }
}
