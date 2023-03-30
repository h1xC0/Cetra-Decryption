using System;
using UnityEngine;

namespace Derby.Vehicle.Controller
{
    public interface IView : IDisposable
    {
        public GameObject GameObject { get; } // Dispose view component
    }
}