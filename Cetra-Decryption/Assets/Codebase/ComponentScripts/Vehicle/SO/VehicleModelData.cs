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
        public class VehicleWheel
        {
            public float WheelRadius;
            public float RestLength;
            public float SpringTravel;
            public float SpringStiffness;
            public float DamperStiffness;
            public WheelLocation Location;

            public VehicleWheelModel ToSpringModel()
            {
                return new VehicleWheelModel(WheelRadius, RestLength, SpringTravel, SpringStiffness, DamperStiffness, Location);
            }
        }
        
        public string VehicleName = "";
        public List<VehicleWheel> Wheels;

        public IVehicleModel ToModel()
        {
            var model = new VehicleModel
            {
                VehicleName = VehicleName
            };

            foreach (var wheel in Wheels)
            {
                model.WheelModels.Add(wheel.ToSpringModel());
            }

            return model;
        }
        
        
    }
}