using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Anim_OpenSlide", menuName = "ScriptableObjects/MenuAnims/Spawn_Anim_OpenSlide", order = 1)]
public class MenuOpenSlideAnim: ScriptableObject
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
            case SliderType.Left:
                action1 = () => Left(tmp);
                break;
            case SliderType.Right:
                action1 = () => Right(tmp);
                break;
            case SliderType.Down:
                action1 = () => Down(tmp);
                break;
            case SliderType.Up:
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
        transform.anchorMin = new Vector2(tmp - 1f, 0f);
        transform.anchorMax = new Vector2(tmp, 1f);
    }
    private void Right(float tmp) 
    {
        transform.anchorMin = new Vector2(1f - tmp, 0f);
        transform.anchorMax = new Vector2(2f - tmp, 1f);
    }
    private void Down(float tmp)
    {
        transform.anchorMin = new Vector2(0f, tmp - 1f);
        transform.anchorMax = new Vector2(1f, tmp);
    }
    private void Up(float tmp) 
    {
        transform.anchorMin = new Vector2(0f, 1f - tmp);
        transform.anchorMax = new Vector2(1f, 2f - tmp);
    }

}