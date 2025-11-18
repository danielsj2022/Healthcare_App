using System;
using Api.Healthcare.Database;
using Library.Healthcare.Models;
using Library.Healthcare.DTO;
using Library.Healthcare.Data;

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

    public PhysicianDTO? EditPhysician(PhysicianDTO physicianDTO)
    {
        Physician updatedPhysician = new Physician(physicianDTO);
        var oldPhysician = FakeDatabase.Physicians.FirstOrDefault(x => x.PhysicianId == physicianDTO.PhysicianId);
        
        if (oldPhysician != null)
        {
            var index = FakeDatabase.Physicians.IndexOf(oldPhysician);
            FakeDatabase.Physicians.Remove(oldPhysician);
            FakeDatabase.Physicians.Insert(index, updatedPhysician);
            return physicianDTO;
        }
        else
        {
            return null;
        }

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

    public IEnumerable<PhysicianDTO?> SearchPhysician(string query)
    {
        return FakeDatabase.Physicians.Where(
            //b?.Title?.ToUpper()?.Contains(query?.ToUpper() ?? string.Empty) ?? false
            p => (p?.PhysicianId.ToString().ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
                || (p?.LisenceNumber.ToString().ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
                || (p?.Name.ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
                || (p?.GraduationDate.ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
                || (p?.Specialization.ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
                || (p?.Availability.ToString().ToUpper().Contains(query.ToUpper() ?? string.Empty) ?? false)
        ).Select(p => new PhysicianDTO(p));
    }
}
