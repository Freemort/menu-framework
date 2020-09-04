using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MutatronicMenues
{
    [ExecuteAlways]
    public class MenuController : MonoBehaviour
    {
        public static MenuController instance;

        private static MenuHistory menuHistory;
        public static MenuHistory MenuHistory
        {
            get
            {
                if (menuHistory == null)
                    menuHistory = new MenuHistory();
                return menuHistory;
            }
        }

        public static void Back()
        {
            MenuActionBase.currentAction?.StopAction();

            if (MenuController.MenuHistory == null)
                return;

            if (MenuController.MenuHistory.Count == 0)
                return;

            MenuBase lastMenu = MenuController.MenuHistory[MenuController.MenuHistory.Count - 1];
            lastMenu.backButton?.onClick.Invoke();
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}