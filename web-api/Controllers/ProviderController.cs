using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]

public class ProviderController : ControllerBase
{

    private readonly ILogger<ProviderController> _logger;

    public ProviderController(ILogger<ProviderController> logger)
    {
        _logger = logger;
    }

    [Route("/Provider/{id}")]
    public Provider Get()
    {
        Provider testProvider = new Provider();
        testProvider.Id = Guid.NewGuid();
        testProvider.FirstName = "first name";
        testProvider.LastName = "last name";
        testProvider.LicenseNumber = 123456;
        testProvider.Address = "1234 Elm St";
        testProvider.CreationTime = DateTimeOffset.Now;
        return testProvider;
    }
}
