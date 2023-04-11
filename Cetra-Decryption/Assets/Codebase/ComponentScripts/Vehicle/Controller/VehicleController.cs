using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.ComponentScripts.Vehicle.View;
using Codebase.Systems.MVC;
using Codebase.Systems.UnityLifecycle;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public class VehicleController : BaseController<IVehicleView>, IVehicle
    {
        private readonly VehicleView _view;
        private readonly IVehicleModel _model;
        private readonly IUnityLifecycleService _lifecycleService;
        
        public VehicleController(
            VehicleView view, 
            IVehicleModel model, 
            IUnityLifecycleService lifecycleService) 
            : base(view)
        {
            _view = view;
            _model = model;
            _lifecycleService = lifecycleService;
        }

        protected override void Initialize()
        {
            _view.SetupSprings(_model.SpringModels);
            _lifecycleService.Subscribe(_view);
        }

        public override void Dispose()
        {
            _lifecycleService.Unsubscribe(_view);
            base.Dispose();
        }
    }
}