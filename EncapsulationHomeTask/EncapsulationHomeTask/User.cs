using System;
using System.Linq;
using System.Threading;

namespace EncapsulationHomeTask
{
    internal class User
    {
        private static int _lastId;
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }

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
            while (true)
            {
                Console.Write("Please enter your password: ");
                string inputPassword = Console.ReadLine() ?? string.Empty;

                if (inputPassword.Length >= 8
                    && inputPassword.Any(char.IsUpper)
                    && inputPassword.Any(char.IsDigit)
                    && inputPassword.Any(char.IsLower))
                {
                    Password = inputPassword;
                    break;
                }

                Console.WriteLine("Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one digit. Try again.");
            }
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
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Email: {Email}");
        }
        public void SetName()
        {
            Console.Write("Enter new name: ");
            string newName = Console.ReadLine() ?? string.Empty;
            Name = newName;
        }

        public void SetEmail()
        {
            Console.Write("Enter new email: ");
            string newEmail = Console.ReadLine() ?? string.Empty;
            Email = newEmail;
        }

        public void SetSurname()
        {
            Console.Write("Enter new surname: ");
            string newSurname = Console.ReadLine() ?? string.Empty;
            Surname = newSurname;

        }

        public void SetAge()
        {
            Console.Write("Enter new age: ");
            string newAge = Console.ReadLine() ?? string.Empty;
            Age = int.Parse(newAge);
        }
    }
}
