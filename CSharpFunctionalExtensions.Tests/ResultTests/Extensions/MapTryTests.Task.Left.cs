﻿using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapTryTests_Task_Left : MapTryTestsBase
    {
        #region MapTry for Task<Result> with function returning K
        [Fact]
        public async Task MapTry_execute_func_K_on_task_success_returns_success()
        {
            Task<Return> sut = Return.Success().AsTask();

            Return<K> result = await sut.MapTry(Func_K);

            AssertSuccess(result);
        }

        [Fact]
        public async Task MapTry_execute_func_K_on_task_failure_returns_failure()
        {
            Task<Return> sut = Return.Failure(ErrorMessage).AsTask();

            Return<K> result = await sut.MapTry(Func_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_K_on_taks_success_returns_failure_with_exception_message()
        {
            Task<Return> sut = Return.Success().AsTask();

            Return<K> result = await sut.MapTry(Throwing_K);

            AssertFailureFromDefaultHandler(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Return> sut = Return.Success().AsTask();

            Return<K> result = await sut.MapTry(Throwing_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for Task<Result<T>> with function returning K
        [Fact]
        public async Task MapTry_execute_func_K_on_task_success_T_returns_success()
        {
            Task<Return<T>> sut = Return.Success(T.Value).AsTask();

            Return<K> result = await sut.MapTry(Func_T_K);

            AssertSuccess(result);
        }

        [Fact]
        public async Task MapTry_execute_func_K_on_task_failure_T_returns_failure()
        {
            Task<Return<T>> sut = Return.Failure<T>(ErrorMessage).AsTask();

            Return<K> result = await sut.MapTry(Func_T_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_K_on_taks_success_T_returns_failure_with_exception_message()
        {
            Task<Return<T>> sut = Return.Success(T.Value).AsTask();

            Return<K> result = await sut.MapTry(Throwing_T_K);

            AssertFailureFromDefaultHandler(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_K_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Return<T>> sut = Return.Success(T.Value).AsTask();

            Return<K> result = await sut.MapTry(Throwing_T_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for Task<Result<T,E>> with function returning K
        [Fact]
        public async Task MapTry_execute_func_T_K_on_task_success_T_E_returns_success()
        {
            Task<Return<T, E>> sut = Return.Success<T, E>(T.Value).AsTask();

            Return<K, E> result = await sut.MapTry(Func_T_K, ErrorHandler_E);

            AssertSuccess(result);
        }

        [Fact]
        public async Task MapTry_execute_func_T_K_on_task_failure_T_E_returns_failure()
        {
            Task<Return<T, E>> sut = Return.Failure<T, E>(E.Value).AsTask();

            Return<K, E> result = await sut.MapTry(Func_T_K, ErrorHandler_E);

            AssertFailure(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_T_K_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            Task<Return<T, E>> sut = Return.Success<T, E>(T.Value).AsTask();

            Return<K, E> result = await sut.MapTry(Throwing_T_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for Task<UnitResult<E>> with function returning K
        [Fact]
        public async Task MapTry_execute_func_K_on_task_success_E_returns_success()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            Return<K, E> result = await sut.MapTry(Func_K, ErrorHandler_E);

            AssertSuccess(result);
        }

        [Fact]
        public async Task MapTry_execute_func_K_on_task_failure_E_returns_failure()
        {
            Task<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsTask();

            Return<K, E> result = await sut.MapTry(Func_K, ErrorHandler_E);

            AssertFailure(result);
        }

        [Fact]
        public async Task MapTry_execute_throwing_func_K_on_success_E_returns_failure_with_value_from_error_handler()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            Return<K, E> result = await sut.MapTry(Throwing_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion        
    }
}
