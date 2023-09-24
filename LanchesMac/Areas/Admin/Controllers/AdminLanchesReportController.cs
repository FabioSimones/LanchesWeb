using FastReport.Data;
using FastReport.Web;
using LanchesMac.Areas.Admin.FastReportUtils;
using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLanchesReportController : Controller
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly RelatorioLanchesService _relatorioLanchesService;

    public AdminLanchesReportController(IWebHostEnvironment webHostEnvironment, RelatorioLanchesService relatorioLanchesService)
    {
        _webHostEnvironment = webHostEnvironment;
        _relatorioLanchesService = relatorioLanchesService;
    }

    public async Task<ActionResult> LanchesCategoriaReport() 
    {
        var webReport = new WebReport();
        var mssqlDataConnection = new MsSqlDataConnection();

        webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        webReport.Report.Load(Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/reports", 
                                            "lanchesCategorias.frx"));

        var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(), "LanchesReport");
        var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(), "CategoriasReport");

        webReport.Report.RegisterData(lanches, "LancheReport");
        webReport.Report.RegisterData(categorias, "CategoriasReport");

        return View(webReport);
    }
}
