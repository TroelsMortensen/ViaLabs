﻿namespace Domain.OperationResult;

public class NoValueWhenErrorsException : Exception
{
    public NoValueWhenErrorsException() : base("Catastrophic server error. Attempted to access unavailable value")
    {
    }
}