using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Close_Slide", menuName = "ScriptableObjects/MenuActions/Spawn_MenuCloseSlide", order = 1)]
    public class MenuActionCloseSlide : MenuActionCloseBase
    {
        public MenuCloseSlideAnim slideAnim;
        public SliderType sliderType;

        protected override void ActionProceed()
        {
            ActionBegin();
        }

        protected override void ActionBegin()
        {
            targetMenu.gameObject.SetActive(true);
            targetMenu.CloseBegin();

            var rectTransform = targetMenu.gameObject.GetComponent<RectTransform>();
            slideAnim = MenuCloseSlideAnim.CreateInstance<MenuCloseSlideAnim>();
            slideAnim.Init(rectTransform, ActionFinish, sliderType, tokenSource.Token);
            slideAnim.AnimStart();
        }

        protected override void ActionFinish()
        {
            targetMenu.CloseFinish();
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