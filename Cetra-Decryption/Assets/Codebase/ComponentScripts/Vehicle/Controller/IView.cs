using System;
using UnityEngine;

namespace Codebase.ComponentScripts.Vehicle.Controller
{
    public interface IView : IDisposable
    {
        public GameObject GameObject { get; } // Dispose view component
    }
}