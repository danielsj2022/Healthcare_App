using Maui.Healthcare.ViewModel;

namespace Maui.Healthcare.Views;
[QueryProperty(nameof(AppointmentId),"appointmentId")]
//[QueryProperty(nameof(PatientId), "patientId")]

public partial class CreateAppointmentView : ContentPage
{
	public CreateApptViewModel CreateApptViewModel { get;}
	public int AppointmentId { get; set; }
	public CreateAppointmentView()
	{
		InitializeComponent();
		CreateApptViewModel = new CreateApptViewModel();
		BindingContext = CreateApptViewModel;
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e){
		(BindingContext as CreateApptViewModel)?.ResetForm(AppointmentId);
	}

}