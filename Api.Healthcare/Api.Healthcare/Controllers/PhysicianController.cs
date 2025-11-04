using System;
using Microsoft.AspNetCore.Mvc;

namespace Api.Healthcare.Controllers;

[ApiController]
[Route("[controller]")]
public class PhysicianController : Controller
{
    private readonly ILogger<PhysicianController> _logger;
    public PhysicianController(ILogger<PhysicianController> logger)
    {
        _logger = logger;
    }

}
