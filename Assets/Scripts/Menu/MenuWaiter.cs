

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MenuWaiter : MenuBase
{
    protected override void Awaiters()
    {
        Thread.Sleep(5000);
    }
}