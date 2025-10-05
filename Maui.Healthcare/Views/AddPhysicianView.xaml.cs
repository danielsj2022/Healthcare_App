using Library.Healthcare.Models;
using Library.Healthcare.Services;
using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;

public partial class AddPhysicianView : ContentPage
{
	public AddPhysicianViewModel AddPhyView {get;}
	public AddPhysicianView()
	{
		InitializeComponent();
		AddPhyView = new AddPhysicianViewModel();
		BindingContext = AddPhyView;
	}

	public void CancelClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Physician");
	}

	public async void OkClicked(object sender, EventArgs e){
		//add blog
		PhysicianService.Current.Add(BindingContext as Physician);	//func is type safe


		await Shell.Current.GoToAsync("//Physician");
	}
}