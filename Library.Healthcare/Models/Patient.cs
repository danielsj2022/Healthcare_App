using System.Reflection.Metadata.Ecma335;

namespace Library.Healthcare.Models;

public class Patient
{
    public int PatientId {get; set;}
    public string Name {get; set;}
    public string Address {get; set;}
    public string Birthday {get; set;}
    public string Race {get; set;}
    public string Gender {get; set;}
    public string Diagnosis {get; set;}
    //List<string?> prescriptions = new List<string?>();
    public string Prescription{get; set;}

    public Patient(string name, string address, string bday, string race, string gender, string diagnosis, string prescript){
        var rand = new Random();
        PatientId = rand.Next();
        Name = name;
        Address = address;
        Birthday = bday;
        Race = race;
        Gender = gender;
        Diagnosis = diagnosis;
        Prescription = prescript;
    }

    public override string ToString()
    {
        string text = $"PatientId: {PatientId}\nName: {Name}\nAddress: {Address}\nBirthday: {Birthday}\n";
        text += $"Race: {Race}\tGender: {Gender}\nDiagnosis: {Diagnosis}\nPrescription: {Prescription}\n";
        return text;
    }
    //workout perscript
}
