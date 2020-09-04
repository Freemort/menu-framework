using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace MutatronicMenues
{
    [CustomEditor(typeof(MenuNavigator))]
    public class MenuSwitchButtonEditor : Editor
    {
        private MenuNavigator button;

        private void Awake()
        {
            button = (MenuNavigator)target;
            if (button.parentMenu == null)
                button.parentMenu = FindParent();
        }

        private MenuBase FindParent(Transform childObject = null)
        {
            Transform transform = childObject;
            if (transform == null)
                transform = button.transform;

            while (transform.parent != null)
            {
                if (transform.gameObject.GetComponent<MenuBase>() != null)
                    return transform.gameObject.GetComponent<MenuBase>();

                transform = transform.parent;
            }

            return null;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EnumField(ref button.switchType, "Action Type:");

            switch (button.switchType)
            {
                case SwitchType.None:
                    button.SetMenuAction(null);
                    break;
                case SwitchType.Open:
                    OpenLogic();
                    break;
                case SwitchType.Close:
                    CloseLogic();
                    break;
                case SwitchType.Switch:
                    SwitchLogic();
                    break;
                default:
                    break;
            }

            if (button.Action != null)
                button.Action.EditorLogic();

            serializedObject.ApplyModifiedProperties();
        }

        private void OpenLogic()
        {
            ChoseActionLogic<MenuActionOpenBase>();
            if (button.Action == null)
                return;

            ObjectField(ref button.parentMenu, "Parent menu:");
            ObjectField(ref button.targetMenu, "Menu to open:");
        }
        private void CloseLogic()
        {
            ChoseActionLogic<MenuActionCloseBase>();
            if (button.Action == null)
                return;

            ObjectField(ref button.parentMenu, "Parent menu:");
            ObjectField(ref button.targetMenu, "Menu to close:");
        }
        private void SwitchLogic()
        {
            ChoseActionLogic<MenuActionSwitchBase>();
            if (button.Action == null)
                return;

            ObjectField(ref button.parentMenu, "Switch from menu:");
            ObjectField(ref button.targetMenu, "Switch to menu:");
        }

        private void ChoseActionLogic<T>() where T : MenuActionBase
        {
            if (button.GetActionType() != null)
                if (button.GetActionType().IsSubclassOf(typeof(T)) == false)
                {
                    button.SetMenuAction(null);
                }

            SetActionField<T>("Action Effect:");
        }

        private void SetActionField<T>(string label, bool searchInScene = true) where T : MenuActionBase
        {
            var fieldValue = (T)EditorGUILayout.ObjectField(label, button.Action, typeof(T), searchInScene);
            button.SetMenuAction(fieldValue);
        }
        private void ObjectField<T>(ref T reference, string label, bool searchInScene = true) where T : UnityEngine.Object
        {
            reference = (T)EditorGUILayout.ObjectField(label, reference, typeof(T), searchInScene);
        }

        private void EnumField<T>(ref T anyEnum, string label) where T : Enum
        {
            anyEnum = (T)EditorGUILayout.EnumPopup(label, anyEnum);
        }
    }
}