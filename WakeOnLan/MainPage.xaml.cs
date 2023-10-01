using WakeOnLan.Devices;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Alerts;

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
            var popup = new DeviceOperationPopup();
            popup.Closed += DeviceAddingEnded;
            this.ShowPopup(popup);
        }

        private void DeviceAddingEnded(object sender, CommunityToolkit.Maui.Core.PopupClosedEventArgs e)
        {
            if (e.Result is Devices.Device device)
            {
                devicesViewModel.AddDevice(device);
            }
        }

        private void EditDeviceClicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var device = item.BindingContext as Devices.Device;

            var popup = new DeviceOperationPopup(device);
            popup.Closed += DeviceEditingEnded;
            this.ShowPopup(popup);
        }

        private void DeviceEditingEnded(object sender, CommunityToolkit.Maui.Core.PopupClosedEventArgs e)
        {
            if (e.Result is Devices.Device device)
            {
                devicesViewModel.UpdateDevice(device);
            }
        }

        private void RemoveDeviceClicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var device = item.BindingContext as Devices.Device;
            devicesViewModel.RemoveDevice(device.Guid);
        }

        private void DeviceOnClicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var device = item.BindingContext as Devices.Device;

            try
            {
                var pkg = new WakeOnLanPackage(device.MAC);
                pkg.Send(device.IP, device.Port);
            }
            catch
            {
                Toast.Make("Error during sending package").Show();
                return;
            }

            Toast.Make("Package has been sended").Show();
        }
    }
}