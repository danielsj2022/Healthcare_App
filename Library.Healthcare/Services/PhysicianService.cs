using System;
using Library.Healthcare.Models;

namespace Library.Healthcare.Services;

public class PhysicianService
{
    private List<Physician> physiciansList ;
    private PhysicianService(){
        physiciansList = new List<Physician>();
    }

    private static PhysicianService? instance;
    private static object instanceLock = new object();
    public static PhysicianService Current{
        get{
            lock (instanceLock){
                if (instance == null){
                    instance = new PhysicianService();
                }
            }
            return instance;
        }
    }

    public List<Physician> Physicians{
        get{ return physiciansList; }
    }

    public void Add(Physician physician){
        physiciansList.Add(physician);
    }
    public void Edit(Physician physician){
        var index = physiciansList.IndexOf(physician);
        physiciansList.RemoveAt(index);
        physiciansList.Insert(index, physician) ;

    }
    public Physician? Remove(int physicianId){
        var physician = PhysicianSearchById(physicianId);
        physiciansList.Remove(physician);

        return physician;
    }

    // public Physician? Edit(int physicianId){
    //     var physician = PhysicianSearchById(physicianId);
    // }

    public Physician? PhysicianSearchById(int id){
        //Console.WriteLine("Enter Physician Id: ");
        //string? physicianIdInput = Console.ReadLine();
            var physician = physiciansList
                .Where(p => p != null)
                .FirstOrDefault(p => p.PhysicianId == id);
            if (physician == null){
                return null;            
            } else{ 
                return physician; 
            }
    }

    public Physician? PhysicianSearchByAvailability(){
        var physician = physiciansList //find first avail phy
            .Where(p => p != null)
            .FirstOrDefault(p => p.Availability == true);
        
        return physician;

        // if(physician != null){
        //     physician.Availability = false; //set availability
        //     return physician;
        // } else{
        //     Console.WriteLine("No physicians available");
        //     return null;
        // }
    }
}
