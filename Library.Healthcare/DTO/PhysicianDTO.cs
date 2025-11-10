using System;
using Library.Healthcare.Models;
namespace Library.Healthcare.DTO;

public class PhysicianDTO
{
    public int PhysicianId {get; set;}
    public int LisenceNumber {get; set;}
    public string Name {get; set;}
    public string GraduationDate {get; set;}
    public string Specialization {get; set;}
    public bool Availability { get; set; }

    public PhysicianDTO(int licenseNum, string name, string gradDate, string specialization)
    {
        //var rand = new Random();
        //PhysicianId = rand.Next();
        LisenceNumber = licenseNum;
        Name = name;
        GraduationDate = gradDate;
        Specialization = specialization;
        Availability = true;
    }
    public PhysicianDTO()
    {

    }

    public PhysicianDTO(Physician physician)
    {
        PhysicianId = physician.PhysicianId;
        LisenceNumber = physician.LisenceNumber;
        Name = physician.Name;
        GraduationDate = physician.GraduationDate;
        Specialization = physician.Specialization;
        Availability = physician.Availability;
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
