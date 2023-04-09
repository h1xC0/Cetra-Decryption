using System;
using System.Collections.Generic;
using Codebase.Systems.UnityLifecycle.Ticks;

namespace Codebase.Systems.UnityLifecycle
{
    public class UnityLifecycleService : IUnityLifecycleService
    {
        private readonly List<IAwakeTick> _awakeListeners = new();
        private readonly List<IStartTick> _startListeners = new();
        private readonly List<IUpdateTick> _updateListeners = new();
        private readonly List<IFixedUpdateTick> _fixedUpdateListeners = new();
        private readonly List<ILateUpdateTick> _lateUpdateListeners = new();

        private readonly IUnityLifecycleHandler _lifecycleHandler;
        
        public UnityLifecycleService(IUnityLifecycleHandler lifecycleHandler)
        {
            _lifecycleHandler = lifecycleHandler;
            
            _lifecycleHandler.AwakeTick += OnAwakeTick;
            _lifecycleHandler.StartTick += OnStartTick;
            _lifecycleHandler.UpdateTick += OnUpdateTick;
            _lifecycleHandler.FixedUpdateTick += OnFixedUpdateTick;
            _lifecycleHandler.LateUpdateTick += OnLateUpdateTick;
        }

        public void Subscribe(ITickListener listener)
        {
            switch (listener)
            {
                case IAwakeTick awakeTick:
                    _awakeListeners.Add(awakeTick);
                    break;
                case IFixedUpdateTick fixedUpdateTick:
                    _fixedUpdateListeners.Add(fixedUpdateTick);
                    break;
                case ILateUpdateTick lateUpdateTick:
                    _lateUpdateListeners.Add(lateUpdateTick);
                    break;
                case IStartTick startTick:
                    _startListeners.Add(startTick);
                    break;
                case IUpdateTick updateTick:
                    _updateListeners.Add(updateTick);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(listener));
            }
        }

        public void Unsubscribe(ITickListener listener)
        {
            switch (listener)
            {
                case IAwakeTick awakeTick:
                    _awakeListeners.Remove(awakeTick);
                    break;
                case IFixedUpdateTick fixedUpdateTick:
                    _fixedUpdateListeners.Remove(fixedUpdateTick);
                    break;
                case ILateUpdateTick lateUpdateTick:
                    _lateUpdateListeners.Remove(lateUpdateTick);
                    break;
                case IStartTick startTick:
                    _startListeners.Remove(startTick);
                    break;
                case IUpdateTick updateTick:
                    _updateListeners.Remove(updateTick);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(listener));
            }
        }
        
        private void OnAwakeTick()
        {
            foreach (var awakeTick in _awakeListeners)
            {
                awakeTick.AwakeTick();
            }
        }
        
        private void OnStartTick()
        {
            foreach (var startTick in _startListeners)
            {
                startTick.StartTick();
            }
        }
        
        private void OnUpdateTick()
        {
            foreach (var updateTick in _updateListeners)
            {
                updateTick.UpdateTick();
            }
        }
        
        private void OnFixedUpdateTick()
        {
            foreach (var fixedUpdateTick in _fixedUpdateListeners)
            {
                fixedUpdateTick.FixedUpdateTick();
            }
        }
        
        private void OnLateUpdateTick()
        {
            foreach (var lateUpdateTick in _lateUpdateListeners)
            {
                lateUpdateTick.LateUpdateTick();
            }
        }
        
        public void Dispose()
        {
            _awakeListeners.Clear();
            _startListeners.Clear();
            _updateListeners.Clear();
            _fixedUpdateListeners.Clear();
            _lateUpdateListeners.Clear();
            
            _lifecycleHandler.AwakeTick -= OnAwakeTick;
            _lifecycleHandler.StartTick -= OnStartTick;
            _lifecycleHandler.UpdateTick -= OnUpdateTick;
            _lifecycleHandler.FixedUpdateTick -= OnFixedUpdateTick;
            _lifecycleHandler.LateUpdateTick -= OnLateUpdateTick;
        }
    }
}