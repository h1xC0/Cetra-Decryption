using Codebase.ComponentScripts.Vehicle.Model;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.SO
{
    [CreateAssetMenu(menuName = "VehicleModels/ArmorVehicle", fileName = "Armor Vehicle Model")]
    public class ArmorVehicleModel : VehicleModelData
    {
        public int Armor;
        
        public override VehicleModel ToModel()
        {
            var model = base.ToModel();
            model.Armor = Armor;
            return model;
        }
    }
}