using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_NameOfSection;
        private MenuItem m_Parent;
        private readonly IActionMethods r_ActionMethod;
        private List<MenuItem> m_SubMenu;

        //Get Set
        public string NameOfSection
        {
            get
            {
                return m_NameOfSection;
            }
            set
            {

                m_NameOfSection = value;
            }
        }

        public MenuItem Parent
        {
            get
            {
                return m_Parent;
            }
            set
            {
                m_Parent = value;
            }
        }

        public List<MenuItem> SubMenu
        {
            get
            {
                return m_SubMenu;
            }
            set
            {
                m_SubMenu = value;
            }
        }

        public IActionMethods ActionMethod
        {
            get
            {
                return r_ActionMethod;
            }
        }

        //Ctor
        public MenuItem(string i_Name, IActionMethods i_ActionMethod )
        {
            NameOfSection = i_Name;
            r_ActionMethod = i_ActionMethod;
        }

        public MenuItem(string i_Name)
        {
            NameOfSection = i_Name;
            r_ActionMethod = null;
            SubMenu = new List<MenuItem>();
        }

        public MenuItem()
        {
            SubMenu = new List<MenuItem>();
        }
     
        public void AddMenuItem(MenuItem i_Item)
        {
            i_Item.Parent = this;
            SubMenu.Add(i_Item);
        }

        public bool CheckIfHasActionOrSubMenu()
        {
            bool hasSubMenu= false;
            if (ActionMethod == null)
            {
                hasSubMenu = true;
            }

            else
            {
                ActionMethod.ActivateMethod();
            }

            return hasSubMenu;
        }
    }
}
