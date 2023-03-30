using Codebase.Enums;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleSpringModel
    {
        public float MaxDistance;
        public float MaxForce;
        public SpringLocation Location;

        public VehicleSpringModel(float maxDistance, float maxForce, SpringLocation location)
        {
            MaxDistance = maxDistance;
            MaxForce = maxForce;
            Location = location;
        }
    }
}
