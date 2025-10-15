using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace Maui.Healthcare.ViewModel;

public class AppointmentViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Appointment> Appointments{
        get{
            return new ObservableCollection<Appointment>(AppointmentService.Current.Appointments);
        }
    }
    public void Refresh(){
        NotifyPropertyChanged("Appointments");
    }

    public void Create(){
        Shell.Current.GoToAsync($"//CreateAppt?appointmentId={0}");
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = ""){
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
