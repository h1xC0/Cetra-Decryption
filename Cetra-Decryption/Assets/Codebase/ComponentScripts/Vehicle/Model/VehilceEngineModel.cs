namespace Codebase.ComponentScripts.Vehicle.Model
{
    public class VehicleEngineModel
    {
        public int AccessoriesCount;
        public float Speed;
        public float Mass;
        public float Nitro;

        public VehicleEngineModel(int accessoriesCount, float speed, float mass, float nitro)
        {
            AccessoriesCount = accessoriesCount;
            Speed = speed;
            Mass = mass;
            Nitro = nitro;
        }
    }
}