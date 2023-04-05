using Codebase.Systems.MVC;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public abstract class VehicleController<TView> : BaseController<TView>, IVehicleController<TView>
        where TView : IVehicleView
    {
        protected VehicleController(TView view) : base(view)
        {
            
        }

        // protected abstract void Initialize();

        public override void Dispose()
        {
            base.Dispose();
            View.Dispose();
        }
    }
}