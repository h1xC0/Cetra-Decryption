using Codebase.Enums;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleWheelModel
    {
        public float WheelRadius;
        public float RestLength;
        public float SpringTravel;
        public float SpringStiffness;
        public float DamperStiffness;
        public WheelLocation Location;

        public VehicleWheelModel(float wheelRadius, float restLength, float springTravel, float springStiffness, float damperStiffness, WheelLocation location)
        {
            WheelRadius = wheelRadius;
            RestLength = restLength;
            SpringTravel = springTravel;
            SpringStiffness = springStiffness;
            DamperStiffness = damperStiffness;
            Location = location;
        }
    }
}
