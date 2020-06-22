using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum SliderType
{
    FromLeft,
    FromRight,
    FromDown,
    FromUp
}

[CreateAssetMenu(fileName = "Open_Slide", menuName = "ScriptableObjects/MenuActions/Spawn_MenuOpenSlide", order = 1)]
public class MenuActionOpenSlide : MenuActionOpenBase
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

    public override void StopAction()
    {
    }

    public override void EditorLogic()
    {
        sliderType = (SliderType)EditorGUILayout.EnumPopup("Slider Type: ", sliderType);
    }
}