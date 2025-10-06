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
    public Physician? Remove(int physicianId){
        var physician = PhysicianSearchById(physicianId);
        physiciansList.Remove(physician);

        return physician;
    }

    private Physician? PhysicianSearchById(int id){
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
}
