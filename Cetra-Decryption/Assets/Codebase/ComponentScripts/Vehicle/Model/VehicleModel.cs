using System.Collections.Generic;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public string VehicleName;
        public int HitPoints;
        public int Armor;
        public int AccessoriesCount;
        public float Speed;
        public float Mass;
        public float Nitro;
        public List<VehicleSpringModel> Springs;
    }
}