using System;
using Codebase.ComponentScripts.Vehicle.Controller;
using UniRx;

namespace Codebase.Systems.MVC
{
    public abstract class BaseController<TViewContract> : IDisposable
        where TViewContract : IView
    {
        protected CompositeDisposable CompositeDisposable = new CompositeDisposable();
        protected TViewContract View;

        protected BaseController(TViewContract viewContract)
        {
            View = viewContract;
            View.Initialize();
        }

        public virtual void Dispose()
        {
            CompositeDisposable.Dispose();
        }
    }
}