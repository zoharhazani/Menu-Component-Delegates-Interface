using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class ManageMenuDelegates
    {
        MainMenu m_TheMainMenu;

        public MainMenu TheMainMenu
        {
            get
            {
                return m_TheMainMenu;
            }
            set
            {
                m_TheMainMenu = value;
            }
        }

        public ManageMenuDelegates()
        {
            TheMainMenu = new MainMenu();
            BuildMenu();
        }

        public void BuildMenu()
        {
            //Add menu items 1
            TheMainMenu.MenuItem.AddMenuItem(new MenuItem("Version and Uppercase", null));

            //Add sub menu to item 1
            TheMainMenu.MenuItem.SubMenu[0].AddMenuItem(new MenuItem("Show Version", ShowVersion));
            TheMainMenu.MenuItem.SubMenu[0].AddMenuItem(new MenuItem("CountUpperCase", CountUpperCase));

            //Add menu items 2
            TheMainMenu.MenuItem.AddMenuItem(new MenuItem("Show date/time", null));

            //Add sub menu to item 2
            TheMainMenu.MenuItem.SubMenu[1].AddMenuItem(new MenuItem("Show Date", ShowDate));
            TheMainMenu.MenuItem.SubMenu[1].AddMenuItem(new MenuItem("Show Time", ShowTime));

            // Show menu
            TheMainMenu.Show(m_TheMainMenu.MenuItem.SubMenu);
        }

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
