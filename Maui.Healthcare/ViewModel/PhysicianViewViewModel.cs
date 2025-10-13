using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using System.Runtime.CompilerServices; 
using System.Linq;
using System.Threading.Tasks; 
using System.Text;

namespace Maui.Healthcare.ViewModel;

public class PhysicianViewViewModel : INotifyPropertyChanged
{

    public ObservableCollection<Physician> Physicians{
        get{
            return new ObservableCollection<Physician>(PhysicianService.Current.Physicians);
        }
    }
    public void Refresh(){
        NotifyPropertyChanged("Physicians");
    }

    public Physician? SelectedPhysician { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public void Add(){
        Shell.Current.GoToAsync($"//AddPhysician?physicianId={0}");
        SelectedPhysician = null;
        NotifyPropertyChanged(nameof(SelectedPhysician));

    }
    public void Edit(){
        if (SelectedPhysician == null){
            return;
        }
        var selectedId = SelectedPhysician.PhysicianId;
        //var physician = SelectedPhysician;
        Shell.Current.GoToAsync($"//AddPhysician?physicianId={selectedId}");
        //Shell.Current.GoToAsync($"//AddPhysician?physicianId={physician}");
        SelectedPhysician = null;
        NotifyPropertyChanged(nameof(SelectedPhysician));

    }

    public void Delete(){
        if(SelectedPhysician == null){
            return;
        }
        PhysicianService.Current.Remove(SelectedPhysician.PhysicianId);
        SelectedPhysician = null;
        NotifyPropertyChanged(nameof(Physicians));
    }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = ""){
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
