namespace Codebase.ComponentScripts.VehicleInput.Model
{
    public class VehicleInputModel : IVehicleInputModel
    {
        public float Horizontal;
        public float Vertical;

        public (float, float) GetInputData()
        {
            return (Horizontal, Vertical);
        }
    }
}
