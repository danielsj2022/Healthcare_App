using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class PhysicianService
{
    public List<Physician> physiciansList = new List<Physician>();

    public void Add(Physician physician){
        physiciansList.Add(physician);
    }
}
