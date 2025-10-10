using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Maui.Healthcare.Views;

namespace Maui.Healthcare.ViewModel;

public class PatientViewViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public PatientView? SelectedPatient { get; set; }
    public ObservableCollection<Patient> Patients{
        get{
            return new ObservableCollection<Patient>(PatientService.Current.Patients);
        }
    }
    public void Refresh(){
        NotifyPropertyChanged("Patients");
    }

    public void Add(){
        Shell.Current.GoToAsync($"//AddPatient?patientId={0}");
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = ""){
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
