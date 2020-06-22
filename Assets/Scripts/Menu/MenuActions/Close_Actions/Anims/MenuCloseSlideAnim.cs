using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MenuCloseSlideAnim : ScriptableObject
{
    private RectTransform transform;
    private float timer;
    private SliderType sliderType;

    public void StartAnim(RectTransform transform, Action action, SliderType sliderType)
    {
        timer = 1f;
        this.transform = transform;
        this.sliderType = sliderType;

        Animation(action);
    }

    private async void Animation(Action action)
    {
        Action action1;
        float tmp = 0;
        switch (sliderType)
        {
            case SliderType.FromLeft:
                action1 = () => Left(tmp);
                break;
            case SliderType.FromRight:
                action1 = () => Right(tmp);
                break;
            case SliderType.FromDown:
                action1 = () => Down(tmp);
                break;
            case SliderType.FromUp:
                action1 = () => Up(tmp);
                break;
            default:
                action1 = () => Left(tmp);
                break;
        }


        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            if (i > 0)
                tmp = i / timer;
            if (tmp > 1)
                tmp = 1;

            action1();

            await Task.Yield();
        }

        tmp = 1f;
        action1();

        action?.Invoke();
    }

    private void Left(float tmp)
    {
        transform.anchorMin = new Vector2(0f - tmp, 0f);
        transform.anchorMax = new Vector2(1f - tmp, 1f);
    }
    private void Right(float tmp)
    {
        transform.anchorMin = new Vector2(tmp, 0f);
        transform.anchorMax = new Vector2(1f + tmp, 1f);
    }
    private void Down(float tmp)
    {
        transform.anchorMin = new Vector2(0f, 0f - tmp);
        transform.anchorMax = new Vector2(1f, 1f - tmp);
    }
    private void Up(float tmp)
    {
        transform.anchorMin = new Vector2(0f, 0f + tmp);
        transform.anchorMax = new Vector2(1f, 1f + tmp);
    }

}