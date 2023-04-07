using System.Collections.Generic;
using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "Models/VehicleModel", fileName = "VehicleModel")]
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
        
        public string VehicleName = "";
        public List<VehicleSpring> Springs = new ();

        public IVehicleModel ToModel()
        {
            var model = new VehicleModel
            {
                VehicleName = VehicleName,
                WheelModels = new ()
            };

            foreach (var wheel in Springs)
            {
                model.WheelModels.Add(wheel.ToSpringModel());
            }

            return model;
        }
        
        
    }
}