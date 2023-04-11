using Codebase.ComponentScripts.Vehicle.Services;
using Codebase.ComponentScripts.VehicleInput.View;
using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Commands;
using Codebase.Systems.CommandSystem.Signals;
using Codebase.Systems.UnityLifecycle;
using UnityEngine;
using Zenject;

namespace Codebase.Installers
{
    public class GameplayInstaller : BaseInstaller
    {
        public GameplayInstaller(ICommandBinder commandBinder) : base(commandBinder)
        {
            
        }

        protected override void InstallComponents()
        {
        }

        protected override void InstallCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<InitializeGameSignal>()
                .To<SpawnPlayerVehicleCommand>();
        }

        protected override void InstallServices()
        {
            Container.BindInterfacesTo<VehicleInputService>().FromNew().AsSingle();
        }
    }
}