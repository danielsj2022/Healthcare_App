using System;
using Library.Healthcare.DTO;

namespace Library.Healthcare.Models;

public class Physician
{
    public int PhysicianId {get; set;}
    public int LisenceNumber {get; set;}
    public string Name {get; set;}
    public string GraduationDate {get; set;}
    public string Specialization {get; set;}
    public bool Availability {get; set;}

    public Physician(){}

    public Physician(int licenseNum, string name, string gradDate, string specialization)
    {
        var rand = new Random();
        PhysicianId = rand.Next();
        LisenceNumber = licenseNum;
        Name = name;
        GraduationDate = gradDate;
        Specialization = specialization;
        Availability = true;
    }
    
    public Physician(PhysicianDTO physicianDTO)
    {
        PhysicianId = physicianDTO.PhysicianId;
        LisenceNumber = physicianDTO.LisenceNumber;
        Name = physicianDTO.Name;
        GraduationDate = physicianDTO.GraduationDate;
        Specialization = physicianDTO.Specialization;
        Availability = physicianDTO.Availability;
    }

    public string Display{
        get { return ToString(); }
    }
    public override string ToString()
    {
        string text = $"Physician Id: {PhysicianId} Licence Number: {LisenceNumber} Name: {Name} Graduation Date: {GraduationDate} Speacialization: {Specialization} Availability: {Availability}";
        return text;
    }
}
