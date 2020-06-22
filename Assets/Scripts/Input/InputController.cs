using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private InputBase input;

    private void Awake()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                input = new InputAndroid(this);
                break;
            default:
                input = new InputComputer(this);
                break;
        }
    }

    private void Update()
    {
        input.Update();
    }

    public void Command_Back() 
    {
        MenuBase.Back();
    }
}