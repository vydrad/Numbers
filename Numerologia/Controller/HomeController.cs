using Microsoft.AspNetCore.Mvc;
using Numerologia.DTOs;
using Numerologia.Models;
using Numerologia.Services;
using Numerologia.ViewModels;

namespace Numerologia.Controllers;

public sealed class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IServicioPersona _servicioPersona;

    public HomeController(IServicioPersona servicioPersona)
    {
        _servicioPersona = servicioPersona;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new NumerologiaView
        {
            BirthDate = new DateTime(1990, 5, 10),
            TargetDate = DateTime.Today
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(NumerologiaView model)
    {
        if (!this.ModelState.IsValid)
        {
            return View(model);
        }

        var persona = new Persona(model.FirstName, model.LastName, model.BirthDate);
        var resumen = _servicioPersona.GetResumen(persona, model.TargetDate);

        model.Resumen = new ResumenResultadoDto
        {
            LifePathNumber = resumen.LifePathNumber,
            AutoMotivationNumber = resumen.AutoMotivationNumber,
            AutoImageNumber = resumen.AutoImageNumber,
            AutoExpressionNumber = resumen.AutoExpressionNumber,
            AutoMotivationChallengeNumber = resumen.AutoMotivationChallengeNumber,
            AutoImageChallengeNumber = resumen.AutoImageChallengeNumber,
            AutoExpressionChallengeNumber = resumen.AutoExpressionChallengeNumber,
            ChallengeNumbers = resumen.ChallengeNumbers,
            Pinnacles = resumen.Pinnacles,
            PersonalYear = resumen.PersonalYear,
            PersonalMonth = resumen.PersonalMonth,
            PersonalDay = resumen.PersonalDay,
            HeredityNumber = resumen.HeredityNumber,
            CapsuleNumber = resumen.CapsuleNumber,
            TemporalAnnualVibration = resumen.TemporalAnnualVibration is null
                ? null
                : new ResumenResultadoDto().TemporalAnnualVibration
        };

        return View(model);
    }
}
