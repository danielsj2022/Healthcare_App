
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

    public bool IsFormValid =>
        !string.IsNullOrWhiteSpace(LicenceNumber) &&
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
    private void Submit(){
        int lNumber = int.Parse(LicenceNumber);
        Physician physician= new Physician(lNumber, Name, GradDate, Specialization);
        PhysicianService.Current.Add(physician);	//func is type safe
        Console.Write(physician.ToString());

        Shell.Current.GoToAsync("//Physician");
    }

    [RelayCommand]
    private void Cancel(){
        Shell.Current.GoToAsync("//PhysicianView");
    }
}
