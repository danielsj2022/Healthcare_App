using System;
using Api.Healthcare.Database;
using Library.Healthcare.Models;

namespace Api.Healthcare.Enterprise;

public class PhysicianEC
{
    public IEnumerable<Physician> GetPhysicians()
    {
        return FakeDatabase.Physicians
            .OrderByDescending(x => x.PhysicianId)
            .Take(100);
    }

    public Physician? GetPhysiciansById(int physicianId)
    {
        return FakeDatabase.Physicians.FirstOrDefault(x => x.PhysicianId == physicianId);
    }

    public Physician? AddPhysician(int lisenseNum, string name, string gradDate, string speacialization){
        Physician physician = new Physician(lisenseNum, name, gradDate, speacialization);
        FakeDatabase.Physicians.Add(physician);
        return physician;
    }
}
