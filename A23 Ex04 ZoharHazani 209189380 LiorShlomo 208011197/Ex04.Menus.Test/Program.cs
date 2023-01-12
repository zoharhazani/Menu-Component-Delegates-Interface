using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program 
    {
        public static void Main()
        {
            ManageMenuInterface MenuInterface = new ManageMenuInterface();           
            ManageMenuDelegates MenuDelegates = new ManageMenuDelegates();
        }
    }
}
