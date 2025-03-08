using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{

    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    [Route("/Patient/{id}")]
    public Patient Get()
    {
        Patient testPatient = new Patient();
        testPatient.Id = Guid.NewGuid();
        testPatient.FirstName = "first name";
        testPatient.LastName = "last name";
        testPatient.DateOfBirth = DateTimeOffset.Now;
        testPatient.CreationTime = DateTimeOffset.Now;
        return testPatient;
    }
}