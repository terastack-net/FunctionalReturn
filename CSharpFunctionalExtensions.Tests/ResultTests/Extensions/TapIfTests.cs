﻿using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapIfTests : TapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return result = Return.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.TapIf(condition, Action_T);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, Action);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.TapIf(condition, Action_T);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Action);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = result.TapIf(Predicate, Action_T);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, Action);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapIf_T_E_executes_action_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = result.TapIf(Predicate, Action_T);

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}
