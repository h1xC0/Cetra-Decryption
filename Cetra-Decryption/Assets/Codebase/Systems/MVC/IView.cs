using System;

namespace Codebase.Systems.MVC
{
    public interface IView : IDisposable
    {
        void Construct();
    }
}