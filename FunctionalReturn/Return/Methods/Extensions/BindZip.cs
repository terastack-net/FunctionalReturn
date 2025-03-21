﻿#if (NETSTANDARD || NETCORE || NET5_0_OR_GREATER)
using System;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        /// <summary>
        ///     Selects result from the return value of a given function. If the calling Result is a success,
        ///     values of both results zip into a tuple. If the calling Result is a failure, a new failure
        ///     result is returned instead.
        /// </summary>
        public static Return<(T First, K Second)> BindZip<T, K>(
            this Return<T> result, Func<T, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T, K)>(result.Error);
            }

            var result2 = func(result.Value);

            return result2.IsFailure
                ? Return.Failure<(T, K)>(result2.Error)
                : Return.Success((result.Value, result2.Value));
        }

        public static Return<(T First, K Second), E> BindZip<T, K, E>(
            this Return<T, E> result, Func<T, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T, K), E>(result.Error);
            }

            var r2 = func(result.Value);

            return r2.IsFailure
                ? Return.Failure<(T, K), E>(r2.Error)
                : Return.Success<(T, K), E>((result.Value, r2.Value));
        }
        
        public static Return<(T1 First, T2 Second, K Third)> BindZip<T1, T2, K>(
            this Return<(T1, T2)> result, Func<T1, T2, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, K)>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, r2.Value));
        }

        public static Return<(T1 First, T2 Second, K Third), E> BindZip<T1, T2, K, E>(
            this Return<(T1, T2), E> result, Func<T1, T2, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, K), E>(r2.Error)
                : Return.Success<(T1, T2, K), E>((v.Item1, v.Item2, r2.Value));
        }
        
        public static Return<(T1, T2, T3, K)> BindZip<T1, T2, T3, K>(
            this Return<(T1, T2, T3)> result, Func<T1, T2, T3, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, K)>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, v.Item3, r2.Value));
        }

        public static Return<(T1, T2, T3, K), E> BindZip<T1, T2, T3, K, E>(
            this Return<(T1, T2, T3), E> result, Func<T1, T2, T3, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, K), E>(r2.Error)
                : Return.Success<(T1, T2, T3, K), E>((v.Item1, v.Item2, v.Item3, r2.Value));
        }

        public static Return<(T1, T2, T3, T4, K)> BindZip<T1, T2, T3, T4, K>(
            this Return<(T1, T2, T3, T4)> result, Func<T1, T2, T3, T4, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, K)>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, v.Item3, v.Item4, r2.Value));
        }

        public static Return<(T1, T2, T3, T4, K), E> BindZip<T1, T2, T3, T4, K, E>(
            this Return<(T1, T2, T3, T4), E> result, Func<T1, T2, T3, T4, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, K), E>(r2.Error)
                : Return.Success<(T1, T2, T3, T4, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, r2.Value));
        }
        
        public static Return<(T1, T2, T3, T4, T5, K)> BindZip<T1, T2, T3, T4, T5, K>(
            this Return<(T1, T2, T3, T4, T5)> result, Func<T1, T2, T3, T4, T5, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, K)>(result.Error);
            }

            var v = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, r2.Value));
        }

        public static Return<(T1, T2, T3, T4, T5, K), E> BindZip<T1, T2, T3, T4, T5, K, E>(
            this Return<(T1, T2, T3, T4, T5), E> result, Func<T1, T2, T3, T4, T5, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, K), E>(r2.Error)
                : Return.Success<(T1, T2, T3, T4, T5, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, r2.Value));
        }

        public static Return<(T1, T2, T3, T4, T5, T6, K)> BindZip<T1, T2, T3, T4, T5, T6, K>(
            this Return<(T1, T2, T3, T4, T5, T6)> result, Func<T1, T2, T3, T4, T5, T6, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, r2.Value));
        }
        
        public static Return<(T1, T2, T3, T4, T5, T6, K), E> BindZip<T1, T2, T3, T4, T5, T6, K, E>(
            this Return<(T1, T2, T3, T4, T5, T6), E> result, Func<T1, T2, T3, T4, T5, T6, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, K), E>(r2.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, K), E>((
                    v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, r2.Value
                ));
        }

        public static Return<(T1, T2, T3, T4, T5, T6, T7, K)> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(
            this Return<(T1, T2, T3, T4, T5, T6, T7)> result, Func<T1, T2, T3, T4, T5, T6, T7, Return<K>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(r2.Error)
                : Return.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, r2.Value));
        }

        public static Return<(T1, T2, T3, T4, T5, T6, T7, K), E> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(
            this Return<(T1, T2, T3, T4, T5, T6, T7), E> result, Func<T1, T2, T3, T4, T5, T6, T7, Return<K, E>> func
        ) {
            if (result.IsFailure)
            {
                return Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error);
            }

            var v  = result.Value;
            var r2 = func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7);

            return r2.IsFailure
                ? Return.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(r2.Error)
                : Return.Success<(T1, T2, T3, T4, T5, T6, T7, K), E>((
                    v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, r2.Value
                ));
        }
    }
}
#endif
