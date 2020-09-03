using System.Threading.Tasks;
using UnityEngine;

public abstract class MenuActionSwitchBase : MenuActionBase
{
    protected override void ManageHistory()
    {
        MenuController.MenuHistory.Add(targetMenu);
        MenuController.MenuHistory.RemoveFromChilds(targetMenu);
    }

    protected abstract void OpenBegin();
    protected abstract void OpenFinish();
    protected abstract void CloseBegin();
    protected abstract void CloseFinish();
}