using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Commands;
using Codebase.Systems.CommandSystem.Signals;

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
        }
    }
}