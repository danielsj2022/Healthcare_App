using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
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

    private int AppointmentId { get; set; }
    private Patient Patient {get; set;}
    private Physician Physician {get; set;}
    private WeekdayEnum DayEnum { get; set; }
    private string AcceptedTime { get; set; }

    public bool IsLocked{ get; set; } = false;  //for patientId when editing

    public void ResetForm(int appointmentId){
        AppointmentId = appointmentId;
        if(appointmentId == 0){ //selected user is none, so add new; clear fields
            PatientId = string.Empty;
            Weekday = string.Empty;
            Time = string.Empty;
            TimeOfDay = string.Empty;
        } else{
            IsLocked = true;
            //var patient = PatientService.Current.PatientSearchById(PatientId);
            // if(patient != null){
            //     Name = patient.Name;
            //     Address = patient.Address;
            //     Birthday = patient.Birthday;
            //     Race = patient.Race;
            //     Gender = patient.Gender;
            //     Diagnosis = patient.Diagnosis;
            //     Prescription = patient.Prescription;
            // }
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
    public void Submit(){
        int patientId = int.Parse(PatientId);
        var patient = PatientService.Current.PatientSearchById(patientId);
        if(patient != null){    //patient exist
            var physician = PhysicianService.Current.PhysicianSearchByAvailability();
            if(physician != null){
                Appointment appt = new Appointment(patient, physician, DayEnum, AcceptedTime);
                AppointmentService.Current.Add(appt);
            }
        }
        //var physician = PhysicianService.Current.PhysicianSearchById(PhysicianId);
        // if (physician == null){
        //     Physician newPhysician= new Physician(lNumber, Name, GradDate, Specialization);
        //     PhysicianService.Current.Add(newPhysician);	//func is type safe
        //     //Console.Write(physician.ToString());
        // } else{
        //     physician.LisenceNumber = lNumber;
        //     physician.Name = Name;
        //     physician.GraduationDate = GradDate;
        //     physician.Specialization = Specialization;
        //     PhysicianService.Current.Edit(physician);
        // }
        

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
        //do{
            //Console.Write("Enter desired time (number only ##:##): ");
            //string? timeDigits = Console.ReadLine(); //11:30 1:30  10
            //timeDigits ??= "6";
            if(!char.IsDigit(timeDigits[0])){

                return false;
            }
            //split digits by colon if exist
            int hour;
            if(timeDigits.Contains(':')){
                string[] splitTime = timeDigits.Split(':');
                // hour = int.Parse(splitTime[0]);
                if(!int.TryParse(splitTime[0], out hour)){
                    return false;
                } 
            } else{
                //hour = int.Parse(timeDigits);
                if(!int.TryParse(timeDigits, out hour)){
                    return false;
                } 
            }
            //check hr

            //Console.Write("am or pm: ");
            //var timeOfDay = Console.ReadLine();
            //timeOfDay ??="mm";  //assign to invalid value
            //8pm, 9pm, 10pm, 11pm, 12am, 1am, 2am, 3am, 4am, 5am not valid
            
            if(timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
                if(invalidAm.Contains(hour)){
                    // Console.WriteLine("Invalid time");
                    // timeLoop = true;
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
