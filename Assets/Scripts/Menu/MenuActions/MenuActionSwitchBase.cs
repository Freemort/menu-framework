using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    public abstract class MenuActionSwitchBase : MenuActionBase
    {
        protected override void ManageHistory()
        {
            MenuController.MenuHistory.Add(targetMenu);
            MenuController.MenuHistory.RemoveFromChilds(targetMenu);
        }
    }
}