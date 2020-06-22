using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuActionSwitchSlide : MenuActionSwitchBase
{
    public MenuOpenSlideAnim slideAnim;
    public SliderType sliderType;

    protected override void ActionProceed()
    {
        OpenBegin();
    }

    protected override void OpenBegin()
    {
        targetMenu.gameObject.SetActive(true);
        targetMenu.OpenBegin(parentMenu);

        var rectTransform = targetMenu.gameObject.GetComponent<RectTransform>();
        slideAnim = MenuOpenSlideAnim.CreateInstance<MenuOpenSlideAnim>();
        slideAnim.StartAnim(rectTransform, OpenFinish, sliderType);
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
        parentMenu.CloseFinish();
    }

    public override void StopAction()
    {
    }

    public override void EditorLogic()
    {
        sliderType = (SliderType)EditorGUILayout.EnumPopup("Slider Type: ", sliderType);
    }
}
