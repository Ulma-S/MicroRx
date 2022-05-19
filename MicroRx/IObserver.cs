using System;

namespace MicroRx
{
    public interface IObserver<T>
    {
        void OnNext(T value);
        void OnError(Exception e);
        void OnCompleted();
    }
}
