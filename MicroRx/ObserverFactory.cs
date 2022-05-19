using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRx
{
    public static class ObserverFactory
    {
        public static IObserver<T> CreateObserver<T>(Action<T> onNotified)
        {
            return new Observer<T>(onNotified);
        }
    }
}
