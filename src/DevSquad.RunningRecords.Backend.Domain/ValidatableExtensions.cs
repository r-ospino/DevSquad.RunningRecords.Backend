using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public static class ValidatableExtensions
{
    public static bool IsValid<TValue>(this in Validatable<TValue> validatable) where TValue : notnull => true;
}
