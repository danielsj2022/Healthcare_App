using System;
using Library.Healthcare.Models;

namespace Api.Healthcare.Database;

public class FakeDatabase
{
    public static List<Physician> Physicians = new List<Physician>
    {
        new Physician(2332, "joe", "34/34/222", "heart")
    };
    public static List<Patient> Patients = new List<Patient>();
    public static List<Appointment> Appointments = new List<Appointment>();
}
