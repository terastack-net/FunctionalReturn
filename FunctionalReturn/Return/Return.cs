﻿using FunctionalReturn.Internal;
using System;
using System.Runtime.Serialization;

namespace FunctionalReturn
{
    [Serializable]
    public readonly partial struct Return : IReturn, ISerializable, IError<Exception>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly Exception _error;
        public Exception Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private Return(bool isFailure, Exception error)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
        }

        private Return(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<Exception> values = ResultCommonLogic.Deserialize(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public static implicit operator UnitReturn<Exception>(Return result)
        {
            if (result.IsSuccess)
                return UnitReturn.Success<Exception>();
            else
                return UnitReturn.Failure(result.Error);
        }
    }
}
