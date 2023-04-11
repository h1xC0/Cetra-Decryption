using System;
using UniRx;

namespace Codebase.Systems.MVC
{
    public abstract class BaseController<TViewContract> : IDisposable
        where TViewContract : IView
    {
        protected CompositeDisposable CompositeDisposable = new CompositeDisposable();
        private readonly TViewContract _view;

        protected BaseController(TViewContract viewContract)
        {
            _view = viewContract;
            _view.Construct();
        }

        protected virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            _view.Dispose();
            CompositeDisposable.Dispose();
        }
    }
}