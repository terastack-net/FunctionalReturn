﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
  public class EnsureTests_Task_Right
  {
    [Fact]
    public async Task Ensure_Task_Right_with_successInput_and_successPredicate()
    {
      var initialResult = Return.Success("Initial message");

      var result = await initialResult.Ensure(() => Task.FromResult(Return.Success("Success message")));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");
      result.Value.Should().Be("Initial message");
    }

    [Fact]
    public async Task Ensure_Task_Right_with_successInput_and_failurePredicate()
    {
      var initialResult = Return.Success("Initial Result");

      var result = await initialResult.Ensure(() => Task.FromResult(Return.Failure("Error message")));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error message");
    }
    
    [Fact]
    public async Task Ensure_Task_Right_with_failureInput_and_successPredicate()
    {
      var initialResult = Return.Failure("Initial Error message");

      var result = await initialResult.Ensure(() => Task.FromResult(Return.Success("Success message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }

    [Fact]
    public async Task Ensure_Task_Right_with_failureInput_and_failurePredicate()
    {
      var initialResult = Return.Failure("Initial Error message");

      var result = await initialResult.Ensure(() => Task.FromResult(Return.Failure("Error message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_Task_Right_with_successInput_and_parameterisedFailurePredicate()
    {
      var initialResult = Return.Success("Initial Success message");

      var result = await initialResult.Ensure(_ => Task.FromResult(Return.Failure("Error Message")));

      result.IsSuccess.Should().BeFalse("Predicate is failure result");
      result.Error.Should().Be("Error Message");
    }
    
    [Fact]
    public async Task Ensure_Task_Right_with_successInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = Return.Success("Initial Success message");

      var result = await initialResult.Ensure(_ => Task.FromResult(Return.Success("Success Message")));

      result.IsSuccess.Should().BeTrue("Initial result and predicate succeeded");;
      result.Value.Should().Be("Initial Success message");
    }
    
    [Fact]
    public async Task Ensure_Task_Right_with_failureInput_and_parameterisedSuccessPredicate()
    {
      var initialResult = Return.Failure<string>("Initial Error message");

      var result = await initialResult.Ensure(_ => Task.FromResult(Return.Success("Success Message")));

      result.IsSuccess.Should().BeFalse("Initial result is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
    
    [Fact]
    public async Task Ensure_Task_Right_with_failureInput_and_parameterisedFailurePredicate()
    {
      var initialResult = Return.Failure<string>("Initial Error message");

      var result = await initialResult.Ensure(_ => Task.FromResult(Return.Failure("Success Message")));

      result.IsSuccess.Should().BeFalse("Initial result and predicate is failure result");;
      result.Error.Should().Be("Initial Error message");
    }
  }
}