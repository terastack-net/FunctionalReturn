#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace FunctionalReturn.ValueTasks
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K, E>> Bind<T, K, E>(this ValueTask<Return<T, E>> resultTask, Func<T, Return<K, E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Bind<T, K>(this ValueTask<Return<T>> resultTask, Func<T, Return<K>> valueTask)
        {
            Return<T> result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<K>> Bind<K>(this ValueTask<Return> resultTask, Func<Return<K>> valueTask)
        {
            Return result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return> Bind<T>(this ValueTask<Return<T>> resultTask, Func<T, Return> valueTask)
        {
            Return<T> result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return> Bind(this ValueTask<Return> resultTask, Func<Return> valueTask)
        {
            Return result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<Return<T, E>> Bind<T, E>(this ValueTask<UnitReturn<E>> resultTask, Func<Return<T, E>> valueTask)
        {
            UnitReturn<E> result = await resultTask;
            return result.Bind(valueTask);
        }

        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> Bind<T, E>(this ValueTask<Return<T, E>> resultTask, Func<T, UnitReturn<E>> valueTask)
        {
            Return<T, E> result = await resultTask;
            return result.Bind(valueTask);
        }
        
        /// <summary>
        ///     Selects result from the return value of a given valueTask action. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static async ValueTask<UnitReturn<E>> Bind<E>(this ValueTask<UnitReturn<E>> resultTask, Func<UnitReturn<E>> valueTask)
        {
            UnitReturn<E> result = await resultTask;
            return result.Bind(valueTask);
        }
    }
}
#endif