using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class AppointmentService
{
    public List<Appointment> appointmentsList = new List<Appointment>();

    public void Add(Appointment appt){
        appointmentsList.Add(appt);
    }
}
