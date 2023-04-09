using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "VehicleModels/FullStackVehicle", fileName = "FullStack Vehicle Model")]
    public class FullStackVehicleModel : VehicleModelData
    {
        public int Defence;
        public float Nitro;
        
        public override VehicleModel ToModel()
        {
            var model = base.ToModel();
            model.Nitro = Nitro;
            model.Armor = Defence;
            return model;
        }
    }
}