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
        _logger.LogDebug("Hello from controller constructor");
    }

    [HttpGet("{id}")]
    public ActionResult<Immunization> Get(Guid id)
    {
        _logger.LogDebug("Hit Immunization get method");

	if (id == null || id.Equals(Guid.Empty)) {
	    throw new BadHttpRequestException("Id is null");
	}

        var immunization = _context.ImmunizationItems.Where(item => id == item.Id).FirstOrDefault();
	if(immunization == null) {
	    return NotFound("Cound not find Immunization with id="+id);
	}
        return Ok(immunization);
    }

    [HttpPost]
    public async Task<ActionResult<Immunization>> NewImmunization([FromForm] Immunization immunization)
    {
        _logger.LogDebug("Hit NewImmunization endpoint");

	if(immunization == null) {
	    throw new BadHttpRequestException("Immunization is null");
	}

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

