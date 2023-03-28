using Codebase.Systems.CommandSystem;
using Codebase.Systems.CommandSystem.Commands;
using Codebase.Systems.CommandSystem.Signals;

namespace Codebase.Installers
{
    public class BootstrapInstaller : BaseProjectInstaller
    { 
        public BootstrapInstaller(ICommandBinder commandBinder) : base(commandBinder)
        {
        }
        
        protected override void InstallServices()
        {
            
        }
        
        protected override void InstallComponents()
        {
            
        }

        protected override void InstallCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<LoadMainMenuSignal>()
                .To<LoadSceneCommand>();

            commandBinder.Bind<LoadGameSceneSignal>()
                .To<LoadSceneCommand>()
                .To<InitializeGameCommand>();
        }
    }
}