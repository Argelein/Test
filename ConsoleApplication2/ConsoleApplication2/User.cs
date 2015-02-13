using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class User
    {
        string login, name, surname;
        int age;
        readonly DateTime created;

        public User(string login, string name, string surname, int age)
        {
            this.login = login;
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.created = DateTime.Now;
        }

        public string Login
        {
            get { return login;}
        }
        public string Name
        {
            get { return name;}
        }
        public string Surname
        {
            get { return surname;}
        }
        public int Age
        {
            get { return age;}
        }
        public DateTime Created
        {
            get { return created;}
        }
    }
}
