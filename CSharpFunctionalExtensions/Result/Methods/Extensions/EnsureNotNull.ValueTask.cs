#if NET5_0_OR_GREATER
#nullable enable

using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Return<T>> EnsureNotNull<T>(this ValueTask<Return<T?>> resultTask, Exception error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static ValueTask<Return<T>> EnsureNotNull<T>(this ValueTask<Return<T?>> resultTask, Exception error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static ValueTask<Return<T>> EnsureNotNull<T>(this ValueTask<Return<T?>> resultTask, Func<ValueTask<string>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Return<T>> EnsureNotNull<T>(this ValueTask<Return<T?>> resultTask, Func<ValueTask<string>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, _ => errorFactory()).Map(value => value!.Value);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this ValueTask<Return<T?, E>> resultTask, E error)
            where T : class
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this ValueTask<Return<T?, E>> resultTask, E error)
            where T : struct
        {
            return resultTask.Ensure(value => value != null, error).Map(value => value!.Value);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this ValueTask<Return<T?, E>> resultTask, Func<ValueTask<E>> errorFactory)
            where T : class
        {
            return resultTask.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!);
        }

        public static ValueTask<Return<T, E>> EnsureNotNull<T, E>(this ValueTask<Return<T?, E>> resultTask, Func<ValueTask<E>> errorFactory)
            where T : struct
        {
            return resultTask.Ensure(value => ValueTask.FromResult(value != null), _ => errorFactory()).Map(value => value!.Value);
        }
    }
}
#endif