using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public static class ObserverFactory
    {
        public static IObserver<T> CreateObserver<T>(Action<T> onNext)
        {
            return new Observer<T>(onNext);
        }

        public static IObserver<T> CreateObserver<T>(Action<T> onNext, Action onCompleted)
        {
            return new Observer<T>(onNext, onCompleted);
        }
    }
}
