using WakeOnLan.Devices;
using CommunityToolkit.Maui.Views;

namespace WakeOnLan
{
    public partial class MainPage : ContentPage
    {
        private DevicesListViewModel devicesViewModel = new DevicesListViewModel();

        public MainPage()
        {
            InitializeComponent();
            DevicesView.BindingContext = devicesViewModel;

            var popup = new AddDevicePopup();
            this.ShowPopup(popup); 
        }
    }
}