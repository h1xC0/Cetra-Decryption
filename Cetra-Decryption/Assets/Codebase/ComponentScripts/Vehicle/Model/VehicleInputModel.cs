namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleInputModel
    {
        public float WheelBase;
        public float RearTrack;
        public float TurnRadius;
        
        public float SteerInput;

        public VehicleInputModel(float wheelBase, float rearTrack, float turnRadius, float steerInput)
        {
            WheelBase = wheelBase;
            RearTrack = rearTrack;
            TurnRadius = turnRadius;
            SteerInput = steerInput;
        }
    }
}
