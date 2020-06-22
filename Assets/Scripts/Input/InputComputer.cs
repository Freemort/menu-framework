using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComputer : InputBase
{
    public InputComputer(InputController input): base(input)
    {
    }

    public override void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            inputController.Command_Back();
        }
    }
}