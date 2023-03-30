using Codebase.ComponentScripts.Vehicle.Controller;

namespace Codebase.ComponentScripts.Vehicle
{
    public interface IVehicleFactory
    {
        IVehicle GeneratePlayerVehicle();
        IVehicle GenerateAiVehicle();
    }
}