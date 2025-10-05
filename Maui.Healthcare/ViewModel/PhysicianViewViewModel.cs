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

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = ""){
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
