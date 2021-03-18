using System;
using System.Data.SqlClient;

namespace AssassinsCreed
{
    class Program
    {
        static void Main()
        {
            Assassins a = new Assassins();
            char ans;
            try
            {
                do
                {
                    Console.WriteLine("ASSASSIN's CREED\n");
                    Console.WriteLine("1.Display all Characters");
                    Console.WriteLine("2.Add a new Character");
                    Console.WriteLine("3.Delete a Character");
                    Console.WriteLine("4.Update a Character");
                    Console.WriteLine("5.Search a Character");
                    Console.WriteLine("6. Number of Assassins in the creed");
                    Console.WriteLine("7.Display  all Templars\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            a.RetrieveAllAssassins();
                            break;
                        case 2:
                            Console.WriteLine("Enter the Assassin name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter the Profile name");
                            string profile = Console.ReadLine();
                            Console.WriteLine("Enter the Series name");
                            string series = Console.ReadLine();
                            a.AddCharacter(name, profile, series);
                            break;
                        case 3:
                            a.RetrieveAllAssassins();
                            Console.WriteLine("Enter the Assassin ID to Delete");
                            int id = Convert.ToInt32(Console.ReadLine());
                            a.DeleteCharacter(id);
                            break;
                        case 4:
                            Console.WriteLine("Enter the new Assassin name");
                            string newname = Console.ReadLine();
                            Console.WriteLine("Enter the Assassin ID");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            a.UpdateCharacter(newname, id1);
                            break;
                        case 5:
                            Console.WriteLine("Enter the profile you want to search");
                            string searchProfile = Console.ReadLine();
                            a.SearchCharacter(searchProfile); 
                            break;
                        case 6:
                            a.CountCharacters();
                            break;
                        case 7:
                            a.DisplayTemplars();
                            break;
                    }
                    Console.WriteLine("\nDo you want to continue? y/n");
                    ans = Console.ReadLine()[0];
                } while (ans != 'n');
                }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message, exception.StackTrace);
            }

        }
    }
}
