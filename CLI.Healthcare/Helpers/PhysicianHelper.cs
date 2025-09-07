using System;
using Library.Healthcare.Models;
using Library.Healthcare.Services;

namespace CLI.Healthcare.Helpers;

public class PhysicianHelper
{
    PhysicianService physicianService = new PhysicianService();

    public void CreatePhysician(){
        
        Console.Write("Enter License number: ");
        var liscenseNumberInput = Console.ReadLine();
        while(string.IsNullOrEmpty(liscenseNumberInput)){
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
}
