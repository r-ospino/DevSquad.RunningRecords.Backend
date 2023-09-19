using System.Diagnostics.CodeAnalysis;
using Throw;

namespace DevSquad.RunningRecords.Backend.Domain;

public record Distance(double Magnitude, DistanceUnits Unit)
{
    [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Validate constructor parameters")]
    private readonly bool _valid = Magnitude.Throw().IfNegativeOrZero().IsValid()
        && Unit.Throw().IfOutOfRange().IsValid();

    public override string ToString() => $"{Magnitude:#.00} {Enum.GetName<DistanceUnits>(Unit)}";
}
