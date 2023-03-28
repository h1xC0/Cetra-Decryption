using System;
using UniRx;

namespace Codebase.Extensions
{
    public static class UniRxExtensions
    {
        public static void AddTo(this IDisposable disposable, CompositeDisposable compositeDisposable)
        {
            compositeDisposable.Add(disposable);
        }
    }
}