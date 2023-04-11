using UnityEngine;

namespace Codebase.Systems.MVC
{
    public abstract class BaseView : MonoBehaviour, IView
    { 
        public virtual void Construct()
        {
        }
        
        public virtual void Dispose()
        {
        }
    }
}