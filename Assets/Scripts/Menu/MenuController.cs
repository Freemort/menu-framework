using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    private MenuHistory menuHistory;
    public MenuHistory MenuHistory
    {
        get
        {
            if (menuHistory == null)
                menuHistory = new MenuHistory();
            return menuHistory;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}