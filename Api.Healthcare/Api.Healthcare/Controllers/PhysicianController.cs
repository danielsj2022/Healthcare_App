using System;
using Api.Healthcare.Enterprise;
using Library.Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Healthcare.Controllers;

[ApiController]
[Route("[controller]")]
public class PhysicianController : ControllerBase
{
    private readonly ILogger<PhysicianController> _logger;
    public PhysicianController(ILogger<PhysicianController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Physician> Get()
    {
        return new PhysicianEC().GetPhysicians();
    }

    [HttpGet("{physicianId}")]
    public Physician? GetPhysicianById(int physicianId)
    {
        return new PhysicianEC().GetPhysiciansById(physicianId);
    }

    [HttpPost]
    public Physician? AddPhysician(int lisenseNum, string name, string gradDate, string speacialization)
    {
        return new PhysicianEC().AddPhysician(lisenseNum, name, gradDate, speacialization);  
    }

}
