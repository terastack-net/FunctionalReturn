﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_Task : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_Task_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage).AsTask();
            var newResult = await myResult.OnFailureCompensate(() => Return.Success().AsTask());

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_Task_func_string_on_failure_returns_Ok()
        {
            var myResult = Return.Failure(ErrorMessage).AsTask();
            var newResult = await myResult.OnFailureCompensate(errorMessage => Return.Success().AsTask());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_Task_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage).AsTask();
            var newResult = await myResult.OnFailureCompensate(() => Return.Success(T.Value).AsTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_Task_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T>(ErrorMessage).AsTask();
            var newResult = await myResult.OnFailureCompensate(error => Return.Success(T.Value).AsTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_Task_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value).AsTask();
            var newResult = await myResult.OnFailureCompensate(error => Return.Success<T, E>(T.Value).AsTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_Task_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Return.Failure<T, E>(E.Value).AsTask();
            var newResult = await myResult.OnFailureCompensate(() => Return.Success<T, E>(T.Value).AsTask());

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}