namespace Numerologia.Models;

public sealed class ResumenPersona
{
    public int LifePathNumber { get; init; }
    public int ExpressionNumber { get; init; }
    public List<int> ChallengeNumbers { get; init; } = new();
    public List<int> Pinnacles { get; init; } = new();
    public int PersonalYear { get; init; }
    public int PersonalMonth { get; init; }
    public int PersonalDay { get; init; }
    public int HeredityNumber { get; init; }
    public int CapsuleNumber { get; init; }
}
