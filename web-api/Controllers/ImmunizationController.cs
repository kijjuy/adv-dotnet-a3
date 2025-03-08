using Microsoft.AspNetCore.Mvc;
using web_api.Models;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImmunizationController : ControllerBase
{

    private readonly ILogger<ImmunizationController> _logger;

    private readonly ApplicationDbContext _context;



    public ImmunizationController(ILogger<ImmunizationController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        _logger.LogInformation("Hello from controller constructor");
    }

    [HttpGet("{id}")]
    public Immunization Get(Guid id)
    {
        _logger.LogInformation("Hit Immunization get method");
        var immunization = _context.ImmunizationItems.Where(item => id == item.Id).FirstOrDefault();
        return immunization;
    }

    [HttpPost]
    public async Task<ActionResult<Immunization>> NewImmunization(Immunization immunization)
    {
        _logger.LogInformation("Hit NewImmunization endpoint");
        Immunization newImmunization = new Immunization
        {
            Id = Guid.NewGuid(),
            CreationTime = DateTimeOffset.Now,
            OfficialName = immunization.OfficialName,
            TradeName = immunization.TradeName,
            LotNumber = immunization.LotNumber,
            ExpirationDate = immunization.ExpirationDate,
        };

        _context.ImmunizationItems.Add(immunization);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Added new immunization to database.");

        return CreatedAtAction("NewImmunization", new { id = newImmunization.Id }, newImmunization);
    }


}

