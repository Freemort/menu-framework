using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    [System.Serializable]
    public abstract class MenuActionBase : ScriptableObject
    {
        protected MenuBase parentMenu;
        protected MenuBase targetMenu;

        public static MenuActionBase currentAction;

        protected CancellationTokenSource tokenSource;

        public virtual void StopAction()
        {
            tokenSource.Cancel();
            Debug.LogWarning("Works");
        }

        public async void ActionStart(MenuBase parentMenu, MenuBase targetMenu)
        {
            this.parentMenu = parentMenu;
            this.targetMenu = targetMenu;

            currentAction = this;

            tokenSource = new CancellationTokenSource();
            if (targetMenu.awaiterType == AwaiterRunType.Await)
            {
                if (targetMenu.loadingScreen != null)
                    await Task.Run(() => targetMenu.AwaitersBegin(tokenSource.Token));
            }
            else
            {
#pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
                if (targetMenu.loadingScreen != null)
                    Task.Run(() => targetMenu.AwaitersBegin(tokenSource.Token));
#pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до тех пор, пока вызов не будет завершен
            }

            ManageHistory();
            ActionProceed();
            ActionFinish();
        }

        protected virtual void ActionFinish()
        {
            currentAction = null;
            Debug.LogError("Finish");
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
}