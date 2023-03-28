using Zenject;

namespace Codebase.Systems.CommandSystem.Commands
{
    public class InitializeGameCommand : Command
    {
        private readonly IInstantiator _instantiator;
        
        public InitializeGameCommand(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }
        
        protected override void Execute()
        {
            Retain();
            
            
            
            Release();
        }
    }
}