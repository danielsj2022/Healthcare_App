using System;
using Api.Healthcare.Enterprise;
using Library.Healthcare.DTO;
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
    public IEnumerable<PhysicianDTO> Get()
    {
        return new PhysicianEC().GetPhysicians();
    }

    [HttpGet("{physicianId}")]
    public PhysicianDTO? GetPhysicianById(int physicianId)
    {
        return new PhysicianEC().GetPhysiciansById(physicianId);
    }

    [HttpPost]
    public PhysicianDTO? AddPhysician([FromBody] PhysicianDTO physicianDTO)
    {
        return new PhysicianEC().AddPhysician(physicianDTO);
    }

    [HttpPost("Update")]
    public PhysicianDTO? EditPhysician([FromBody] PhysicianDTO physicianDTO)
    {
        return new PhysicianEC().EditPhysician(physicianDTO);
    }

    [HttpDelete("{id}")]
    public PhysicianDTO? DeletePhysician(int id)
    {
        return new PhysicianEC().DeletePhysician(id);
    } 

}
