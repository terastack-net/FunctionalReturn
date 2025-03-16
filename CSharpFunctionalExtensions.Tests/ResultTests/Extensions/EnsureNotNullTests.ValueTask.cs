﻿#nullable enable

using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureNotNullTests_ValueTask : EnsureNotNullTests_Base
    {
        [Fact]
        public async Task EnsureNotNull_ValueTask_T_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?> result = Return.Failure<T?>(ErrorMessage);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?> result = Return.Failure<V?>(ErrorMessage);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?> result = Return.Success<T?>(T.Value);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?> result = Return.Success<V?>(V.Value);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?> result = Return.Success<T?>(null);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?> result = Return.Success<V?>(null);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(ErrorMessage2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_factory_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?> result = Return.Failure<T?>(ErrorMessage);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?> result = Return.Failure<V?>(ErrorMessage);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?> result = Return.Success<T?>(T.Value);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?> result = Return.Success<V?>(V.Value);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?> result = Return.Success<T?>(null);

            Return<T> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?> result = Return.Success<V?>(null);

            Return<V> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(ErrorMessage2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(ErrorMessage2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?, E> result = Return.Failure<T?, E>(E.Value);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?, E> result = Return.Failure<V?, E>(E.Value);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(T.Value);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(V.Value);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(null);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(null);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(E.Value2);

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_factory_with_class_returns_failed_return_for_failed_result()
        {
            Return<T?, E> result = Return.Failure<T?, E>(E.Value);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_factory_with_struct_returns_failed_return_for_failed_result()
        {
            Return<V?, E> result = Return.Failure<V?, E>(E.Value);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_factory_with_class_returns_original_success_result_if_value_is_not_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(T.Value);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(T.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_factory_with_struct_returns_original_success_result_if_value_is_not_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(V.Value);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeTrue();
            returned.Value.Should().Be(V.Value);
            factoryExecuted.Should().BeFalse();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_T_E_factory_with_class_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<T?, E> result = Return.Success<T?, E>(null);

            Return<T, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }

        [Fact]
        public async Task EnsureNotNull_ValueTask_V_E_factory_with_struct_returns_failed_result_for_success_result_if_value_is_null()
        {
            Return<V?, E> result = Return.Success<V?, E>(null);

            Return<V, E> returned = await result.AsValueTask().EnsureNotNull(GetValueTaskErrorFactory(E.Value2));

            returned.IsSuccess.Should().BeFalse();
            returned.Error.Should().Be(E.Value2);
            factoryExecuted.Should().BeTrue();
        }
    }
}
