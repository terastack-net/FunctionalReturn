﻿using System;
using System.Threading.Tasks;

namespace FunctionalReturn
{
    public static partial class ResultExtensions
    {
        public static async Task<T> GetValueOrDefault<T>(this Task<Return<T>> resultTask, Func<T> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return result.GetValueOrDefault(defaultValue);
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Return<T>> resultTask, Func<T, K> selector,
            K defaultValue = default)
        {
            var result = await resultTask.DefaultAwait();
            return result.GetValueOrDefault(selector, defaultValue);
        }

        public static async Task<K> GetValueOrDefault<T, K>(this Task<Return<T>> resultTask, Func<T, K> selector,
            Func<K> defaultValue)
        {
            var result = await resultTask.DefaultAwait();
            return result.GetValueOrDefault(selector, defaultValue);
        }
    }
}
