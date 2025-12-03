using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;


[QueryProperty(nameof(PhysicianId), "physicianId")]
public partial class AddPhysicianView : ContentPage
{
	public int PhysicianId { get; set;}
	public AddPhysicianViewModel AddPhyView {get;}
	public AddPhysicianView()
	{
		InitializeComponent();
		AddPhyView = new AddPhysicianViewModel();
		BindingContext = AddPhyView;
	}

	public void CancelClicked(object sender, EventArgs e){
		if (BindingContext is AddPhysicianViewModel vm){
			vm.ResetForm(0);
		}
		Shell.Current.GoToAsync("//Physician");
		//remove ref to selectedPhysician
	}

    
}