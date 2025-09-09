using System;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace CLI.Healthcare.Helpers;

public class AppointmentHelper
{
    AppointmentService appointmentService = new AppointmentService();
    //PatientService patientService = new PatientService();
    //PhysicianService physicianService = new PhysicianService();

    public void CreateAppointment(PatientHelper patientHelper, PhysicianHelper physicianHelper){
        Patient? patient = patientHelper.PatientSearchById();
        if(patient != null){    //patient found
            Weekday weekday = DayChecker();
            string time = TimeChecker();
            Physician? physician = physicianHelper.PhysicianSearchByAvailability();
            if(physician != null){
                Appointment appointment = new Appointment(patient,physician, weekday, time);
                appointmentService.Add(appointment);
                Console.WriteLine("Appointment booked.");
            } else{
                Console.WriteLine("No physicians availabe. Appointment cannot be booked.");
            }
        }
        //find doctor
        //create appt
        
    }
    private string TimeChecker(){
        bool timeLoop = false;
        int[] invalidAm = [1, 2, 3, 4, 5, 12];
        int[] invalidPm = [8, 9, 10, 11];
        do{
            Console.Write("Enter desired time (number only ##:##): ");
            string? timeDigits = Console.ReadLine(); //11:30 1:30  10
            timeDigits ??= "6";
            while(timeDigits.StartsWith("6") || timeDigits.StartsWith("7") || (!char.IsDigit(timeDigits[0]))){
                Console.Write("Time is outside of window. Re-enter: ");
                timeDigits = Console.ReadLine();
                timeDigits ??= "6";
            }
            //split digits by colon if exist
            int hour;
            if(timeDigits.Contains(':')){
                string[] splitTime = timeDigits.Split(':');
                hour = int.Parse(splitTime[0]);
            } else{
                hour = int.Parse(timeDigits);
            }
            //check hr

            Console.Write("am or pm: ");
            var timeOfDay = Console.ReadLine();
            timeOfDay ??="mm";  //assign to invalid value
            while(!timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase) && !timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
                Console.Write("Invalid time of day. Re-enter: ");
                timeOfDay = Console.ReadLine();
                timeOfDay ??="mm";
            }
            //8pm, 9pm, 10pm, 11pm, 12am, 1am, 2am, 3am, 4am, 5am not valid
            
            if(timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
                if(invalidAm.Contains(hour)){
                    Console.WriteLine("Invalid time");
                    timeLoop = true;
                }
                else{
                    return timeDigits + timeOfDay;
                }
            } else{ //if pm
                if(invalidPm.Contains(hour)){
                    Console.WriteLine("Invalid time");
                    timeLoop = true;
                }
                else{
                    return timeDigits + timeOfDay;
                }
            }
        
        }while(timeLoop);
        return "error";        

    }
    private Weekday DayChecker(){
        Console.WriteLine("Enter desired weekday (M, T, W, TH, F): ");
        string? day = Console.ReadLine();
        day ??= "S";    //if null assign val
        bool inputCheck = true;
        //Weekday weekday;
        while(inputCheck){
            //day = day.ToUpper();
            if(day.Equals("M", StringComparison.OrdinalIgnoreCase)){
                return Weekday.Monday;
            }
            else if(day.Equals("T", StringComparison.OrdinalIgnoreCase)){
                return Weekday.Tuesday;
            }
            else if(day.Equals("W", StringComparison.OrdinalIgnoreCase)){
                return Weekday.Wednesday;
            }
            else if(day.Equals("TH", StringComparison.OrdinalIgnoreCase)){
                return Weekday.Thursday;
            }
            else if(day.Equals("F", StringComparison.OrdinalIgnoreCase)){
                return Weekday.Friday;
            }
            else{
                Console.Write("Invalid day. Re-enter: ");
                day = Console.ReadLine();
                day ??= "S";
            }
        }
        return Weekday.Friday;
    }

    // private Patient? PatientSearchById(){
    //     //need search by id
    //     //1. find patient
        
    //     Console.WriteLine("Enter PatientId: ");
    //     string? patientIdInput = Console.ReadLine();
       
    //     if(int.TryParse(patientIdInput, out int patientId)){
    //         //look in patientList
    //         Console.WriteLine("printing patinest");
    //         patientService.patientsList.ForEach(Console.WriteLine);
    //         var patient = patientService.patientsList
    //             .Where(p => p != null)
    //             .FirstOrDefault(p => p.PatientId == patientId);
    //         if (patient == null)
    //         {
    //             Console.WriteLine("Patient not found");
    //         } else{ 
    //             return patient; 
    //         }
    //     } else{
    //         Console.WriteLine("Invalid patient Id");
    //     }
    //     return null;
        
    // }
    // private Physician? PhysicianSearchByAvailability(){
    //     var physician = physicianService.physiciansList //find first avail phy
    //         .Where(p => p != null)
    //         .FirstOrDefault(p => p.Availability == true);

    //     if(physician != null){
    //         physician.Availability = false; //set availability
    //         return physician;
    //     } else{
    //         Console.WriteLine("No physicians available");
    //         return null;
    //     }
    // }

    public void ListAppointments(){
        appointmentService.appointmentsList.ForEach(Console.WriteLine);
    }
}
