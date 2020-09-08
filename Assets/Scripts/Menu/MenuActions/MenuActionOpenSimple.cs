using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Open_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuOpenAction", order = 1)]
    public class MenuActionOpenSimple : MenuActionOpenBase
    {
        protected override void ActionProceed()
        {
            ActionBegin();
            ActionFinish();
        }

        protected override void ActionBegin()
        {
            targetMenu.gameObject.SetActive(true);
            targetMenu.OpenBegin(parentMenu);
        }

        protected override void ActionFinish()
        {
            targetMenu.OpenFinish();
            base.ActionFinish();
        }

        public override void StopAction()
        {
            base.StopAction();
        }
    }
}