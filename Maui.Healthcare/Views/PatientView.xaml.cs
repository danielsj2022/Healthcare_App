using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
		BindingContext = new PatientViewViewModel();
	}

	public void HomeClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//MainPage");
	}
}