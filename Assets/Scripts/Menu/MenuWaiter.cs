

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MenuWaiter : MenuBase
{
    protected override void Awaiters(CancellationToken token)
    {
        for (int i = 0; !token.IsCancellationRequested && i < 5000; i++)
        {
            //if (!Application.isPlaying)
            //    return;

            Thread.Sleep(1);
            Debug.Log(token.IsCancellationRequested);
        }
    }
}