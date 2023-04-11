using UniRx;
using UnityEngine;

namespace Codebase.Systems.MVC
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        protected CompositeDisposable CompositeDisposable;
        private bool _isDestroyed;
        
        public virtual void Construct()
        {
            _isDestroyed = false;
            CompositeDisposable = new CompositeDisposable();
        }
        
        public virtual void Dispose()
        {
            if (_isDestroyed) return;
            _isDestroyed = true;
            
            CompositeDisposable.Dispose();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}