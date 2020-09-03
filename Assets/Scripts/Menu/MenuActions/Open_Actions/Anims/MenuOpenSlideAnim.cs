using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Anim_OpenSlide", menuName = "ScriptableObjects/MenuAnims/Spawn_Anim_OpenSlide", order = 1)]
public class MenuOpenSlideAnim : AnimationActionBase
{
    private SliderType sliderType;

    public void Init(RectTransform transform, Action action, SliderType sliderType) 
    {
        postAction = action;
        timer = 1f;
        this.transform = transform;
        this.sliderType = sliderType;
        animAction = GetSlideType();
        AnimProgress = 0f;
    }

    protected override async Task<float> Animation()
    {
        AnimProgress = 0f;
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
             await AnimStep(i);
        }
        AnimProgress = 1f;

        return AnimProgress;
    }

    private Action GetSlideType()
    {
        Action action1;
        switch (sliderType)
        {
            case SliderType.Left:
                action1 = () => Left();
                break;
            case SliderType.Right:
                action1 = () => Right();
                break;
            case SliderType.Down:
                action1 = () => Down();
                break;
            case SliderType.Up:
                action1 = () => Up();
                break;
            default:
                action1 = () => Left();
                break;
        }

        return action1;
    }

    private async Task AnimStep(float i)
    {
        if (i > 0)
            AnimProgress = i / timer;
        if (AnimProgress > 1)
            AnimProgress = 1;

        if (AwaiterAction != null)
            await AwaiterAction();
        else
            await Task.Yield();
    }

    private void Left() 
    {
        transform.anchorMin = new Vector2(AnimProgress - 1f, 0f);
        transform.anchorMax = new Vector2(AnimProgress, 1f);
    }
    private void Right() 
    {
        transform.anchorMin = new Vector2(1f - AnimProgress, 0f);
        transform.anchorMax = new Vector2(2f - AnimProgress, 1f);
    }
    private void Down()
    {
        transform.anchorMin = new Vector2(0f, AnimProgress - 1f);
        transform.anchorMax = new Vector2(1f, AnimProgress);
    }
    private void Up() 
    {
        transform.anchorMin = new Vector2(0f, 1f - AnimProgress);
        transform.anchorMax = new Vector2(1f, 2f - AnimProgress);
    }

}