using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Library.Healthcare.DTO;
namespace Maui.Healthcare.ViewModel;

public partial class CreateApptViewModel : ObservableObject 
{
    [ObservableProperty]
    private string patientId;
    [ObservableProperty]
    private string weekday;
    [ObservableProperty]
    private string time;
    [ObservableProperty]
    private string timeOfDay;
    [ObservableProperty]
    public bool isLocked = false;  //for patientId when editing

    private int AppointmentId { get; set; }

    private WeekdayEnum DayEnum { get; set; }
    private string AcceptedTime { get; set; }    

    public void ResetForm(int appointmentId){
        AppointmentId = appointmentId;
        if(appointmentId == 0){ //selected user is none, so add new; clear fields
            IsLocked = false;
            PatientId = string.Empty;
            Weekday = string.Empty;
            Time = string.Empty;
            TimeOfDay = string.Empty;
        } else{
            IsLocked = true;
            var appointment = AppointmentService.Current.AppointmentSearch(appointmentId);
            if(appointment != null)
            {
                PatientId = appointment.Patient.PatientId.ToString();
                Weekday = appointment.Day.ToString();
                if (Weekday.Equals("Thursday"))
                {
                    Weekday = Weekday[..2];
                }
                else{
                    Weekday = Weekday[0].ToString();
                }
                string storedTime = appointment.Time;
                Time = storedTime[..^2];
                TimeOfDay = storedTime[^2..];
            }
        }
    }

    public bool IsFormValid =>
        !string.IsNullOrWhiteSpace(PatientId) &&
        int.TryParse(PatientId, out _) &&
        !string.IsNullOrWhiteSpace(Weekday) &&
        DayChecker(Weekday) &&
        !string.IsNullOrWhiteSpace(Time) &&
        !string.IsNullOrWhiteSpace(TimeOfDay) &&
        TimeChecker(Time, TimeOfDay);

    public CreateApptViewModel(){
        PropertyChanged += (_, e) => {
            if (e.PropertyName == nameof(PatientId) || e.PropertyName == nameof(Weekday) || 
                e.PropertyName == nameof(Time) || e.PropertyName == nameof(TimeOfDay)){
                    OnPropertyChanged(nameof(IsFormValid));
                }
        };
    }

    [RelayCommand]
    public void Submit(){   //add functionality for edit and deselect selectedAppt
        int patientId = int.Parse(PatientId);
        
        if(AppointmentId == 0){
            var patient = PatientService.Current.PatientSearchById(patientId);
            if(patient != null){    //patient exist
                var physicianDTO = PhysicianService.Current.PhysicianSearchByAvailability();
                if(physicianDTO != null){
                    Appointment appt = new Appointment(patient, physicianDTO, DayEnum, AcceptedTime);
                    AppointmentService.Current.Add(appt);
                }
            }
        }else{
            Appointment existingAppt = AppointmentService.Current.AppointmentSearch(AppointmentId);
            existingAppt.Day = DayEnum;
            existingAppt.Time = AcceptedTime;
            AppointmentService.Current.Edit(existingAppt);  
        }        

        Shell.Current.GoToAsync("//Patient");
    }
    [RelayCommand]
    public void Cancel(){
        Shell.Current.GoToAsync("//Patient");
    }

    private bool DayChecker(string day){
        if(day.Equals("M", StringComparison.OrdinalIgnoreCase)){
            DayEnum = WeekdayEnum.Monday;
            return true;
        }
        else if(day.Equals("T", StringComparison.OrdinalIgnoreCase)){
            DayEnum = WeekdayEnum.Tuesday;
            return true;
        }
        else if(day.Equals("W", StringComparison.OrdinalIgnoreCase)){
            DayEnum = WeekdayEnum.Wednesday;
            return true;
        }
        else if(day.Equals("TH", StringComparison.OrdinalIgnoreCase)){
            DayEnum = WeekdayEnum.Thursday;
            return true;
        }
        else if(day.Equals("F", StringComparison.OrdinalIgnoreCase)){
            DayEnum = WeekdayEnum.Friday;
            return true;
        }
        else{
            return false;
        }
    }

    private bool TimeChecker(string timeDigits, string timeOfDay){
        //bool timeLoop = false;
        int[] invalidAm = [1, 2, 3, 4, 5, 6, 7, 12];
        int[] invalidPm = [5, 6, 7, 8, 9, 10, 11];
        
        if(!char.IsDigit(timeDigits[0])){

            return false;
        }
        //split digits by colon if exist
        int hour;
        if(timeDigits.Contains(':')){
            string[] splitTime = timeDigits.Split(':');
            if(!int.TryParse(splitTime[0], out hour)){
                return false;
            } 
        } else{
            if(!int.TryParse(timeDigits, out hour)){
                return false;
            } 
        }
            //check hr
            //8pm, 9pm, 10pm, 11pm, 12am, 1am, 2am, 3am, 4am, 5am not valid
        if(timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
            if(invalidAm.Contains(hour)){
                return false;
            }
            else{
                AcceptedTime = timeDigits + timeOfDay;
                return true;
            }
        } else if(timeOfDay.Equals("pm", StringComparison.OrdinalIgnoreCase)){ //if pm
            if(invalidPm.Contains(hour)){
                return false;
            }
            else{
                AcceptedTime = timeDigits + timeOfDay;
                return true;
            }
        }else{
            return false;
        }
    }
}
