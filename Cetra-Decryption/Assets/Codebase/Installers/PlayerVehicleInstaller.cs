using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class PlayerVehicleInstaller : MonoInstaller
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private TmpVehicle _vehiclePrefab;
        
        public override void InstallBindings()
        {
            var vehicle = 
        }
    }
}