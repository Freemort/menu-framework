using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Close_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuCloseAction", order = 1)]
public class MenuActionCloseSimple : MenuActionCloseBase
{
    protected override void ActionProceed()
    {
        CloseBegin();
        CloseFinish();
    }

    protected override void CloseBegin()
    {
        targetMenu.CloseBegin();
    }

    protected override void CloseFinish()
    {
        targetMenu.CloseFinish();
        targetMenu.gameObject.SetActive(false);
    }

    public override void StopAction()
    {
    }
}
