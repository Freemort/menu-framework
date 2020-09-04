using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MutatronicMenues
{
    [CreateAssetMenu(fileName = "Switch_Slide", menuName = "ScriptableObjects/MenuActions/Spawn_MenuSwitchSlide", order = 1)]
    public class MenuActionSwitchSlide : MenuActionSwitchBase
    {
        public SliderType sliderType;

        protected override void ActionProceed()
        {
            AnimationsBinder binder = new AnimationsBinder(AnimBinderType.Simultaneously, GetAnimClose(), GetOpenAnim());
            binder.StartAnimations();
            OpenBegin();
            CloseBegin();
        }

        private AnimationActionBase GetOpenAnim()
        {
            var rectTransform = targetMenu.gameObject.GetComponent<RectTransform>();
            var slideAnimOpen = MenuOpenSlideAnim.CreateInstance<MenuOpenSlideAnim>();
            slideAnimOpen.Init(rectTransform, OpenFinish, sliderType);
            return slideAnimOpen;
        }

        private AnimationActionBase GetAnimClose()
        {
            SliderType closeSliderType;
            switch (sliderType)
            {
                case SliderType.Left:
                    closeSliderType = SliderType.Right;
                    break;
                case SliderType.Right:
                    closeSliderType = SliderType.Left;
                    break;
                case SliderType.Down:
                    closeSliderType = SliderType.Up;
                    break;
                case SliderType.Up:
                    closeSliderType = SliderType.Down;
                    break;
                default:
                    closeSliderType = SliderType.Right;
                    break;
            }

            var rectTransform = parentMenu.gameObject.GetComponent<RectTransform>();
            var slideAnimClose = MenuCloseSlideAnim.CreateInstance<MenuCloseSlideAnim>();
            slideAnimClose.Init(rectTransform, CloseFinish, closeSliderType);
            return slideAnimClose;
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

        protected override void CloseBegin()
        {
            parentMenu.CloseBegin();
        }

        protected override void CloseFinish()
        {
            parentMenu.gameObject.SetActive(false);
            parentMenu.CloseFinish();
        }

        //public override void StopAction()
        //{
        //}

        public override void EditorLogic()
        {
            sliderType = (SliderType)EditorGUILayout.EnumPopup("Slider Type: ", sliderType);
        }
    }
}