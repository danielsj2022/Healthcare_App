using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;

[QueryProperty(nameof(PatientId), "patientId")]
public partial class AddPatientView : ContentPage
{
	public int PatientId { get; set; }
	public AddPatientViewModel addPatientvm { get;}
	public AddPatientView()
	{
		InitializeComponent();
		addPatientvm = new AddPatientViewModel();
		BindingContext = addPatientvm;
	}

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e){
		(BindingContext as AddPatientViewModel)?.ResetForm(PatientId);
	}
}