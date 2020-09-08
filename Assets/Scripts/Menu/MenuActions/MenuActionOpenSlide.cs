using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MutatronicMenues
{
    public enum SliderType
    {
        Left,
        Right,
        Down,
        Up
    }

    [CreateAssetMenu(fileName = "Open_Slide", menuName = "ScriptableObjects/MenuActions/Spawn_MenuOpenSlide", order = 1)]
    public class MenuActionOpenSlide : MenuActionOpenBase
    {
        public MenuOpenSlideAnim slideAnim;
        public SliderType sliderType;

        protected override void ActionProceed()
        {
            ActionBegin();
        }

        protected override void ActionBegin()
        {
            targetMenu.gameObject.SetActive(true);
            targetMenu.OpenBegin(parentMenu);
            var rectTransform = targetMenu.gameObject.GetComponent<RectTransform>();
            slideAnim = MenuOpenSlideAnim.CreateInstance<MenuOpenSlideAnim>();
            slideAnim.Init(rectTransform, ActionFinish, sliderType, tokenSource.Token);
            slideAnim.AnimStart();
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

        public override void EditorLogic()
        {
            sliderType = (SliderType)EditorGUILayout.EnumPopup("Slider Type: ", sliderType);
        }
    }
}