using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LF.Models;
using LF.Data;

namespace LF.Controllers;

public class RecettesController : Controller
{
    private readonly ILogger<RecettesController> _logger;
    private readonly ApplicationDbContext _context;

    public RecettesController(ILogger<RecettesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Interieures()
    {
        // Récupérer les recettes intérieures avec leurs natures d'impôts
        var recettes = await _context.RecettesInterieurs
            .Include(r => r.NatureImpot)
            .OrderBy(r => r.Annee)
            .ThenBy(r => r.NatureImpot.IdNatureImpots)
            .ToListAsync();

        return View(recettes);
    }

    public async Task<IActionResult> Douanieres()
    {
        // Récupérer les recettes douanières avec leurs natures de droits et taxes
        var recettes = await _context.RecettesDouanieres
            .Include(r => r.NatureDroitsetTaxes)
            .OrderBy(r => r.Annee)
            .ThenBy(r => r.NatureDroitsetTaxes.IdNatureDroitsetTaxes)
            .ToListAsync();

        // Récupérer les recettes intérieures pour le graphique
        var recettesInterieures = await _context.RecettesInterieurs
            .ToListAsync();

        // Calculer les totaux pour le graphique
        var totalInterieures2024 = (double)recettesInterieures.Where(r => r.Annee == 2024).Sum(r => r.Montant);
        var totalInterieures2025 = (double)recettesInterieures.Where(r => r.Annee == 2025).Sum(r => r.Montant);
        var totalDouanieres2024 = (double)recettes.Where(r => r.Annee == 2024).Sum(r => r.Montant);
        var totalDouanieres2025 = (double)recettes.Where(r => r.Annee == 2025).Sum(r => r.Montant);

        // Passer les données via ViewBag (en utilisant la culture invariante pour JavaScript)
        ViewBag.TotalInterieures2024 = totalInterieures2024.ToString(System.Globalization.CultureInfo.InvariantCulture);
        ViewBag.TotalInterieures2025 = totalInterieures2025.ToString(System.Globalization.CultureInfo.InvariantCulture);
        ViewBag.TotalDouanieres2024 = totalDouanieres2024.ToString(System.Globalization.CultureInfo.InvariantCulture);
        ViewBag.TotalDouanieres2025 = totalDouanieres2025.ToString(System.Globalization.CultureInfo.InvariantCulture);

        return View(recettes);
    }
}
