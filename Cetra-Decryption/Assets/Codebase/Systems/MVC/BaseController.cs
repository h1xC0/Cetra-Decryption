using System;
using Codebase.ComponentScripts.Vehicle.Controller;
using UniRx;

namespace Codebase.Systems.MVC
{
    public abstract class BaseController<TViewContract> : IDisposable, IVehicle
        where TViewContract : IView
    {
        protected CompositeDisposable CompositeDisposable = new CompositeDisposable();
        protected TViewContract View;

        protected BaseController(TViewContract viewContract)
        {
            View = viewContract;
        }

        public virtual void Dispose()
        {
            
        }
        protected T AddDisposable<T>(T controller) where T : IDisposable
        {
            CompositeDisposable.Add(controller);
            return controller;
        }
    }
}