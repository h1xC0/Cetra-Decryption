using System;
using Codebase.Systems.CommandSystem.Payloads;

namespace Codebase.Systems.CommandSystem
{
    public class Command : ICommand
    {
        public event Action OnExecuted;
        public bool IsRetained { get; private set; }
        
        public void Invoke()
        {
            Execute();
        }
        
        protected void Retain()
        {
            IsRetained = true;
        }

        protected void Release()
        {
            IsRetained = false;
            OnExecuted?.Invoke();
        }

        protected virtual void Execute()
        {
            
        }
        
        public void Dispose()
        {
        }
    }

    public class Command<TPayload> : Command, ICommand<TPayload> where TPayload : ICommandPayload
    {
        public void Invoke(ICommandPayload payload)
        {
            if (payload is null)
            {
                Execute();
                return;
            }
            
            Execute(payload);   
        }

        protected virtual void Execute(ICommandPayload payload)
        {
            
        }
    }
}
