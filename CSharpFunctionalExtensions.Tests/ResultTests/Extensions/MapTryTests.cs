﻿using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public sealed class MapTryTests : MapTryTestsBase
    {        

        #region MapTry for Result with function returning K
        [Fact]
        public void MapTry_execute_func_K_on_success_returns_success()
        {
            Return sut = Return.Success();

            Return<K> result = sut.MapTry(Func_K);
            
            AssertSuccess(result);
        }
        [Fact]
        public void MapTry_execute_func_K_on_failure_returns_failure()
        {
            Return sut = Return.Failure(ErrorMessage);

            Return<K> result = sut.MapTry(Func_K);

            AssertFailure(result);
        }        

        [Fact]
        public void MapTry_execute_throwing_func_K_on_success_returns_failure_with_exception_message()
        {
            Return sut = Return.Success();

            Return<K> result = sut.MapTry(Throwing_K);

            AssertFailureFromDefaultHandler(result);
        }
        [Fact]
        public void MapTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Return sut = Return.Success();

            Return<K> result = sut.MapTry(Throwing_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for Result<T> with function returning K
        [Fact]
        public void MapTry_execute_func_T_K_on_success_T_returns_success_K()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.MapTry(Func_T_K);

            AssertSuccess(result);
        }
        [Fact]
        public void MapTry_execute_func_T_K_on_failure_T_returns_failure_K()
        {
            Return<T> sut = Return.Failure<T>(ErrorMessage);

            Return<K> result = sut.MapTry(Func_T_K);

            AssertFailure(result);
            result.Should().BeOfType<Return<K>>();
        }        

        [Fact]
        public void MapTry_execute_throwing_func_T_K_on_success_T_returns_failure_K_with_exception_message()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.MapTry(Throwing_T_K);

            AssertFailureFromDefaultHandler(result);
        }
        [Fact]
        public void MapTry_execute_throwing_func_T_K_on_success_T_with_custom_error_handler_returns_failure_K_with_custom_message()
        {
            Return<T> sut = Return.Success(T.Value);

            Return<K> result = sut.MapTry(Throwing_T_K, ErrorHandler);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for Result<T,E> with function returning K
        [Fact]
        public void MapTry_execute_func_T_K_on_success_T_E_returns_success_K_E()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            Return<K, E> result = sut.MapTry(Func_T_K, ErrorHandler_E);

            AssertSuccess(result);            
        }
        [Fact]
        public void MapTry_execute_func_T_K_on_failure_T_E_returns_failure_K_E()
        {
            Return<T, E> sut = Return.Failure<T, E>(E.Value);

            Return<K, E> result = sut.MapTry(Func_T_K, ErrorHandler_E);

            AssertFailure(result);            
        }
        
        [Fact]
        public void MapTry_execute_throwing_func_T_K_on_success_T_E_returns_failure_K_E_with_value_from_error_handler()
        {
            Return<T, E> sut = Return.Success<T, E>(T.Value);

            Return<K, E> result = sut.MapTry(Throwing_T_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion

        #region MapTry for UnitResult<E> with function returning K
        [Fact]
        public void MapTry_execute_func_K_on_success_E_returns_success_T_E()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Return<K, E> result = sut.MapTry(Func_K, ErrorHandler_E);

            AssertSuccess(result);
        }
        [Fact]
        public void MapTry_execute_func_K_on_failure_E_returns_failure_K_E()
        {
            UnitResult<E> sut = UnitResult.Failure(E.Value);

            Return<K, E> result = sut.MapTry(Func_K, ErrorHandler_E);

            AssertFailure(result);
        }        

        [Fact]
        public void MapTry_execute_throwing_func_K_on_success_E_returns_failure_K_E_with_value_from_error_handler()
        {
            UnitResult<E> sut = UnitResult.Success<E>();

            Return<K, E> result = sut.MapTry(Throwing_K, ErrorHandler_E);

            AssertFailureFromHandler(result);
        }
        #endregion
    }
}