using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WakeOnLan.Devices
{
    public class DevicesListViewModel
    {
        public ObservableCollection<Device> Devices { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public DevicesListViewModel()
        {
            Devices = new ObservableCollection<Device>()
            {
                new Device() {Name="qwerty", IP="192.168.100.125", Port=54, MAC="41:45:98:ac:45:df"},
                new Device() {Name="zxcvbn", IP="192.168.100.126", Port=152, MAC="41:45:98:ac:45:d4"},
                new Device() {Name="asdfgh", IP="192.168.100.127", Port=1455, MAC="41:45:98:ac:45:74"}
            };
            
        }
    }
}
