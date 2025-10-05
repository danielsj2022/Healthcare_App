
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        Shell.Current.GoToAsync("//Physician");
    }
    private void Cancel(){
        Shell.Current.GoToAsync("//PhysicianView");
    }
}
