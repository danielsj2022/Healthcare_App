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
        int[] invalidAm = [1, 2, 3, 4, 5, 6, 7, 12];
        int[] invalidPm = [6, 7, 8, 9, 10, 11];
        do{
            Console.Write("Enter desired time (number only ##:##): ");
            string? timeDigits = Console.ReadLine(); //11:30 1:30  10
            timeDigits ??= "6";
            // while(timeDigits.StartsWith("6") || timeDigits.StartsWith("7") || (!char.IsDigit(timeDigits[0]))){
            while(!char.IsDigit(timeDigits[0])){

                Console.Write("Invalid input: ");
                timeDigits = Console.ReadLine();
                timeDigits ??= " ";
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
            // while(!timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase) && !timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
            //     Console.Write("Invalid time of day. Re-enter: ");
            //     timeOfDay = Console.ReadLine();
            //     timeOfDay ??="mm";
            // }
            //8pm, 9pm, 10pm, 11pm, 12am, 1am, 2am, 3am, 4am, 5am not valid
            
            if(timeOfDay.Equals("am", StringComparison.OrdinalIgnoreCase)){
                if(invalidAm.Contains(hour)){
                    Console.WriteLine("Invalid time");
                    timeLoop = true;
                }
                else{
                    return timeDigits + timeOfDay;
                }
            } else if(timeOfDay.Equals("pm", StringComparison.OrdinalIgnoreCase)){ //if pm
                if(invalidPm.Contains(hour)){
                    Console.WriteLine("Invalid time");
                    timeLoop = true;
                }
                else{
                    return timeDigits + timeOfDay;
                }
            }else{
                Console.WriteLine("Invalid time");
                timeLoop = true;
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

    public void DeleteAppointment(){
        //search by id
        Console.WriteLine("Enter Appointment Id: ");
        var appointmentIdInput = Console.ReadLine();
        Appointment? appointment = AppointmentSearchById(appointmentIdInput);
        if(appointment != null){
            appointment.Physician.Availability = true;
            appointmentService.Remove(appointment);
            Console.WriteLine("Appointment deleted");

        }

    }
    public void ListAppointments(){
        appointmentService.appointmentsList.ForEach(Console.WriteLine);
    }

    private Appointment? AppointmentSearchById(string? appointmentIdInput){
        
       
        if(int.TryParse(appointmentIdInput, out int appointmentId)){
            var appointment = appointmentService.appointmentsList
                .Where(a => a != null)
                .FirstOrDefault(a => a.AppointmentId == appointmentId);
            if (appointment == null)
            {
                Console.WriteLine("Physician not found");
            } else{ 
                return appointment; 
            }
        } else{
            Console.WriteLine("Invalid physician Id");
        }
        return null;
    }
}
