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
    public Patient? SelectedPatient { get; set; }
    public Appointment? SelectedAppointment { get; set; } 
    public AppointmentViewModel ApptVM {get;}
    public PatientViewViewModel(){
        ApptVM = new AppointmentViewModel();
    }
    public ObservableCollection<Patient> Patients{
        get{
            return new ObservableCollection<Patient>(PatientService.Current.Patients);
        }
    }
    public void Refresh(){
        NotifyPropertyChanged("Patients");
        //NotifyPropertyChanged(nameof(ApptVM.Appointments));
        ApptVM.Refresh();
    }

    public void Add(){
        Shell.Current.GoToAsync($"//AddPatient?patientId={0}");
        SelectedPatient=null;
        NotifyPropertyChanged(nameof(SelectedPatient));
    }

    public void Edit(){
        if(SelectedPatient == null){
            return;
        }
        var patientId = SelectedPatient.PatientId;
        //SelectedPatient = null;
        Shell.Current.GoToAsync($"//AddPatient?patientId={patientId}");
        SelectedPatient = null;
        NotifyPropertyChanged(nameof(SelectedPatient));

    }

    public void Delete(){
        if(SelectedPatient == null){
            return;
        }
        PatientService.Current.Remove(SelectedPatient);
        SelectedPatient = null;
        NotifyPropertyChanged(nameof(Patients));
    }

    public void CreateAppt()
    {
        ApptVM.Create();
    }
    public void EditAppt()
    {
        if(SelectedAppointment == null)
        {
            return;
        }
        ApptVM.Edit(SelectedAppointment);
        NotifyPropertyChanged(nameof(SelectedAppointment));
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = ""){
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
