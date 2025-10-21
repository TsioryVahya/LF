using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LF.Models;
using LF.Data;

namespace LF.Controllers;

public class DepensesController : Controller
{
    private readonly ILogger<DepensesController> _logger;
    private readonly ApplicationDbContext _context;

    public DepensesController(ILogger<DepensesController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> ParNature()
    {
        // Récupérer les dépenses par nature avec leurs natures
        var depenses = await _context.DepensesParNature
            .Include(d => d.NatureDepenses)
            .OrderBy(d => d.Annee)
            .ThenBy(d => d.NatureDepenses.IdNatureDepenses)
            .ToListAsync();

        return View(depenses);
    }

    public async Task<IActionResult> Fonctionnement()
    {
        // Récupérer les dépenses de fonctionnement
        var depenses = await _context.DepensesFonctionnement
            .OrderBy(d => d.Annee)
            .ToListAsync();

        return View(depenses);
    }

    public async Task<IActionResult> Investissement()
    {
        // Récupérer les dépenses d'investissement
        var depenses = await _context.DepensesInvestissement
            .OrderBy(d => d.Annee)
            .ToListAsync();

        return View(depenses);
    }

    public async Task<IActionResult> Administratives()
    {
        // Récupérer les dépenses administratives
        var depenses = await _context.DepensesAdministratives
            .OrderBy(d => d.Annee)
            .ThenBy(d => d.Institution)
            .ToListAsync();

        return View(depenses);
    }

    public async Task<IActionResult> SoldePensions()
    {
        // Récupérer les dépenses de solde et pensions
        var depenses = await _context.DepensesSoldePensions
            .OrderBy(d => d.Annee)
            .ToListAsync();

        return View(depenses);
    }

    public async Task<IActionResult> DeficitBudgetaire()
    {
        // Récupérer les données du déficit budgétaire
        var deficit = await _context.DeficitBudgetaire
            .OrderBy(d => d.Annee)
            .ToListAsync();

        return View(deficit);
    }
}
