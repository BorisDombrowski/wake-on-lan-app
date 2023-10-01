using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace WakeOnLan.Devices
{
    public class DevicesStorage
    {
        private readonly string _dataDirPath;

        public DevicesStorage()
        {
            _dataDirPath = $@"{FileSystem.Current.AppDataDirectory}/devices/";
            if (!Directory.Exists(_dataDirPath))
            {
                Directory.CreateDirectory(_dataDirPath);                
            }
        }

        public ObservableCollection<Device> LoadDevices()
        {
            var configs = Directory.GetFiles(_dataDirPath, "*.config");
            var devices = configs.Select(File.ReadAllText).Select(x => JsonSerializer.Deserialize<Device>(x)).ToList();
            return new ObservableCollection<Device>(devices);
        }

        public void SaveDevice(Device device)
        {
            var json = JsonSerializer.Serialize(device);
            var configPath = $@"{_dataDirPath}/{device.Guid}.config";
            File.WriteAllText(configPath, json);
        }

        public void RemoveDevice(string guid)
        {
            var configPath = $@"{_dataDirPath}/{guid}.config";
            if (File.Exists(configPath))
            {
                File.Delete(configPath);
            }
        }
    }
}
