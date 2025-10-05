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
    public void Remove(Physician physician){
        physiciansList.Remove(physician);
    }
}
