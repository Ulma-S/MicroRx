using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public interface ISubject<T> : IObserver<T>, IObservable<T>
    {
        void Unsubscribe(IObserver<T> observer);
    }
}
