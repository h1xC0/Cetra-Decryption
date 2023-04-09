using System;
using UnityEngine;

namespace Codebase.Systems.UnityLifecycle
{
    public class UnityLifecycleHandler : MonoBehaviour, IUnityLifecycleHandler
    {
        public event Action AwakeTick;
        public event Action StartTick;   
        public event Action UpdateTick;
        public event Action FixedUpdateTick;
        public event Action LateUpdateTick;

        private void Awake()
        {
            AwakeTick?.Invoke();
        }

        private void Start()
        {
            StartTick?.Invoke();
        }

        private void Update()
        {
            UpdateTick?.Invoke();
        }

        private void FixedUpdate()
        {
            FixedUpdateTick?.Invoke();
        }

        private void LateUpdate()
        {
            LateUpdateTick?.Invoke();
        }
    }
}