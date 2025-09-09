using System;

namespace Library.Healthcare.Models;

public class Appointment
{
    public int AppointmentId {get; set;}
    public Patient Patient {get; set;}
    public Physician Physician {get; set;}
    public Weekday Day {get; set;}
    public string Time {get; set;}

    public Appointment(Patient pt, Physician phy, Weekday weekday, string time){
        Random rand = new Random();
        AppointmentId = rand.Next();
        Patient = pt;
        Physician = phy;
        Day = weekday;
        Time = time;
    }
    public override string ToString()
    {
        return $"Appointment Id: {AppointmentId}\nPhysician Name: {Physician.Name}\n{Day} at {Time}\n";
    }
}

public enum Weekday{
    Monday, Tuesday, Wednesday, Thursday, Friday
}
