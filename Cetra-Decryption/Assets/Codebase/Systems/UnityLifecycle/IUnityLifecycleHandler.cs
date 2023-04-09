using System;

namespace Codebase.Systems.UnityLifecycle
{
    public interface IUnityLifecycleHandler
    {
        event Action AwakeTick;
        event Action StartTick;   
        event Action UpdateTick;
        event Action FixedUpdateTick;
        event Action LateUpdateTick;
    }
}