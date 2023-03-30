using UnityEngine;

namespace Codebase.Systems.MVC
{
    public class BaseView : MonoBehaviour, IView
    {
        public virtual void Dispose()
        {
            
        }

        public GameObject GameObject { get; }
    }
}