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

    public string Display{
        get{ return ToString();}
    }

    public override string ToString()
    {
        string text = $"PatientId: {PatientId} Name: {Name} Address: {Address} Birthday: {Birthday} ";
        text += $"Race: {Race} Gender: {Gender} Diagnosis: {Diagnosis} Prescription: {Prescription}";
        return text;
    }
    //workout perscript
}
