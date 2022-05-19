using System;
using System.Collections.Generic;
using System.Text;
using MicroRx.Operator;

namespace MicroRx
{
    public static class Extension
    {
        public static IDisposable Subscribe<T>(this IObservable<T> source, Action<T> onNotified)
        {
            return source.Subscribe(ObserverFactory.CreateObserver<T>(onNotified));
        }

        public static IObservable<T> Where<T>(this IObservable<T> source, Func<T, bool> conditionalFunc)
        {
            return new WhereOperator<T>(source, conditionalFunc);
        }
    }
}
