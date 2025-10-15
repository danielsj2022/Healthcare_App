using System;

namespace Library.Healthcare.Models;

public class Appointment
{
    public int AppointmentId {get; set;}
    public Patient Patient {get; set;}
    public Physician Physician {get; set;}
    public WeekdayEnum Day {get; set;}
    public string Time {get; set;}

    public Appointment(Patient pt, Physician phy, WeekdayEnum weekday, string time){
        Random rand = new Random();
        AppointmentId = rand.Next();
        Patient = pt;
        Physician = phy;
        Day = weekday;
        Time = time;
    }

    public string Display{
        get{
            return ToString();
        }
    }
    public override string ToString()
    {
        return $"Appointment Id: {AppointmentId} Physician Name: {Physician.Name} {Day} at {Time}";
    }
}

// public enum Weekday{
//     Monday, Tuesday, Wednesday, Thursday, Friday
// }
