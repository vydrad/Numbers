using System.ComponentModel.DataAnnotations;
using Numerologia.DTOs;

namespace Numerologia.ViewModels;

public sealed class NumerologiaView
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime TargetDate { get; set; } = DateTime.Today;

    public ResumenResultadoDto? Resumen { get; set; }
}
