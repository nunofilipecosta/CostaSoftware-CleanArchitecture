﻿using ErrorOr;

namespace CostaSoftware_CleanArchitecture.Domain.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid credentials");
    }
}
