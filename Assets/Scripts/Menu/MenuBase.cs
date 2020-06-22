using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public enum AwaiterRunType
{
    Await,
    Background
}

[System.Serializable]
[RequireComponent(typeof(CanvasGroup))]
public abstract class MenuBase: MonoBehaviour
{
    public static MenuHistory menuHistory { get; set; }
    public List<MenuBase> menuChilds;
    private MenuBase parent;
    private CanvasGroup canvasGroup;

    public Button backButton;
    public bool ignoreParenting;

    [Header("Awaiter Settings")]
    public AwaiterRunType awaiterType;
    public GameObject loadingScreen;

    private void Awake()
    {
        menuChilds = new List<MenuBase>();
        canvasGroup = GetComponent<CanvasGroup>();

        if(menuHistory == null)
            menuHistory = MenuController.instance.MenuHistory;
    }

    /// <summary>
    /// Scheduled/async code goes here. For manipulating Unity objects use "ActionScheduler.AddAction()".
    /// </summary>
    protected virtual void Awaiters() { }
    public virtual void AwaitersBegin() 
    {
        //Need to remake loading screen logic entirely
        Debug.LogWarning("WIP");
        ActionScheduler.AddAction(() => loadingScreen.SetActive(true));
        Awaiters();
        AwaitersFinish();
    }
    protected virtual void AwaitersFinish() 
    {
        Debug.LogWarning("WIP");
        ActionScheduler.AddAction(() => loadingScreen.SetActive(false)); 
    }

    public virtual void OpenBegin(MenuBase openedFrom) 
    {
        canvasGroup.interactable = false;

        if (ignoreParenting)
            return;
      
        parent = openedFrom;
        if (parent.menuChilds.Contains(this) == false)
            parent.menuChilds.Add(this);
    }
    public virtual void OpenFinish() 
    {
        canvasGroup.interactable = true;
    }

    public virtual void CloseBegin() 
    {
        canvasGroup.interactable = false;
    }
    public virtual void CloseFinish() 
    {
        //DisableChilds();
        canvasGroup.interactable = true;
    }

    public virtual void DisableChilds()
    {
        for (int i = 0; i < menuChilds.Count; i++)
        {
            menuChilds[i].CloseBegin();
            menuChilds[i].CloseFinish();
        }
        gameObject.SetActive(false);
    }

    public virtual void Reset() { }

    public static void Back() 
    {
        if (menuHistory == null)
            return;

        if (menuHistory.Count == 0)
            return;

        MenuBase lastMenu = menuHistory[menuHistory.Count - 1];
        lastMenu.backButton?.onClick.Invoke();
    }
}