using System;
using UnityEngine;

namespace Codebase.Systems.MVC
{
    public interface IView : IDisposable
    {
        public GameObject GameObject { get; } // Dispose view component
    }
}