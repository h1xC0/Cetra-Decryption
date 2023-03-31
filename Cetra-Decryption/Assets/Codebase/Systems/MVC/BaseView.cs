using UniRx;
using UnityEngine;

namespace Codebase.Systems.MVC
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public GameObject GameObject { get; }
        public CompositeDisposable CompositeDisposable;

        public virtual void Dispose()
        {
            CompositeDisposable.Dispose();
        }
    }
}