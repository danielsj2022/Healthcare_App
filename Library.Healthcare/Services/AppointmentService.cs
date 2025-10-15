using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class AppointmentService
{
    public List<Appointment> appointmentsList;

    private AppointmentService(){
        appointmentsList = new List<Appointment>();
    }
    private static AppointmentService? instance;
    private static object instanceLock = new object();
    public static AppointmentService Current{
        get{
            lock (instanceLock){
                if (instance == null){
                    instance = new AppointmentService();
                }
            }
            return instance;
        }
    }

    public List<Appointment> Appointments{
        get{
            return appointmentsList;
        }
    }

    public void Add(Appointment appt){
        appointmentsList.Add(appt);
    }
    public void Remove(Appointment appt)
    {
        appointmentsList.Remove(appt);
    }
    
    public Appointment? AppointmentSearch(int appointmentId)
    {
        var appointment = appointmentsList
            .Where(x => x != null)
            .FirstOrDefault(x => x.AppointmentId == appointmentId);

        return appointment;
    }
}
