using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class MenuActionBase: ScriptableObject
{
    protected MenuBase parentMenu;
    protected MenuBase targetMenu;

    protected static MenuActionBase currentAction;
    public abstract void StopAction();

    public async void ActionStart(MenuBase parentMenu, MenuBase targetMenu)
    {
        this.parentMenu = parentMenu;
        this.targetMenu = targetMenu;

        if (targetMenu.awaiterType == AwaiterRunType.Await)
        {
            //Task task = new Task(() => targetMenu.Awaiters());
            //task.Start();
            //task.Wait();

            //targetMenu.loadingScreen.SetActive(true);
            if(targetMenu.loadingScreen != null)
                await Task.Run(() => targetMenu.AwaitersBegin());

            //targetMenu.loadingScreen.SetActive(false);
            //while (targetMenu.isProceeding)
            //{
            //    await Task.Yield();
            //}
        }
        else 
        {
#pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
            if (targetMenu.loadingScreen != null)
                Task.Run(() => targetMenu.AwaitersBegin());
#pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
        }

        ManageHistory();
        ActionProceed();
    }

    protected virtual void ManageHistory()
    {

    }

    protected virtual void ActionProceed() 
    {

    }

    public virtual MenuActionBase GetActionCopy() 
    {
        var type = GetType();
        return (MenuActionBase)CreateInstance(type);
    }

    public virtual void EditorLogic() { }
}
