
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using System;

namespace Maui.Healthcare.ViewModel;

public partial class AddPhysicianViewModel : ObservableObject
{
    [ObservableProperty]
    private string licenceNumber;
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string gradDate;
    [ObservableProperty]
    private string specialization;

    //public int PhysicianId { get; set; }
    [ObservableProperty]
    public int physicianId;

    public void ResetForm(int physicianIdd){
        if(physicianIdd == 0){
            LicenceNumber = string.Empty;
            Name = string.Empty;
            GradDate = string.Empty;
            Specialization = string.Empty;
            PhysicianId = physicianIdd;
        }//need to load old info
        else{
            
            var physician =  PhysicianService.Current.PhysicianSearchById(physicianIdd);
            PhysicianId = physicianIdd;
            LicenceNumber = physician.LisenceNumber.ToString();
            Name = physician.Name;
            GradDate = physician.GraduationDate;
            Specialization = physician.Specialization;
        }
        
    }

    public bool IsFormValid =>
        !string.IsNullOrWhiteSpace(LicenceNumber) &&
        int.TryParse(LicenceNumber, out _) &&
        !string.IsNullOrWhiteSpace(Name) &&
        !string.IsNullOrWhiteSpace(GradDate) &&
        !string.IsNullOrWhiteSpace(Specialization);

    public AddPhysicianViewModel(){
        PropertyChanged += (_, e) => {
            if (e.PropertyName == nameof(LicenceNumber) || e.PropertyName == nameof(Name) || 
                e.PropertyName == nameof(GradDate) || e.PropertyName == nameof(Specialization)){
                    OnPropertyChanged(nameof(IsFormValid));
                }
        };

    }

    [RelayCommand]
    private void Submit(){  //need to add for edit instead of just add to list
        int lNumber = int.Parse(LicenceNumber);
        var physician = PhysicianService.Current.PhysicianSearchById(PhysicianId);
        if (physician == null){
            Physician newPhysician= new Physician(lNumber, Name, GradDate, Specialization);
            PhysicianService.Current.Add(newPhysician);	//func is type safe
        } else{
            physician.LisenceNumber = lNumber;
            physician.Name = Name;
            physician.GraduationDate = GradDate;
            physician.Specialization = Specialization;
            PhysicianService.Current.Edit(physician);
        }
        
        Shell.Current.GoToAsync("//Physician");
    }

    [RelayCommand]
    private void Cancel(){
        Shell.Current.GoToAsync("//PhysicianView");
    }
}
