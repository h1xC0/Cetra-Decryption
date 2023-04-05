using System;
using UnityEngine;

namespace Codebase.Systems.MVC
{
    public interface IView : IDisposable
    {
        void Initialize();
    }
}