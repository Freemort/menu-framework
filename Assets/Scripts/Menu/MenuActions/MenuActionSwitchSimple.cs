using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Switch_Simple", menuName = "ScriptableObjects/MenuActions/Spawn_MenuSwitchAction", order = 1)]
public class MenuActionSwitchSimple : MenuActionSwitchBase
{
    protected override void ActionProceed()
    {
        CloseBegin();
        CloseFinish();

        OpenBegin();
        OpenFinish();
    }

    protected override void CloseBegin()
    {
        parentMenu.CloseBegin();
    }

    protected override void CloseFinish()
    {
        parentMenu.CloseFinish();
        parentMenu.gameObject.SetActive(false);
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