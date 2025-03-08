using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImmunizationController : ControllerBase
{

    private readonly ILogger<ImmunizationController> _logger;

    public ImmunizationController(ILogger<ImmunizationController> logger)
    {
        _logger = logger;
    }

    [Route("/Immunization/{id}")]
    public Immunization Get()
    {
        Immunization testImmunization = new Immunization();
        testImmunization.Id = Guid.NewGuid();
        testImmunization.LotNumber = "lot number";
        testImmunization.TradeName = "trade name";
        testImmunization.UpdatedTime = DateTimeOffset.Now;
        testImmunization.CreationTime = DateTimeOffset.Now;
        testImmunization.OfficialName = "official name";
        testImmunization.ExpirationDate = DateTimeOffset.Now;
        return testImmunization;
    }
}

