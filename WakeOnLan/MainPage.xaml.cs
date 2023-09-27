using WakeOnLan.Devices;
using CommunityToolkit.Maui.Views;

namespace WakeOnLan
{
    public partial class MainPage : ContentPage
    {
        private readonly DevicesListViewModel devicesViewModel = new();

        public MainPage()
        {
            InitializeComponent();
            DevicesView.BindingContext = devicesViewModel;
        }

        private void AddDeviceClicked(object sender, EventArgs e)
        {
            var popup = new AddDevicePopup();
            popup.Closed += AddPopupClosed;
            this.ShowPopup(popup);
        }

        private void AddPopupClosed(object sender, CommunityToolkit.Maui.Core.PopupClosedEventArgs e)
        {
            var device = e.Result as WakeOnLan.Devices.Device;

            if (device != null)
            {
                devicesViewModel.AddDevice(device);
            }
        }
    }
}