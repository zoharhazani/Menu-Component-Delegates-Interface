using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Test
{
    class UsersMethods
    {
        public void ShowVersion()
        {
            Console.WriteLine("Version 23.1.4.8859");
        }

        public void CountUpperCase()
        {
            Console.WriteLine("Please enter some statment in english");
            string userChoise = Console.ReadLine();
            int countOfUpperCase = CountUpperCase(userChoise);
            Console.WriteLine("There are {0} UpperCases in your statment.", countOfUpperCase);
        }

        public void ShowDate()
        {
            Console.WriteLine(ReturnDate());
        }

        public void ShowTime()
        {
            Console.WriteLine(ReturnTime());
        }

        private int CountUpperCase(string i_UserInput)
        {
            int count = 0;

            foreach (char c in i_UserInput)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }

            }

            return count;
        }

        private string ReturnDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        private string ReturnTime()
        {
            return DateTime.Now.ToString("hh:mm:ss tt");
        }

    }
}
