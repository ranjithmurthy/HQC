﻿namespace Theatre.Exception
{
    using System;

    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string message)
            : base(message)
        {
        }
    }
}
