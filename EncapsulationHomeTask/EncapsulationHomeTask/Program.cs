using System;
using EncapsulationHomeTask;

namespace EncapsulationApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== USER REGISTRATION ===\n");

            
            User user = CreateUser();
            User user1 = CreateUser();
            User user2 = CreateUser();
            User user3 = CreateUser();

            User[] users = { user, user1, user2, user3 };

            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Show all users");
            Console.WriteLine("2. Find user by ID");
            Console.WriteLine("3. Exit\n");

            while (true)
            {
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("\n=== All Users ===");
                    foreach (var usr in users)
                    {
                        usr.GetInfo();
                        Console.WriteLine("===========================");
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter the ID of the user to find: ");
                    if (int.TryParse(Console.ReadLine(), out int idToFind))
                    {
                        User foundUser = Array.Find(users, u => u.ID == idToFind);

                        if (foundUser != null)
                        {
                            Console.WriteLine("\nUser found:");
                            foundUser.GetInfo();
                        }
                        else
                        {
                            Console.WriteLine("No user found with that ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format!");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again (1, 2 or 3).");
                }

                Console.WriteLine();
            }
        }

        static User CreateUser()
        {
            User user = new User();
            user.SetName();
            user.SetSurname();
            user.SetEmail();
            user.SetAge();
            user.PassChecker();
            user.AccessPassword();
            Console.WriteLine("User created successfully!\n");
            return user;
        }
    }
}
