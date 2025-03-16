﻿using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class FinallyTests_Task_Left : FinallyTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_Task_Left_result_returns_K(bool isSuccess)
        {
            Return result = Return.SuccessIf(isSuccess, ErrorMessage);
            K output = await result.AsTask().Finally(Func_Result);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_Task_Left_result_T_returns_K(bool isSuccess)
        {
            Return<T> result = Return.SuccessIf(isSuccess, T.Value, ErrorMessage);
            K output = await result.AsTask().Finally(Func_Result_T);

            AssertCalled(result, output);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Finally_Task_Left_result_T_E_returns_K(bool isSuccess)
        {
            Return<T, E> result = Return.SuccessIf(isSuccess, T.Value, E.Value);
            K output = await result.AsTask().Finally(Func_Result_T_E);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_Task_Left_UnitResult_E_executes_on_success_returns_K()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            K output = await result.AsTask().Finally(Func_UnitResult_E);

            AssertCalled(result, output);
        }

        [Fact]
        public async Task Finally_Task_Left_UnitResult_E_executes_on_failure_returns_K() {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            K output = await result.AsTask().Finally(Func_UnitResult_E);

            AssertCalled(result, output);
        }
    }
}
