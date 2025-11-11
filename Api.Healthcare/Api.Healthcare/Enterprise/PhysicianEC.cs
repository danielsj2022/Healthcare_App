using System;
using Api.Healthcare.Database;
using Library.Healthcare.Models;
using Library.Healthcare.DTO;

namespace Api.Healthcare.Enterprise;

public class PhysicianEC
{
    public IEnumerable<PhysicianDTO> GetPhysicians()
    {
        return FakeDatabase.Physicians
            .Select(x => new PhysicianDTO(x))
            .OrderByDescending(x => x.PhysicianId)
            .Take(100);
    }

    public PhysicianDTO? GetPhysiciansById(int physicianId)
    {
        var physician = FakeDatabase.Physicians.FirstOrDefault(x => x.PhysicianId == physicianId);
        if (physician != null)
        {
            return new PhysicianDTO(physician);
        }
        else
        {
            return null;
        }
        
    }

    public PhysicianDTO? AddPhysician(PhysicianDTO physicianDTO)
    {
        //var lNumber = physicianDTO.LisenceNumber;
        Physician physician = new Physician(physicianDTO.LisenceNumber, physicianDTO.Name, physicianDTO.GraduationDate, physicianDTO.Specialization);
        FakeDatabase.Physicians.Add(physician);
        return new PhysicianDTO(physician);
    }
    
    public PhysicianDTO? DeletePhysician(int physicianId)
    {
        var physician = FakeDatabase.Physicians.FirstOrDefault(x => x.PhysicianId == physicianId);
        if(physician != null)
        {
            FakeDatabase.Physicians.Remove(physician);
            return new PhysicianDTO(physician);
        }
        else
        {
            return null;
        }

    }
}
