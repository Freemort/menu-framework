using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Close_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuCloseAction", order = 1)]
    public class MenuActionCloseSimple : MenuActionCloseBase
    {
        protected override void ActionProceed()
        {
            ActionBegin();
            ActionFinish();
        }

        protected override void ActionBegin()
        {
            targetMenu.CloseBegin();
        }

        protected override void ActionFinish()
        {
            targetMenu.CloseFinish();
            targetMenu.DisableChilds();
            targetMenu.gameObject.SetActive(false);

            base.ActionFinish();
        }

        public override void StopAction()
        {
            base.StopAction();
        }
    }
}