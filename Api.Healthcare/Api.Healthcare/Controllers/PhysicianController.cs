using System;
using Api.Healthcare.Database;
using Api.Healthcare.Enterprise;
using Library.Healthcare.Data;
using Library.Healthcare.DTO;
using Library.Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Healthcare.Controllers;

[ApiController]
[Route("[controller]")]
public class PhysicianController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<PhysicianController> _logger;
    // public PhysicianController(AppDbContext context)
    // {
    //     _context = context;
    // }
    public PhysicianController(ILogger<PhysicianController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IEnumerable<PhysicianDTO> Get()
    {
        var physicians = _context.Physicians.ToList().Select
        (
            p =>  new PhysicianDTO(p)
        );
        return physicians;

        //return _context.Physicians.ToList();
        //return new PhysicianEC().GetPhysicians();
    }

    [HttpGet("{physicianId}")]
    public PhysicianDTO? GetPhysicianById(int physicianId)
    {

        return new PhysicianEC().GetPhysiciansById(physicianId);
    }

    [HttpPost]
    public PhysicianDTO? AddPhysician([FromBody] PhysicianDTO physicianDTO)
    {
        Physician physician = new Physician(physicianDTO.LisenceNumber, physicianDTO.Name, physicianDTO.GraduationDate, physicianDTO.Specialization);
        _context.Physicians.Add(physician);
        _context.SaveChanges();
        return physicianDTO;

        //return new PhysicianEC().AddPhysician(physicianDTO);
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

    [HttpPost("Search")] 
    public IEnumerable<PhysicianDTO?> SearchPhysician([FromBody] QueryRequest query)
    {
        return new PhysicianEC().SearchPhysician(query.Content);
    }

}
