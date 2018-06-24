using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSystem.ImportsTests
{
    class FunctionEqualityComparer
    {
        public static FunctionEqualityComparer<T> Create<T>(Func<T, T, bool> comparer) => new FunctionEqualityComparer<T>(comparer);
    }

    class FunctionEqualityComparer<TObject> : IEqualityComparer<TObject>
    {
        private readonly Func<TObject, TObject, bool> mComparer;

        public FunctionEqualityComparer(Func<TObject, TObject, bool> comparer) => mComparer = comparer;

        public bool Equals(TObject x, TObject y) => mComparer.Invoke(x, y);
        public int GetHashCode(TObject obj) => throw new NotImplementedException();
    }
}
