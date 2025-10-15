using Library.Healthcare.Models;
using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;
//[QueryProperty(nameof(SelectedPatient), "selectedPatient")]

public partial class PatientView : ContentPage
{
	//public Patient SelectedPatient{ get; set; }
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
		(BindingContext as PatientViewViewModel)?.Edit();
	}

	private void DeleteClicked(object sender, EventArgs e){
		(BindingContext as PatientViewViewModel)?.Delete();	
	}


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PatientViewViewModel)?.Refresh();
    }

    private void CreateApptClicked(object sender, EventArgs e)
    {
		(BindingContext as PatientViewViewModel)?.CreateAppt();
    }

    private void EditApptClicked(object sender, EventArgs e)
    {
    }

    private void DeleteApptClicked(object sender, EventArgs e)
    {
    }
}