namespace WakeOnLan.Devices
{
    public class Device
    {
        public string Guid { get; private set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public uint Port { get; set; }
        public string MAC { get; set; }

        public Device() 
        { 
            Guid = System.Guid.NewGuid().ToString();
        }
    }
}
