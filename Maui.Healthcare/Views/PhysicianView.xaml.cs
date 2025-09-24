using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;

public partial class PhysicianView : ContentPage
{
	public PhysicianView()
	{
		InitializeComponent();
		BindingContext = new PhysicianViewViewModel();
	}

	public void HomeClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//MainPage");
	}
}