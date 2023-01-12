using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_NameOfSection;
        private MenuItem m_Parent;
        private List<MenuItem> m_SubMenu;
        public event Action Chosen;

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

        //Ctor
        public MenuItem(string i_Name, Action i_Action)
        {
            NameOfSection = i_Name;
            Chosen = i_Action;
            SubMenu = new List<MenuItem>();
        }

        public MenuItem()
        {
            SubMenu = new List<MenuItem>();
        }

        public bool ChosenSection()
        {
            bool hasAMethod;

            if (this.SubMenu.Count > 0)
            {
                hasAMethod = false;
            }
            else
            {
                hasAMethod = true;
                OnChosen();
            }

            return hasAMethod;

        }

        protected virtual void OnChosen()
        {
            if (Chosen != null)
            {
                Chosen.Invoke();
            }
        }

        public void AddMenuItem(MenuItem i_Item)
        {
            i_Item.Parent = this;
            SubMenu.Add(i_Item);
        }
    }    
}
