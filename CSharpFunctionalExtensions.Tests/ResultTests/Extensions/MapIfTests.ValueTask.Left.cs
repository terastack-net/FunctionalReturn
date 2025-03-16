using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapIfTests_ValueTask_Left : MapIfTestsBase
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsValueTask();

            Return<T> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T, E>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, E.Value)
                .AsValueTask();

            Return<T, E> returned = await resultTask.MapIf(condition, GetAction());

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsValueTask();

            Return<T> returned = await resultTask.MapIf(GetValuePredicate(condition), GetAction());

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_E_executes_func_conditionally_and_returns_new_result(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T, E>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, E.Value)
                .AsValueTask();

            Return<T, E> returned = await resultTask.MapIf(
                GetValuePredicate(condition),
                GetAction()
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsValueTask();

            Return<T> returned = await resultTask.MapIf(
                condition,
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetAction()(value);
                },
                ContextMessage
            );

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_T_E_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T, E>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, E.Value)
                .AsValueTask();

            Return<T, E> returned = await resultTask.MapIf(
                condition,
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetAction()(value);
                },
                ContextMessage
            );

            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, ErrorMessage)
                .AsValueTask();

            Return<T> returned = await resultTask.MapIf(
                (value, context) => GetValuePredicate(condition)(value),
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetAction()(value);
                },
                ContextMessage
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueResult(isSuccess, condition));
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task MapIf_ValueTask_Left_computes_predicate_T_E_executes_func_conditionally_and_passes_context(
            bool isSuccess,
            bool condition
        )
        {
            ValueTask<Return<T, E>> resultTask = Return
                .SuccessIf(isSuccess, T.Value, E.Value)
                .AsValueTask();

            Return<T, E> returned = await resultTask.MapIf(
                (value, context) => GetValuePredicate(condition)(value),
                (value, context) =>
                {
                    context.Should().Be(ContextMessage);
                    return GetAction()(value);
                },
                ContextMessage
            );

            predicateExecuted.Should().Be(isSuccess);
            actionExecuted.Should().Be(isSuccess && condition);
            returned.Should().Be(GetExpectedValueErrorResult(isSuccess, condition));
        }
    }
}
