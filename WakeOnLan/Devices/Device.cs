using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WakeOnLan.Devices
{
    public class Device : INotifyPropertyChanged
    {
        public string Guid { get; private set; }

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            } 
        }
        private string _name;

        public string IP
        {
            get => _ip;
            set
            {
                _ip = value;
                OnPropertyChanged("IP");
            }
        }
        private string _ip;

        public int Port
        {
            get => _port;
            set
            {
                _port = value;
                OnPropertyChanged("Port");
            }
        }
        private int _port = 9;

        public string MAC
        {
            get => _mac;
            set
            {
                _mac = value;
                OnPropertyChanged("MAC");
            }
        }
        private string _mac;

        public event PropertyChangedEventHandler PropertyChanged;

        public Device() 
        { 
            Guid = System.Guid.NewGuid().ToString();
        }

        [JsonConstructor]
        public Device(string guid)
        {
            Guid = guid;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
