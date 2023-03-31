using System.Threading.Tasks;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Systems.MVC;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public abstract class VehicleController<TView> : BaseController<TView>, IVehicleController<TView>
        where TView : IVehicleView
    {
        private TView _view;

        public VehicleController(TView view, IVehicleModel model) : base(view)
        {
            _view = view;
        }

        protected abstract void Initialize();

        private async void InitializeAsyncWrapped()
        {
            await InitializeAsync();
            //TODO: When view was initialized
        }

        protected virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            base.Dispose();
            View.Dispose();
        }
    }
}