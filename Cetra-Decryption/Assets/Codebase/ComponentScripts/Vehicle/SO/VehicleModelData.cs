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
            public float WheelRadius;
            public float WheelOffset;
            public float RestLength;
            public float SpringTravel;
            public float SpringStiffness;
            public float DamperStiffness;
            public WheelLocation Location;

            public VehicleSpringModel ToSpringModel()
            {
                return new VehicleSpringModel(WheelRadius, WheelOffset, RestLength, SpringTravel, SpringStiffness, DamperStiffness, Location);
            }
        }
        
        public List<VehicleSpring> Springs = new();
        
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

            model.Springs = new();
            
            foreach (var spring in Springs)
            {
                model.Springs.Add(spring.ToSpringModel());
            }

            return model;
        }
        
        
    }
}