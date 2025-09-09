using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class PatientService
{
    public List<Patient?> patientsList = new List<Patient?>();

    public void Add(Patient patient){
        patientsList.Add(patient);
    }

    public void Remove(Patient patient){
        patientsList.Remove(patient);
    }

}
