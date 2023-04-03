using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Enums;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
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
        
        public List<VehicleSpring> Springs;
        
        public string VehicleName = "";
        public int HitPoints;
        public int AccessoriesCount;
        public float Speed;
        public float Mass;
        
        public virtual VehicleModel ToModel()
        {
            var model = new VehicleModel
            {
                VehicleName = VehicleName,
                HitPoints = HitPoints,
                AccessoriesCount = AccessoriesCount,
                Speed = Speed,
                Mass = Mass,
                Armor = 0,
                Nitro = 0
            };

            foreach (var spring in Springs)
            {
                model.Springs.Add(spring.ToSpringModel());
            }

            return model;
        }
        
        
    }
}