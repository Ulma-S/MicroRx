using System;
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

        public static IObservable<T> Select<T>(this IObservable<T> source, Func<T, T> selectFunc)
        {
            return new SelectOperator<T>(source, selectFunc);
        }
    }
}
