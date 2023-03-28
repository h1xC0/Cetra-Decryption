using Derby.Vehicle.Controller;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class PlayerVehicleInstaller : MonoInstaller
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Vehicle _vehiclePrefab;
        
        public override void InstallBindings()
        {
            //var vehicle = 
        }
    }
}