using Codebase.ComponentScripts.Vehicle.Model;
using Codebase.Enums;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "VehicleModels/Springs/SpringData", fileName = "SpringData")]
    public class VehicleSpringData : ScriptableObject
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
}