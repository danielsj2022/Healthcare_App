
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Library.Healthcare.DTO;
using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace Maui.Healthcare.ViewModel;

public partial class AddPhysicianViewModel : ObservableObject, IQueryAttributable
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
            
            var existingPhysician =  PhysicianService.Current.PhysicianSearchById(physicianIdd);
            PhysicianId = physicianIdd;
            LicenceNumber = existingPhysician.LisenceNumber.ToString();
            Name = existingPhysician.Name;
            GradDate = existingPhysician.GraduationDate;
            Specialization = existingPhysician.Specialization;
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

    public void ApplyQueryAttributes(IDictionary<string, object> query)
{
    if (query.TryGetValue("physicianId", out var idObj) && idObj != null)
    {
        int id = Convert.ToInt32(idObj);
        ResetForm(id); 
    }
    else
    {
        ResetForm(0);
    }
}

    [RelayCommand]
    private async Task<bool> Submit(){  //need to add for edit instead of just add to list
        int lNumber = int.Parse(LicenceNumber);
        var physicianDTO = PhysicianService.Current.PhysicianSearchById(PhysicianId);
        try
        {
            if (physicianDTO == null)
            {
                Physician newPhysician = new Physician(lNumber, Name, GradDate, Specialization);
                //need to go from obj -> dto; then add
                PhysicianDTO newPhysicianDTO = new PhysicianDTO(newPhysician);
                await PhysicianService.Current.Add(newPhysicianDTO);	//func is type safe
            }
            else
            {
                physicianDTO.LisenceNumber = lNumber;
                physicianDTO.Name = Name;
                physicianDTO.GraduationDate = GradDate;
                physicianDTO.Specialization = Specialization;
                PhysicianService.Current.Edit(physicianDTO);
            }
            
        }catch(Exception e)
        {
            Debug.WriteLine(e.ToString());
            await Shell.Current.DisplayAlert("Error", e.Message, "OK");
            return false;
        }
        await Shell.Current.GoToAsync("//Physician");
        return true;
    }

    [RelayCommand]
    private void Cancel(){
        Shell.Current.GoToAsync("//PhysicianView");
    }
}
