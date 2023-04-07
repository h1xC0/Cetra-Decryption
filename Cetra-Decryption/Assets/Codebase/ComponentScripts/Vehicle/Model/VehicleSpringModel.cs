using Codebase.Enums;

namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleSpringModel
    {
        public float WheelOffset;
        public float WheelRadius;
        public float RestLength;
        public float SpringTravel;
        public float SpringStiffness;
        public float DamperStiffness;
        public WheelLocation Location;

        public VehicleSpringModel(float wheelRadius, float wheelOffset, float restLength, float springTravel, float springStiffness, float damperStiffness, WheelLocation location)
        {
            WheelRadius = wheelRadius;
            WheelOffset = wheelOffset;
            RestLength = restLength;
            SpringTravel = springTravel;
            SpringStiffness = springStiffness;
            DamperStiffness = damperStiffness;
            Location = location;
        }
    }
}
