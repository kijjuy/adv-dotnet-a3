using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientController : ControllerBase
{

    private readonly ApplicationDbContext _context;
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        }


    //POST /Patient
    [HttpPost]
    public async Task<IActionResult> CreatePatient(Patient patient)
    {
        if (patient == null)
        {
            return BadRequest(new { Message = "Patient is null", StatusCode = 400 });
        }

        _context.Patients.Add(patient);
        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException) {
            return Conflict(new { Message = "Patient already exists", StatusCode = 409 });

        }

        var acceptHeader = Request.Headers["Accept"].ToString();
        _logger.LogInformation("Accept Header: " + acceptHeader);

        if (acceptHeader == "application/xml")
        {
            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        else if (acceptHeader == "application/json") //if accpet header is json
        {
            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        } else {
            return StatusCode(406, new { Message = "Not Acceptable", StatusCode = 406 });
        }
    }


    //GET /Patient/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return NotFound(new { Message = "Patient not found", StatusCode = 404 });
        }

        var acceptHeader = Request.Headers["Accept"].ToString();
        if (acceptHeader == "application/xml")
        {
            return Ok(patient);
        }

        else if (acceptHeader == "application/json") //if accpet header is json
        {
            return Ok(patient);
        } else {
            return StatusCode(406, new { Message = "Not Acceptable", StatusCode = 406 });
        }
    }


    //PUT /Patient/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(Guid id, Patient patient)
    {
        if (id != patient.Id){
            return BadRequest(new { Message = "Id mismatch", StatusCode = 400 });
        }

        _context.Entry(patient).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException){
            if (!PatientExists(id)){
                return NotFound(new { Message = "Patient not found", StatusCode = 404 });
            }
            else {
                throw;
            }
        }

        return NoContent();
    }









    //check if patient exists by id
    private bool PatientExists(Guid id)
    {
        return _context.Patients.Any(e => e.Id == id);
    }






}