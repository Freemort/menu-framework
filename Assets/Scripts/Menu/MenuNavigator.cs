using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum SwitchType
{
    None,
    Open,
    Close,
    Switch
}

[RequireComponent(typeof(Button))]
public class MenuNavigator : MonoBehaviour
{
    [SerializeField] private MenuActionBase action;
    public MenuActionBase Action 
    { 
        get { return action; } 
        private set { action = value; } 
    }

    public SwitchType switchType;

    public MenuBase parentMenu;
    public MenuBase targetMenu;

    private Button button;

    private void Awake()
    {
        UnityAction someAction = null;
        someAction = () => action.ActionStart(parentMenu, targetMenu);

        if (someAction == null)
        {
            Debug.LogError("Button action is empty! " + gameObject.name);
            return;
        }

        button = GetComponent<Button>();
        button.onClick.RemoveListener(someAction);
        button.onClick.AddListener(someAction);
    }

    public void SetMenuAction(MenuActionBase newAction)
    {
        if (newAction == null)
        {
            action = null;
            return;
        }

        if (newAction == action) 
            return;

        action = (MenuActionBase)MenuActionBase.CreateInstance(newAction.GetType());
    }

    public Type GetActionType() 
    {
        if (action == null)
            return null;
        return action.GetType();
    }
}
