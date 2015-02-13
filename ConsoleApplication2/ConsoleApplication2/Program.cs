using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string login = "TestLogin";
            string name = "TestName";
            string surname = "TestSurname";
            int age = 25;
            User TestUser = new User( login,  name,  surname,  age);
            Console.WriteLine("TestUser");
            Console.WriteLine("Name: {0}", TestUser.Name);
            Console.WriteLine("Surname: {0}", TestUser.Surname);
            Console.WriteLine("Login: {0}", TestUser.Login);
            Console.WriteLine("Age: {0}", TestUser.Age);
            Console.WriteLine("Creation date: {0}", TestUser.Created);
            Console.ReadKey();
        }
    }
}
