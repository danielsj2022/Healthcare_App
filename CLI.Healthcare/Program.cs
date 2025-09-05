using System;
using System.Transactions;
using Library.Healthcare.Models;

namespace CLI.Healthcare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Closed 1  (how to closse github issue)
            List<Patient?> patients = new List<Patient?>();

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
                        Patient newPatient = CreatePatient();
                        //show patient id
                        patients.Add(newPatient);
                        break;
                    case "c2":
                    case "C2":
                        break;
                    case "a":
                    case "A":
                        break;
                    case "l1":
                    case "L1":
                        foreach(var p in patients){
                            Console.WriteLine(p);
                        }
                        break;
                    case "l2":
                    case "L2":
                        break;
                    case "l3":
                    case "L3":
                        break;
                    case "u1":
                    case "U1":
                        break;
                    case "u3":
                    case "U3":
                        break;
                    case "d1":
                    case "D1":
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

        public static Patient CreatePatient(){
            //Patient(string name, string address, string bday, string race, string gender, string diagnosis)
            Console.Write("Enter name: ");
            string? name = Console.ReadLine();
            while(string.IsNullOrEmpty(name)){
                Console.Write("Enter valid name: ");
                name = Console.ReadLine();
            }
            Console.Write("Enter address: ");
            string? address = Console.ReadLine();
            while(string.IsNullOrEmpty(address)){
                Console.Write("Enter valid address: ");
                address = Console.ReadLine();
            }
            Console.Write("Enter birthday(##/##/####): ");
            string? bday = Console.ReadLine();
            while(string.IsNullOrEmpty(bday)){
                Console.Write("Enter valid birthday: ");
                bday = Console.ReadLine();
            }
            Console.Write("Enter race: ");
            string? race = Console.ReadLine();
            while(string.IsNullOrEmpty(race)){
                Console.Write("Enter valid race: ");
                race = Console.ReadLine();
            }
            Console.Write("Enter gender: ");
            string? gender = Console.ReadLine();
            while(string.IsNullOrEmpty(gender)){
                Console.Write("Enter valid gender: ");
                gender = Console.ReadLine();
            }
            Console.Write("Enter diagnosis (leave blank if empty): ");
            string? diagnosis = Console.ReadLine();
            if(string.IsNullOrEmpty(diagnosis)){
                diagnosis="none";
            }
            Console.Write("Enter prescription (leave blank if empty): ");
            string? prescript = Console.ReadLine();
            if(string.IsNullOrEmpty(prescript)){
                prescript="none";
            }
            //here
            return new Patient(name, address, bday, race, gender, diagnosis, prescript);
        }
    }
}