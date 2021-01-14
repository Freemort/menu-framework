using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace MutatronicMenues
{
    public enum AnimBinderType
    {
        Simultaneously,
        Chained
    }

    public class AnimationsBinder
    {
        private AnimationActionBase[] animationAction;
        private AnimBinderType animBinderType;

        public AnimationsBinder(AnimBinderType animBinderType, params AnimationActionBase[] animations)
        {
            this.animBinderType = animBinderType;
            animationAction = animations;

            if (animations.Length <= 1)
                return;

            if (animBinderType == AnimBinderType.Simultaneously)
            {
                foreach (var item in animations)
                {
                    item.AwaiterAction = () => Awaiter(animations.Length);
                }
            }

        }

        private Mutex mutexObj = new Mutex();
        public async Task Awaiter(int i)
        {
            mutexObj.WaitOne();

            await Task.Yield();

            mutexObj.ReleaseMutex();
        }

        public async void StartAnimations()
        {
            foreach (var item in animationAction)
            {
                if (animBinderType == AnimBinderType.Simultaneously)
                    item.AnimStart();
                else if (animBinderType == AnimBinderType.Chained)
                    await Task.Run( () => item.AnimStart());
            }
        }
    }
}