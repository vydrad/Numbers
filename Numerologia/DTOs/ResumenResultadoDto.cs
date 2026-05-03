
namespace Numerologia.DTOs;
public sealed class ResumenResultadoDto
{
    public int LifePathNumber { get; init; }
    public int AutoMotivationNumber { get; init; }
    public int AutoImageNumber { get; init; }
    public int AutoExpressionNumber { get; init; }
    public int AutoMotivationChallengeNumber { get; init; }
    public int AutoImageChallengeNumber { get; init; }
    public int AutoExpressionChallengeNumber { get; init; }
    public List<int> ChallengeNumbers { get; init; } = new();
    public List<int> Pinnacles { get; init; } = new();
    public int PersonalYear { get; init; }
    public int PersonalMonth { get; init; }
    public int PersonalDay { get; init; }
    public int HeredityNumber { get; init; }
    public int CapsuleNumber { get; init; }
    public VibracionTemporalResultadoDto? TemporalAnnualVibration { get; init; }
}
