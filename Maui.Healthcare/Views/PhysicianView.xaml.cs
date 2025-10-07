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
		//Shell.Current.GoToAsync("//AddPhysician");
		(BindingContext as PhysicianViewViewModel)?.Add();

    }

    private void EditClicked(object sender, EventArgs e)
    {
		(BindingContext as PhysicianViewViewModel)?.Edit();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
		(BindingContext as PhysicianViewViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PhysicianViewViewModel)?.Refresh();
    }
}