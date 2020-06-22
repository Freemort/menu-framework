using System.Threading.Tasks;

public abstract class MenuActionCloseBase : MenuActionBase
{
    protected override void ManageHistory()
    {
        MenuBase.menuHistory.RemoveFromChilds(targetMenu, true);
    }

    protected abstract void CloseBegin();
    protected abstract void CloseFinish();
}