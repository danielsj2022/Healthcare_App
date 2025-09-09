using System;
using System.Transactions;
using CLI.Healthcare.Helpers;
using Library.Healthcare.Models;

namespace CLI.Healthcare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Closed 1  (how to closse github issue)
            //List<Patient?> patients = new List<Patient?>();
            PatientHelper patientHelper = new PatientHelper();
            PhysicianHelper physicianHelper = new PhysicianHelper();
            AppointmentHelper appointmentHelper = new AppointmentHelper();

            bool quitChoice = true;

            do{
                Console.WriteLine("Select a choice:");
                Console.WriteLine("c1 - create patient");
                Console.WriteLine("c2 - create physician");
                Console.WriteLine("a - create appointment");
                Console.WriteLine("l1 - list patients");
                Console.WriteLine("l2 - list physicians");
                Console.WriteLine("l3 - list appointments");
                Console.WriteLine("u1 - update patient");
                Console.WriteLine("u3 - update appointment");
                Console.WriteLine("d1 - delete patient");
                Console.WriteLine("d2 - delete physician");
                Console.WriteLine("d3 - delete appointment");
                Console.WriteLine("q - quit");

                var userChoice = Console.ReadLine();

                switch(userChoice){
                    case "c1":
                    case "C1":
                        //Patient newPatient = CreatePatient();
                        //show patient id
                        //patients.Add(newPatient);
                        patientHelper.CreatePatient();
                        
                        break;
                    case "c2":
                    case "C2":
                        physicianHelper.CreatePhysician();
                        break;
                    case "a":
                    case "A":
                        appointmentHelper.CreateAppointment(patientHelper, physicianHelper);
                        break;
                    case "l1":
                    case "L1":
                        // foreach(var p in patients){
                        //     Console.WriteLine(p);
                        // }
                        patientHelper.ListPatients();
                        break;
                    case "l2":
                    case "L2":
                        physicianHelper.ListPhysicians();
                        break;
                    case "l3":
                    case "L3":
                        appointmentHelper.ListAppointments();
                        break;
                    case "u1":
                    case "U1":
                        break;
                    case "u3":
                    case "U3":
                        break;
                    case "d1":
                    case "D1":
                        patientHelper.DeletePatient();
                        break;
                    case "d2":
                    case "D2":
                        break;
                    case "d3":
                    case "D3":
                        break;
                    case "q":
                    case "Q":
                        quitChoice = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;

                    
                }  
            } while(quitChoice);
        }
    }
}