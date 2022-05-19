using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public interface IReadOnlyReactiveProperty<T> : IObservable<T>
    {
        T Value { get; }
    }
}
