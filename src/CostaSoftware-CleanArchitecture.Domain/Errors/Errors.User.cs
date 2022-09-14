﻿using ErrorOr;

namespace CostaSoftware_CleanArchitecture.Domain.Errors;
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");
    }
}
