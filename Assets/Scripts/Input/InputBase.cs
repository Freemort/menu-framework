using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase
{
    protected InputController inputController;

    public InputBase(InputController input)
    {
        inputController = input;
    }

    public abstract void Update();
}