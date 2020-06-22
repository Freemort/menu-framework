using System.Threading.Tasks;

public abstract class MenuActionOpenBase : MenuActionBase
{
    protected override void ManageHistory()
    {
        MenuBase.menuHistory.Add(targetMenu);
    }

    protected abstract void OpenBegin();
    protected abstract void OpenFinish();
}