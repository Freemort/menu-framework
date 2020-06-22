using System.Threading.Tasks;
using UnityEngine;

public abstract class MenuActionSwitchBase : MenuActionBase
{
    protected override void ManageHistory()
    {
        MenuBase.menuHistory.Add(targetMenu);
        MenuBase.menuHistory.RemoveFromChilds(targetMenu);
    }

    protected abstract void OpenBegin();
    protected abstract void OpenFinish();
    protected abstract void CloseBegin();
    protected abstract void CloseFinish();
}