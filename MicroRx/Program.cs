using System;
using MicroRx;

namespace MicroRx.Sample
{
    class Program
    {
        private enum Type
        {
            A,
            B,
            C,
            D,
        }

        static void Main(string[] args)
        {
            var num = new ReactiveProperty<int>();

            var disposable = num.Where(value => value % 2 == 0)
                .Select(value => value *= 2)
                .Subscribe(value => {
                Console.WriteLine(value);
            });

            num.Value = 1;
            num.Value = 2;
            num.Value = 3;
            num.Value = 4;

            disposable.Dispose();
        }
    }
}
