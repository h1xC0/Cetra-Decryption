using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Enums;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "Models/VehicleModel", fileName = "VehicleModel")]
    public class VehicleModelData : ScriptableObject
    {
        [System.Serializable]
        public class VehicleSpring
        {
            public float MaxDistance;
            public float MaxForce;
            public SpringLocation Location;

            public VehicleSpringModel ToSpringModel()
            {
                return new VehicleSpringModel(MaxDistance, MaxForce, Location);
            }
        }
        
        public string VehicleName = "";
        public List<VehicleSpring> Springs;

        public IVehicleModel ToModel()
        {
            var model = new VehicleModel
            {
                VehicleName = VehicleName
            };

            foreach (var spring in Springs)
            {
                model.Springs.Add(spring.ToSpringModel());
            }

            return model;
        }
        
        
    }
}