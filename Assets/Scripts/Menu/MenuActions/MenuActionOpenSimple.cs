using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Open_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuOpenAction", order = 1)]
    public class MenuActionOpenSimple : MenuActionOpenBase
    {
        protected override void ActionProceed()
        {
            OpenBegin();
            OpenFinish();
        }

        protected override void OpenBegin()
        {
            targetMenu.gameObject.SetActive(true);
            targetMenu.OpenBegin(parentMenu);
        }

        protected override void OpenFinish()
        {
            targetMenu.OpenFinish();
        }

        public override void StopAction()
        {
            base.StopAction();
        }
    }
}