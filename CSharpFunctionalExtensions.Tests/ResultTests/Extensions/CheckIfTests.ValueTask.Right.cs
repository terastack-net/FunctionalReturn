using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class CheckIfTests_ValueTask_Right : CheckIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_T_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = await result.CheckIf(condition, ValueTask_Func_Result);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_K_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = await result.CheckIf(condition, ValueTask_Func_Result_K);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_K_E_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = await result.CheckIf(condition, ValueTask_Func_Result_K_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_T_E_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = await result.CheckIf(condition, ValueTask_Func_UnitResult_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_E_executes_func_UnitResult_E_conditionally_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = await result.CheckIf(condition, ValueTask_Func_UnitResult_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_T_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = await result.CheckIf(Predicate, ValueTask_Func_Result);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_K_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool> result = Return.SuccessIf(isSuccess, condition, ErrorMessage);

            var returned = await result.CheckIf(Predicate, ValueTask_Func_Result_K);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_K_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = await result.CheckIf(Predicate, ValueTask_Func_Result_K_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_T_executes_func_result_T_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            Return<bool, E> result = Return.SuccessIf(isSuccess, condition, E.Value);

            var returned = await result.CheckIf(Predicate, ValueTask_Func_UnitResult_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task CheckIf_ValueTask_Right_E_executes_func_UnitResult_E_per_predicate_and_returns_self(bool isSuccess, bool condition)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            var returned = await result.CheckIf(Predicate(condition), ValueTask_Func_UnitResult_E);

            actionExecuted.Should().Be(isSuccess && condition);
            result.Should().Be(returned);
        }
    }
}