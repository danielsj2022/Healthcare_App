using System;
using System.Text.Json.Serialization;
using Library.Healthcare.Utilities;
using Library.Healthcare.Models;
using Library.Healthcare.DTO;
using Newtonsoft.Json;


namespace Library.Healthcare.Services;

public class PhysicianService
{
    private List<PhysicianDTO> physiciansList =new List<PhysicianDTO>() ;
    private PhysicianService(){
        //physiciansList = new List<Physician>();
        var physicianResponse = new WebRequestHandler().Get("/Physician").Result;

        if (physicianResponse != null)
        {
            physiciansList = JsonConvert.DeserializeObject<List<PhysicianDTO>>(physicianResponse);
        }
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

    public List<PhysicianDTO> Physicians{
        get{ return physiciansList; }
    }

    public async Task<PhysicianDTO> Add(PhysicianDTO physicianDTO){
        if (physicianDTO == null)
        {
            return null;
        }
        var physicianPayload = await new WebRequestHandler().Post("/Physician", physicianDTO);
        var physicianFromServer = JsonConvert.DeserializeObject<PhysicianDTO>(physicianPayload);
        physiciansList.Add(physicianFromServer);

        return physicianDTO;
    }
    public void Edit(PhysicianDTO physicianDTO){
        var index = physiciansList.IndexOf(physicianDTO);
        physiciansList.RemoveAt(index);
        physiciansList.Insert(index, physicianDTO) ;

    }
    public PhysicianDTO? Remove(int physicianId){
        var physicianDTO = PhysicianSearchById(physicianId);
        physiciansList.Remove(physicianDTO);

        return physicianDTO;
    }

    // public Physician? Edit(int physicianId){
    //     var physician = PhysicianSearchById(physicianId);
    // }

    public PhysicianDTO? PhysicianSearchById(int id){
        //Console.WriteLine("Enter Physician Id: ");
        //string? physicianIdInput = Console.ReadLine();
            var physicianDTO = physiciansList
                .Where(p => p != null)
                .FirstOrDefault(p => p.PhysicianId == id);
            if (physicianDTO == null){
                return null;            
            } else{ 
                return physicianDTO; 
            }
    }

    public PhysicianDTO? PhysicianSearchByAvailability(){
        var physicianDTO = physiciansList //find first avail phy
            .Where(p => p != null)
            .FirstOrDefault(p => p.Availability == true);
        
        if (physicianDTO != null)
        {
            physicianDTO.Availability = false;
        }
        return physicianDTO;

        // if(physician != null){
        //     physician.Availability = false; //set availability
        //     return physician;
        // } else{
        //     Console.WriteLine("No physicians available");
        //     return null;
        // }
    }
}
