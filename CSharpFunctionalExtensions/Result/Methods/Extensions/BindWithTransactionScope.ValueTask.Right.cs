#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<K, E>> BindWithTransactionScope<T, K, E>(this Return<T, E> self, Func<T, ValueTask<Return<K, E>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return<K>> BindWithTransactionScope<T, K>(this Return<T> self, Func<T, ValueTask<Return<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return<K>> BindWithTransactionScope<K>(this Return self, Func<ValueTask<Return<K>>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return> BindWithTransactionScope<T>(this Return<T> self, Func<T, ValueTask<Return>> f)
            => WithTransactionScope(() => self.Bind(f));

        public static ValueTask<Return> BindWithTransactionScope(this Return self, Func<ValueTask<Return>> f)
            => WithTransactionScope(() => self.Bind(f));
    }
}
#endif
