using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]

public class OrganizationController : ControllerBase
{

    private readonly ILogger<OrganizationController> _logger;

    public OrganizationController(ILogger<OrganizationController> logger)
    {
        _logger = logger;
    }

    [Route("/Organization/{id}")]
    public Organization Get()
    {
        Organization testOrganization = new Organization();
        testOrganization.Id = Guid.NewGuid();
        testOrganization.Name = "name";
        testOrganization.Type = "type";
        testOrganization.Address = "1234 Elm St";
        testOrganization.CreationTime = DateTimeOffset.Now;
        return testOrganization;
    }
}