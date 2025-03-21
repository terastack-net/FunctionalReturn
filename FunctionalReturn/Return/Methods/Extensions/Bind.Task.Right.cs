using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class AsyncResultExtensionsRightOperand
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return<K, E>> Bind<T, K, E>(this Return<T, E> result, Func<T, Task<Return<K, E>>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K, E>(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return<K>> Bind<T, K>(this Return<T> result, Func<T, Task<Return<K>>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return<K>> Bind<K>(this Return result, Func<Task<Return<K>>> func)
        {
            if (result.IsFailure)
                return Return.Failure<K>(result.Error).AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return> Bind<T>(this Return<T> result, Func<T, Task<Return>> func)
        {
            if (result.IsFailure)
                return Return.Failure(result.Error).AsCompletedTask();

            return func(result.Value);
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return> Bind(this Return result, Func<Task<Return>> func)
        {
            if (result.IsFailure)
                return result.AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<UnitReturn<E>> Bind<E>(this UnitReturn<E> result, Func<Task<UnitReturn<E>>> func)
        {
            if (result.IsFailure)
                return UnitReturn.Failure(result.Error).AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<Return<T, E>> Bind<T, E>(this UnitReturn<E> result, Func<Task<Return<T, E>>> func)
        {
            if (result.IsFailure)
                return Return.Failure<T, E>(result.Error).AsCompletedTask();

            return func();
        }

        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Task<UnitReturn<E>> Bind<T, E>(this Return<T, E> result, Func<T, Task<UnitReturn<E>>> func)
        {
            if (result.IsFailure)
                return UnitReturn.Failure(result.Error).AsCompletedTask();

            return func(result.Value);
        }
    }
}