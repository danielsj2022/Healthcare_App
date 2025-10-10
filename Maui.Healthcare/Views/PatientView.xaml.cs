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

	private void AddClicked(object sender, EventArgs e){
		(BindingContext as PatientViewViewModel)?.Add();
	}

	private void EditClicked(object sender, EventArgs e){
		
	}

	private void DeleteClicked(object sender, EventArgs e){
		
	}


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PatientViewViewModel)?.Refresh();
    }
}