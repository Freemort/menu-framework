﻿using System.Threading.Tasks;

namespace MutatronicMenues
{
    public abstract class MenuActionCloseBase : MenuActionBase
    {
        protected override void ManageHistory()
        {
            MenuController.MenuHistory.RemoveFromChilds(targetMenu, true);
        }
    }
}