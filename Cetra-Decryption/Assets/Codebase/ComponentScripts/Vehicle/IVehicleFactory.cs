using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;

namespace Codebase.ComponentScripts.Vehicle
{
    public interface IVehicleFactory
    {
        IVehicle GeneratePlayerVehicle(IVehicleModel model);
        IVehicle GenerateAiVehicle();
    }
}