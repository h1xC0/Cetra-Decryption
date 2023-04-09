using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    public class VehicleModelData : ScriptableObject
    {
        public string VehicleName = "";
        public List<VehicleSpringData> Springs = new();
        public int HitPoints;
        public int AccessoriesCount;
        public float Speed;
        public float Mass;
        
        public virtual VehicleModel ToModel()
        {
            var health = new VehicleHPModel(HitPoints, 0);
            var engine = new VehicleEngineModel(AccessoriesCount, Speed, Mass, 0);
            var model = new VehicleModel(VehicleName, health, engine);

            foreach (var spring in Springs)
            {
                model.SpringModels.Add(spring.ToSpringModel());
            }

            return model;
        }
    }
}