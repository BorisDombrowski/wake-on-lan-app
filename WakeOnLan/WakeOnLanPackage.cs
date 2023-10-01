using System.Globalization;
using System.Net;
using System.Net.Sockets;

namespace WakeOnLan
{
    public class WakeOnLanPackage
    {        
        private readonly byte[] _package;

        public WakeOnLanPackage(string mac) 
        {
            var macBytes = mac.Split(':').Select(x => byte.Parse(x, NumberStyles.HexNumber)).ToArray();
            
            var packageList = new List<byte>();
            packageList.AddRange(new byte[] { 255, 255, 255, 255, 255, 255 });
            while(packageList.Count < 102)
            {
                packageList.AddRange(macBytes);
            }
            _package = packageList.ToArray();
        }

        public void Send(string ip, int port)
        {
            var ipBytes = ip.Split('.').Select(byte.Parse).ToArray();
            var targetIP = new IPAddress(ipBytes);
            var endpoint = new IPEndPoint(targetIP, port);

            var udp = new UdpClient();
            udp.Connect(endpoint);
            udp.Send(_package);
            udp.Close();
        }
    }
}
