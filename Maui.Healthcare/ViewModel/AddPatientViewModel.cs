using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace Maui.Healthcare.ViewModel;

public partial class AddPatientViewModel : ObservableObject
{
    private int PatientId { get; set; }
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string address;
    [ObservableProperty]
    private string birthday;
    [ObservableProperty]
    private string race;
    [ObservableProperty]
    private string gender;
    [ObservableProperty]
    private string diagnosis;
    [ObservableProperty]
    private string prescription;
    

    public void ResetForm(int patientId){
        PatientId = patientId;
        if(patientId == 0){ //selected user is none, so add new; clear fields
            Name = string.Empty;
            Address = string.Empty;
            Birthday = string.Empty;
            Race = string.Empty;
            Gender = string.Empty;
            Diagnosis = string.Empty;
            Prescription = string.Empty;
        } else{
            var patient = PatientService.Current.PatientSearchById(PatientId);
            if(patient != null){
                Name = patient.Name;
                Address = patient.Address;
                Birthday = patient.Birthday;
                Race = patient.Race;
                Gender = patient.Gender;
                Diagnosis = patient.Diagnosis;
                Prescription = patient.Prescription;
            }
        }
    }

    public bool IsFormValid =>
        !string.IsNullOrWhiteSpace(Name) &&
        !string.IsNullOrWhiteSpace(Address) &&
        !string.IsNullOrWhiteSpace(Birthday) &&
        !string.IsNullOrWhiteSpace(Race) &&
        !string.IsNullOrWhiteSpace(Gender);

    public AddPatientViewModel(){   //check if any fields changed real time; if so call isformvalid
        PropertyChanged += (_, e) => {
            if (e.PropertyName == nameof(Name) || e.PropertyName == nameof(Address) || 
                e.PropertyName == nameof(Birthday) || e.PropertyName == nameof(Race) || e.PropertyName == nameof(Gender)){
                    OnPropertyChanged(nameof(IsFormValid));
                }
        };

    }

    [RelayCommand]
    private void Submit(){
        if(Diagnosis == null){
            Diagnosis = "none";
        }
        if(Prescription == null){
            Prescription = "none";
        }
        var patient = PatientService.Current.PatientSearchById(PatientId);
        if(patient == null){    //patient dne
           var newPatient = new Patient(Name, Address, Birthday, Race, Gender, Diagnosis, Prescription);
           PatientService.Current.Add(newPatient); 
        } else{     //update then add
            patient.Name = Name;
            patient.Address = Address;
            patient.Birthday = Birthday;
            patient.Race = Race;
            patient.Gender = Gender;
            patient.Diagnosis = Diagnosis;
            patient.Prescription = Prescription;
            PatientService.Current.Edit(patient);
        }

        //Shell.Current.GoToAsync($"//Patient?selectedPatient={null}");
                Shell.Current.GoToAsync("//Patient");
    }
    [RelayCommand]
    private void Cancel(){
        Shell.Current.GoToAsync("//Patient");
    }    
   
}
