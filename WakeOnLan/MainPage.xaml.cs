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
            var popup = new DeviceOperationPopup();
            popup.Closed += DeviceAddingEnded;
            this.ShowPopup(popup);
        }

        private void DeviceAddingEnded(object sender, CommunityToolkit.Maui.Core.PopupClosedEventArgs e)
        {
            var device = e.Result as Devices.Device;

            if (device != null)
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
            var device = e.Result as Devices.Device;

            if (device != null)
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

        }
    }
}