using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WakeOnLan.Devices
{
    public class DevicesListViewModel
    {
        public ObservableCollection<Device> Devices { get; private set; }
        private readonly DevicesStorage _devicesStorage;

        public DevicesListViewModel(DevicesStorage devicesStorage)
        {
            _devicesStorage = devicesStorage;
            Devices = _devicesStorage.LoadDevices();
        }

        public void AddDevice(Device device)
        {
            Devices.Add(device);
            _devicesStorage.SaveDevice(device);
        }

        public void RemoveDevice(string guid)
        {
            try
            {
                Devices.Remove(Devices.First(x => x.Guid == guid));
                _devicesStorage.RemoveDevice(guid);
            }
            catch 
            { 
                Toast.Make("Error on removing device").Show();
            }
        }

        public void UpdateDevice(Device device)
        {
            try
            {
                var updDevice = Devices.First(x => x.Guid == device.Guid);
                updDevice.Name = device.Name;
                updDevice.IP = device.IP;
                updDevice.Port = device.Port;
                updDevice.MAC = device.MAC;

                _devicesStorage.SaveDevice(updDevice);
            }
            catch
            {
                Toast.Make("Error: device not found").Show();
            }
        }
    }
}
