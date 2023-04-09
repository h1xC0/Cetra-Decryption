using UnityEngine;

namespace Codebase.Systems.MVC
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}