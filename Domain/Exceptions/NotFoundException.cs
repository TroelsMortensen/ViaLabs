﻿namespace Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string s) : base(s) {}
}