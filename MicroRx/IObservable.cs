using System;

namespace MicroRx
{
    public interface IObservable<T>
    {
         IDisposable Subscribe(IObserver<T> observer);
    }
}
