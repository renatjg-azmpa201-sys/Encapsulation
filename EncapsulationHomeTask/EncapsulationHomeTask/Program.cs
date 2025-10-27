using EncapsulationHomeTask;
using System.Xml.Serialization;

User user = new User();
user.SetName();
user.SetSurname();
user.SetEmail();
user.SetAge();
user.PassChecker();
user.AccessPassword();

User user1 = new User();
user1.SetName();
user1.SetSurname();
user1.SetEmail();
user1.SetAge();
user1.PassChecker();
user1.AccessPassword();

User user2 = new User();
user2.SetName();
user2.SetSurname();
user2.SetEmail();
user2.SetAge();
user2.PassChecker();
user2.AccessPassword();

User user3 = new User();
user3.SetName();
user3.SetSurname();
user3.SetEmail();
user3.SetAge();
user3.PassChecker();
user3.AccessPassword();


string coice = Console.ReadLine();
while (true)
{
    if (coice == "1")
    {  
        User[] users = { user , user1 , user2 , user3  };
        foreach (var usr in users)
        {
            usr.GetInfo();
            Console.WriteLine("===================================");
        }
    }
    else if (coice == "2")
    {
        int idToFind;
        Console.Write("Enter the ID of the user to find: ");
        idToFind = int.Parse(Console.ReadLine()) ;
        User[] users = { user , user1 , user2 , user3  };
        foreach (var usr in users)
        {
            if (usr.ID == idToFind)
            {
                usr.GetInfo();
                break;
            }
        }
    }
    else if (coice == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice. Please try again.");
        Console.WriteLine("Enter 1 to display all users, 2 to find a user by ID, or 3 to exit:");
        Console.ReadLine();
    }


}
