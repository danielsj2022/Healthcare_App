namespace Maui.Healthcare;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	// private void OnCounterClicked(object sender, EventArgs e)
	// {
	// 	count++;

	// 	if (count == 1)
	// 		CounterBtn.Text = $"Clicked {count} time";
	// 	else
	// 		CounterBtn.Text = $"Clicked {count} times";

	// 	SemanticScreenReader.Announce(CounterBtn.Text);
	// }

    private void PatientClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Patient");
    }

	private void PhysicianClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Physician");
    }
}

