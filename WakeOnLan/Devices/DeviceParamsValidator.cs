using System.Text.RegularExpressions;

namespace WakeOnLan.Devices
{
    public static class DeviceParamsValidator
    {
        public static bool IsValidName(string name)
        {
            return IsStringFilled(name);
        }
        
        private static readonly string ipRegExp = "(\\b25[0-5]|\\b2[0-4][0-9]|\\b[01]?[0-9][0-9]?)(\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}";
        public static bool IsValidIP(string ip)
        {
            return IsStringFilled(ip) && Regex.IsMatch(ip, ipRegExp);
        }

        private static readonly string macRegExp = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
        public static bool IsValidMac(string mac)
        {
            return IsStringFilled(mac) && Regex.IsMatch(mac, macRegExp);
        }

        public static bool IsValidPort(int port)
        {            
            return port > 1 && port < 65535;
        }

        private static bool IsStringFilled(string str)
        {
            return !string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str);
        }
    }
}
