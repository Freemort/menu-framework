using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    public abstract class AnimationActionBase : ScriptableObject
    {
        protected RectTransform transform;
        protected Action postAction;
        protected float timer;

        public Func<Task> AwaiterAction;

        private float animProgress;
        protected Action animAction;

        public float AnimProgress
        {
            get => animProgress;
            set
            {
                animProgress = value;
                animAction();
            }
        }

        public virtual async void AnimStart()
        {
            await Animation();
            AnimFinish();
        }

        /// <summary>
        /// By design should be async.
        /// </summary>
        /// <returns></returns>
        protected abstract Task<float> Animation();

        protected virtual void AnimFinish()
        {
            postAction?.Invoke();
        }
    }
}