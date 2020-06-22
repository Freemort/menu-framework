using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ActionScheduler : MonoBehaviour
{
    public static ActionScheduler Instance { get; private set; }

    private List<Action> actions;

    private void Awake()
    {
        actions = new List<Action>();
        Instance = this;
    }

    void Update()
    {
        while (actions.Count > 0) 
        {
            actions[0]?.Invoke();
            actions.RemoveAt(0);
        }
    }

    public static void AddAction(Action action) 
    {
        Instance.actions.Add(action);
    }
}