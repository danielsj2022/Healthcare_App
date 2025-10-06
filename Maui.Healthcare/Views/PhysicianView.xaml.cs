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

    private void AddClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//AddPhysician");
    }

    private void EditClicked(object sender, EventArgs e)
    {
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PhysicianViewViewModel)?.Refresh();
    }
}