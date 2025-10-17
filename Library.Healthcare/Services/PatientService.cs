using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class PatientService
{
    private List<Patient?> patientsList;

    private PatientService(){
        patientsList = new List<Patient?>();
    }

    private static PatientService? instance;
    private static object instanceLock = new object();
    public static PatientService Current{
        get{
            lock (instanceLock){
                if (instance == null){
                    instance = new PatientService();
                }
            }
            return instance;
        }
    }

    public List<Patient?> Patients{
        get { return patientsList; }
    }

    public void Add(Patient patient){
        patientsList.Add(patient);
    }

    public void Edit(Patient patient){
        int index = patientsList.IndexOf(patient);
        patientsList.RemoveAt(index);
        patientsList.Insert(index, patient);
    }

    public void Remove(Patient patient){
        patientsList.Remove(patient);
    }

    public Patient? PatientSearchById(int patientId){

        //string? patientIdInput = Console.ReadLine();

        var patient = patientsList
            .Where(p => p != null)
            .FirstOrDefault(p => p?.PatientId == patientId);
        
        return patient;
    }

}
