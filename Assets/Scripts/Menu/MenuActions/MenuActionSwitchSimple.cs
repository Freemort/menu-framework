using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Switch_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuSwitchAction", order = 1)]
    public class MenuActionSwitchSimple : MenuActionSwitchBase
    {
        protected override void ActionProceed()
        {
            ActionBegin();
            ActionFinish();
        }

        protected override void ActionBegin()
        {
            parentMenu.CloseBegin();

            targetMenu.gameObject.SetActive(true);
            targetMenu.OpenBegin(parentMenu);
        }

        protected override void ActionFinish()
        {
            parentMenu.CloseFinish();
            parentMenu.gameObject.SetActive(false);

            targetMenu.OpenFinish();

            base.ActionFinish();
        }

        public override void StopAction()
        {
            base.StopAction();
        }
    }
}