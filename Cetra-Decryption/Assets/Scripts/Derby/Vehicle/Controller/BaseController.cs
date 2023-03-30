using System;

namespace Derby.Vehicle.Controller
{
    public class BaseController<TViewContract> : IDisposable
        where TViewContract : IView
    {
        protected TViewContract View;

        public BaseController(TViewContract viewContract)
        {
            View = viewContract;
        }

        public void Dispose()
        {
        }

        protected T AddDisposable<T>(T controller) where T : IDisposable
        {
            return controller;
        }
    }
}