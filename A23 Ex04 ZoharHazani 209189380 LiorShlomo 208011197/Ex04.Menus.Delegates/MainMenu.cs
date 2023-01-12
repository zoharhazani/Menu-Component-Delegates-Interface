using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;

        //Ctor
        public MainMenu()
        {
            MenuItem = new MenuItem();
            MenuItem.NameOfSection = "Main Menu Delegates";
        }

        //Get Set 
        public MenuItem MenuItem
        {
            get
            {
                return m_MenuItem;
            }
            set
            {
                m_MenuItem = value;
            }
        }

        public void Show(List<MenuItem> i_SubMenu)
        {
            bool isMenuInUse = true;
            StringBuilder showMenuSB;

            while (isMenuInUse == true)
            {
                showMenuSB = new StringBuilder();
                bool isMainRoot = false;

                //Display the name of the speicifc menu
                showMenuSB.Append(i_SubMenu[0].Parent.NameOfSection);
                showMenuSB.Append("\n");
                showMenuSB.Append("=========================\n");

                //Display menu options
                for (int i = 0; i < i_SubMenu.Count; i++)
                {
                    showMenuSB.Append(i + 1);
                    showMenuSB.Append(". ");
                    showMenuSB.Append(i_SubMenu[i].NameOfSection);
                    showMenuSB.Append("\n");
                }

                if (i_SubMenu[0].Parent.Parent != null)
                {
                    showMenuSB.Append("0. Back\n");
                    showMenuSB.Append(string.Format("Enter your choice (1-{0}) or 0 to the previous menu:\n", i_SubMenu.Count));
                }

                else
                {
                    showMenuSB.Append("0. Exit\n");
                    showMenuSB.Append(string.Format("Enter your choice (1-{0}) or 0 to Exit:\n", i_SubMenu.Count));
                    isMainRoot = true;
                }

                showMenuSB.Append(">> ");
                Console.Write(showMenuSB.ToString());

                //Get user input
                int userChoice = getUserInput(i_SubMenu.Count);

                // if 0 is entered :
                //- Exit if its the mainRoot
                //- back to previous menu if its not
                if (userChoice == 0)
                {
                    if (isMainRoot == false)
                    {
                        NavigateUp(i_SubMenu[0]);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You chose to Exit, GoodBye (: ");
                        isMenuInUse = false;
                        Environment.Exit(0);

                    }

                }

                //Navigate Down 
                if (i_SubMenu[userChoice - 1].ChosenSection() == false)
                {
                    i_SubMenu = i_SubMenu[userChoice - 1].SubMenu;
                }

            }
        }
       
        private void NavigateUp(MenuItem i_Item)
        {
            Show(i_Item.Parent.Parent.SubMenu);
        }

        private int getUserInput(int i_CountSubMenu)
        {
            string userChoiceString = Console.ReadLine();
            while (validateFormatInputUser(userChoiceString) == false || validateRangeOfUserInput(int.Parse(userChoiceString), i_CountSubMenu) == false)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Console.Write(">> ");
                userChoiceString = Console.ReadLine();
            }

            int userChoiceNumber = int.Parse(userChoiceString);
            return userChoiceNumber;
        }

        private bool validateFormatInputUser(string i_UserInput)
        {
            bool isFormatValid;
            int userChoice;
            try
            {
                if (int.TryParse(i_UserInput, out userChoice) == false)
                {
                    throw new FormatException("This input is in valid");
                }
                else
                {
                    isFormatValid = true;
                }

            }

            catch (FormatException)
            {
                isFormatValid = false;
            }
            return isFormatValid;
        }

        private bool validateRangeOfUserInput(int i_UserInput, int i_CountSubMenu)
        {
            bool isValidRange = true;
            if (i_UserInput < 0 || i_UserInput > i_CountSubMenu)
            {
                isValidRange = false;
            }

            return isValidRange;
        }
    }
}

