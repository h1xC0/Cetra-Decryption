﻿using System;
using Codebase.Systems.CommandSystem.Payloads;

namespace Codebase.Systems.CommandSystem
{
    public interface ICommand : IDisposable
    {
        event Action OnExecuted;
        bool IsRetained { get; }
        void Invoke();
    }

    public interface ICommand<TPayload> : ICommand where TPayload : ICommandPayload
    {
        void Invoke(ICommandPayload payload);
    }
}