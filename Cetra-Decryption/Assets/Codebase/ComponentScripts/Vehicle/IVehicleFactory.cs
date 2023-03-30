using Codebase.ComponentScripts.Vehicle.Controller;
using Codebase.ComponentScripts.Vehicle.Model;

namespace Codebase.ComponentScripts.Vehicle
{
    public interface IVehicleFactory
    {
        IPlayerVehicle GeneratePlayerVehicle(IVehicleModel model);
        IVehicle GenerateAiVehicle();
    }
}