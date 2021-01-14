using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MutatronicMenues
{
    [System.Serializable]
    public class MenuHistory : List<MenuBase>
    {
        public new void Add(MenuBase menuBase)
        {
            if (base.Contains(menuBase))
                return;

            base.Add(menuBase);
        }

        public void RemoveFromChilds(MenuBase menuBase, bool includeParent = false)
        {
            List<MenuBase> menuChilds = menuBase.menuChilds;
            foreach (var item in menuChilds)
            {
                base.Remove(item);
                RemoveFromChilds(item);
            }
            if (includeParent)
                base.Remove(menuBase);
        }
    }
}