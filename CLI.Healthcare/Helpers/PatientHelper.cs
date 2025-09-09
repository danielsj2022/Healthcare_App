using System;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace CLI.Healthcare.Helpers;

public class PatientHelper
{
    //private List<Patient?> patients = new List<Patient?>();
    private PatientService patientService = new PatientService();

    public void CreatePatient(){
        //Patient(string name, string address, string bday, string race, string gender, string diagnosis)
        Console.Write("Enter name: ");
        string? name = Console.ReadLine();
        while(string.IsNullOrEmpty(name)){
            Console.Write("Enter valid name: ");
            name = Console.ReadLine();
        }
        Console.Write("Enter address: ");
        string? address = Console.ReadLine();
        while(string.IsNullOrEmpty(address)){
            Console.Write("Enter valid address: ");
            address = Console.ReadLine();
        }
        Console.Write("Enter birthday(##/##/####): ");
        string? bday = Console.ReadLine();
        while(string.IsNullOrEmpty(bday)){
            Console.Write("Enter valid birthday: ");
            bday = Console.ReadLine();
        }
        Console.Write("Enter race: ");
        string? race = Console.ReadLine();
        while(string.IsNullOrEmpty(race)){
            Console.Write("Enter valid race: ");
            race = Console.ReadLine();
        }
        Console.Write("Enter gender: ");
        string? gender = Console.ReadLine();
        while(string.IsNullOrEmpty(gender)){
            Console.Write("Enter valid gender: ");
            gender = Console.ReadLine();
        }
        Console.Write("Enter diagnosis (leave blank if empty): ");
        string? diagnosis = Console.ReadLine();
        if(string.IsNullOrEmpty(diagnosis)){
            diagnosis="none";
        }
        Console.Write("Enter prescription (leave blank if empty): ");
        string? prescript = Console.ReadLine();
        if(string.IsNullOrEmpty(prescript)){
            prescript="none";
        }
        //here
        Patient patient = new Patient(name, address, bday, race, gender, diagnosis, prescript);
        patientService.Add(patient);
        Console.WriteLine($"Patient Id is: {patient.PatientId}\n");
    }

    public Patient? PatientSearchById(){
        //need search by id
        //1. find patient
        
        Console.WriteLine("Enter PatientId: ");
        string? patientIdInput = Console.ReadLine();
       
        if(int.TryParse(patientIdInput, out int patientId)){
            //look in patientList
            Console.WriteLine("printing patinest");
            patientService.patientsList.ForEach(Console.WriteLine);
            var patient = patientService.patientsList
                .Where(p => p != null)
                .FirstOrDefault(p => p.PatientId == patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
            } else{ 
                return patient; 
            }
        } else{
            Console.WriteLine("Invalid patient Id");
        }
        return null;
        
    }
    public void ListPatients(){
        patientService.patientsList.ForEach(Console.WriteLine);
    }
}
