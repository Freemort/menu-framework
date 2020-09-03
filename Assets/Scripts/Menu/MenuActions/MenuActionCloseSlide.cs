using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Close_Slide", menuName = "ScriptableObjects/MenuActions/Spawn_MenuCloseSlide", order = 1)]
public class MenuActionCloseSlide : MenuActionCloseBase
{
    public MenuCloseSlideAnim slideAnim;
    public SliderType sliderType;

    protected override void ActionProceed()
    {
        CloseBegin();
    }

    protected override void CloseBegin()
    {
        targetMenu.gameObject.SetActive(true);
        targetMenu.CloseBegin();

        var rectTransform = targetMenu.gameObject.GetComponent<RectTransform>();
        slideAnim = MenuCloseSlideAnim.CreateInstance<MenuCloseSlideAnim>();
        slideAnim.Init(rectTransform, CloseFinish, sliderType);
        slideAnim.AnimStart();
    }

    protected override void CloseFinish()
    {
        targetMenu.CloseFinish();
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