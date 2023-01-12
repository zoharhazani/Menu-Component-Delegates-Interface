using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ManageMenuInterface 
    {
        MainMenu m_TheMainMenu;

        //Ctor
        public ManageMenuInterface()
        {
            m_TheMainMenu = new MainMenu();
            BuildMenu();            
        }

        //Get Set
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

        public void BuildMenu()
        {
            //Add to the mainmenu item 1
            TheMainMenu.MenuItem.AddMenuItem(new MenuItem("Version and Uppercase"));

            //Add sub menu to item 1
            TheMainMenu.MenuItem.SubMenu[0].AddMenuItem(new MenuItem("Show Version", new ShowVersion()));
            TheMainMenu.MenuItem.SubMenu[0].AddMenuItem(new MenuItem("CountUpperCase", new CountUpperCase()));

            //Add to the mainmenu item 2
            TheMainMenu.MenuItem.AddMenuItem(new MenuItem("Show date/time"));

            //Add sub menu to item 2
            TheMainMenu.MenuItem.SubMenu[1].AddMenuItem(new MenuItem("Show Date", new ShowDate()));
            TheMainMenu.MenuItem.SubMenu[1].AddMenuItem(new MenuItem("Show Time", new ShowTime()));

            // Show menu
            TheMainMenu.Show(m_TheMainMenu.MenuItem.SubMenu);
        }           
    }
}
