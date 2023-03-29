using Derby.Vehicle.Controller;

namespace Derby
{
    public interface IVehicleFactory
    {
        IVehicle GeneratePlayerVehicle();
        IVehicle GenerateAiVehicle();
    }
}