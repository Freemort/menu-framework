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
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            actions[i]?.Invoke();
            actions.RemoveAt(i);
        }
    }

    public static void AddAction(Action action) 
    {
        Instance.actions.Add(action);
    }
}