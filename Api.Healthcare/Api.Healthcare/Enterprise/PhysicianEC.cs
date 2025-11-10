using System;
using Api.Healthcare.Database;
using Library.Healthcare.Models;
using Library.Healthcare.DTO;

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

    // public Physician? AddPhysician(int lisenseNum, string name, string gradDate, string speacialization){
    //     Physician physician = new Physician(lisenseNum, name, gradDate, speacialization);
    //     FakeDatabase.Physicians.Add(physician);
    //     return physician;
    // }
    public Physician? AddPhysician(PhysicianDTO physicianDTO)
    {
        //var lNumber = physicianDTO.LisenceNumber;
        Physician physician = new Physician(physicianDTO.LisenceNumber, physicianDTO.Name, physicianDTO.GraduationDate, physicianDTO.Specialization);
        FakeDatabase.Physicians.Add(physician);
        return physician;
    }
    // var newPhysician = PhysicianEC().AddPhysician(
    //     //     physicianDTO.lisenceNumber, physicianDTO.name, physicianDTO.graduationDate, physicianDTO.specialization
    //     // );
}
