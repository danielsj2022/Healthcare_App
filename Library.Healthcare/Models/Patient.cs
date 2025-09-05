using System.Reflection.Metadata.Ecma335;

namespace Library.Healthcare.Models;

public class Patient
{
    public int PatientId {get; set;}
    public required string Name {get; set;}
    public required string Address {get; set;}
    public required string Birthday {get; set;}
    public required string Race {get; set;}
    public required string Gender {get; set;}
    public string? Diagnosis {get; set;}
    List<string?> prescriptions = new List<string?>();

    public Patient(string name, string address, string bday, string race, string gender, string diagnosis){
        var rand = new Random();
        PatientId = rand.Next();
        Name = name;
        Address = address;
        Birthday = bday;
        Race = race;
        Gender = gender;
        Diagnosis = diagnosis;

    }

    //workout perscript
}
