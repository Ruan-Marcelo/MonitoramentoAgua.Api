
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoramentoAgua.Api.Data;
using MonitoramentoAgua.Api.DTOs;
using MonitoramentoAgua.Api.Models;

namespace MonitoramentoAgua.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicoesController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public MedicoesController(
        AppDbContext context,
        IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(
        [FromBody] CriarMedicaoDto dto)
    {
        var alturaUtil = _configuration.GetValue<decimal>(
            "Reservatorio:AlturaUtilCm");

        if (alturaUtil <= 0)
        {
            return BadRequest("Altura do reservatório inválida.");
        }

        var nivelCm = Math.Clamp(
            alturaUtil - dto.DistanciaCm,
            0m,
            alturaUtil);

        var percentual = Math.Round(
            (nivelCm / alturaUtil) * 100m, 2);

        var medicao = new MedicaoAgua
        {
            DistanciaCm = dto.DistanciaCm,
            NivelCm = nivelCm,
            NivelPercentual = percentual,
            DataHora = DateTime.UtcNow
        };

        _context.Medicoes.Add(medicao);

        await _context.SaveChangesAsync();

        return Ok(medicao);
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var medicoes = await _context.Medicoes
            .AsNoTracking()
            .OrderByDescending(m => m.DataHora)
            .ToListAsync();

        return Ok(medicoes);
    }

    [HttpGet("ultima")]
    public async Task<IActionResult> ObterUltima()
    {
        var medicao = await _context.Medicoes
            .AsNoTracking()
            .OrderByDescending(m => m.DataHora)
            .FirstOrDefaultAsync();

        if (medicao == null)
        {
            return NotFound("Nenhuma medição encontrada.");
        }

        return Ok(medicao);
    }
}
