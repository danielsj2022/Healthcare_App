using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Library.Healthcare.DTO;
using System.Runtime.CompilerServices; 
using System.Linq;
using System.Threading.Tasks; 
using System.Text;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Maui.Healthcare.ViewModel;

public partial class PhysicianViewViewModel : ObservableObject, INotifyPropertyChanged
{

    public ObservableCollection<PhysicianDTO> Physicians{
        get{
            return new ObservableCollection<PhysicianDTO>(PhysicianService.Current.Physicians
                .Where(
                    p => (p?.PhysicianId.ToString().ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                    || (p?.LisenceNumber.ToString().ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                    || (p?.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                    || (p?.GraduationDate.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                    || (p?.Specialization.ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                    || (p?.Availability.ToString().ToUpper().Contains(Query?.ToUpper() ?? string.Empty) ?? false)
                ));
        }
    }

    [ObservableProperty]
    private string? query;
    public void Refresh(){
        NotifyPropertyChanged("Physicians");
    }

    public PhysicianDTO? SelectedPhysician { get; set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    
    [RelayCommand]
    private void Search()
    {
        //need query
        //update list
        Refresh();
    }
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
        Shell.Current.GoToAsync($"//AddPhysician?physicianId={selectedId}");
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
