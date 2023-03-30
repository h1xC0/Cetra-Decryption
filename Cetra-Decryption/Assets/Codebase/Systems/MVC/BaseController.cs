using System;

namespace Codebase.Systems.MVC
{
    public class BaseController<TViewContract> : IDisposable
        where TViewContract : IView
    {
        protected TViewContract View;

        public BaseController(TViewContract viewContract)
        {
            View = viewContract;
        }

        public virtual void Dispose()
        {
            
        }
    }
}