using UniRx;
using UnityEngine;

namespace Codebase.Systems.MVC
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public CompositeDisposable CompositeDisposable;

        private bool _isInitialized = false;
        
        public void Initialize()
        {
            Setup();
            _isInitialized = true;
        }

        protected virtual void Setup()
        {
            
        }

        public virtual void FixedTick()
        {
            
        }

        private void FixedUpdate()
        {
            if (_isInitialized == false) return;
            FixedTick();
        }

        public virtual void Dispose()
        {
            CompositeDisposable.Dispose();
        }
    }
}