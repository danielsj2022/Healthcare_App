using System;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace CLI.Healthcare.Helpers;

public class PhysicianHelper
{
    //refactor str -> int
    PhysicianService physicianService = new PhysicianService();

    public void CreatePhysician(){
        
        Console.Write("Enter License number: ");
        var liscenseNumberInput = Console.ReadLine();

        while(string.IsNullOrEmpty(liscenseNumberInput) || !char.IsDigit(liscenseNumberInput[0])){
            Console.Write("Enter valid Lisence Number: ");
            liscenseNumberInput = Console.ReadLine();
        }
        int licenseNum = int.Parse(liscenseNumberInput);

        Console.Write("Enter name: ");
        string? name = Console.ReadLine();
        while(string.IsNullOrEmpty(name)){
            Console.Write("Enter valid name: ");
            name = Console.ReadLine();
        }
        Console.Write("Enter Graduation date(##/##/####): ");
        string? gradDate = Console.ReadLine();
        while(string.IsNullOrEmpty(gradDate)){
            Console.Write("Enter valid birthday: ");
            gradDate = Console.ReadLine();
        }
        Console.Write("Enter Specialization: ");
        string? specialization = Console.ReadLine();
        while(string.IsNullOrEmpty(specialization)){
            Console.Write("Enter valid specialization: ");
            specialization = Console.ReadLine();
        }

        Physician physician = new Physician(licenseNum, name, gradDate, specialization);
        physicianService.Add(physician);
    }

    public void ListPhysicians(){
        physicianService.physiciansList.ForEach(Console.WriteLine);
    }

    public Physician? PhysicianSearchByAvailability(){
        var physician = physicianService.physiciansList //find first avail phy
            .Where(p => p != null)
            .FirstOrDefault(p => p.Availability == true);

        if(physician != null){
            physician.Availability = false; //set availability
            return physician;
        } else{
            Console.WriteLine("No physicians available");
            return null;
        }
    }

    public void DeletePhysicain(){
        Physician? physician = PhysicianSearchById();
        if(physician != null){
            physicianService.Remove(physician);
            Console.WriteLine("Physician deleted");
        }
    }

    public void UpdatePhysician(){
        Physician? physician = PhysicianSearchById();
        if(physician != null){
            //update lic#, name, graddate, specialization
            Console.Write(
                "What would you like to update (license number, name, graduation date, specialization): ");
            var update = Console.ReadLine();
            update ??= "no update";
            Console.Write("Enter updated information: ");
            var content = Console.ReadLine();

            while(string.IsNullOrEmpty(content)){
                Console.Write("Enter updated information: ");
                content = Console.ReadLine();
            }
            if(update.Equals("name", StringComparison.OrdinalIgnoreCase)){
                physician.Name =content;
                Console.WriteLine("Update completed.");
            } else if(update.Equals("license number", StringComparison.OrdinalIgnoreCase)){
                int licenseNumber = int.Parse(content);
                physician.LisenceNumber = licenseNumber;
                Console.WriteLine("Update completed.");
            } else if(update.Equals("graduation date", StringComparison.OrdinalIgnoreCase)){
                physician.GraduationDate = content;
                Console.WriteLine("Update completed.");
            } else if(update.Equals("specialization", StringComparison.OrdinalIgnoreCase)){
                physician.Specialization = content;
                Console.WriteLine("Update completed.");
            } else{
                Console.WriteLine("Invalid field. Back to main menu;");
            }
        }
    }

    private Physician? PhysicianSearchById(){
        Console.WriteLine("Enter PatientId: ");
        string? physicianIdInput = Console.ReadLine();
       
        if(int.TryParse(physicianIdInput, out int physicianId)){
            var physician = physicianService.physiciansList
                .Where(p => p != null)
                .FirstOrDefault(p => p.PhysicianId == physicianId);
            if (physician == null)
            {
                Console.WriteLine("Physician not found");
            } else{ 
                return physician; 
            }
        } else{
            Console.WriteLine("Invalid physician Id");
        }
        return null;
    }
}
