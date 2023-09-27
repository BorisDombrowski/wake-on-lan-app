using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using System.Text.RegularExpressions;

namespace WakeOnLan;

public partial class AddDevicePopup : Popup
{
    private string _macRegEx = "^(?:[0-9a-fA-F]{2}:){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}-){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}){5}[0-9a-fA-F]{2}$";

    public AddDevicePopup()
	{
		InitializeComponent();
	}
	
    private void MaskedEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
		entry.CursorPosition = entry.Text.Length;
    }

    private void AddConfirmationClicked(object sender, EventArgs e)
    {
        //if(string.IsNullOrEmpty(IPEntry.Text) || string.IsNullOrWhiteSpace(IPEntry.Text))
        //{
        //    Toast.Make("Invalid IP or domain").Show();
        //    return;
        //}

        uint port;
        var portParsed = uint.TryParse(PortEntry.Text, out port);
        //if(!portParsed || port < 1 || port > 65535)
        //{
        //    Toast.Make("Invalid port").Show();
        //    return;
        //}

        //var macValidation = Regex.Match(MacEntry.Text, _macRegEx);
        //if (!macValidation.Success)
        //{
        //    Toast.Make("Invalid MAC").Show();
        //    return;
        //}

        var device = new WakeOnLan.Devices.Device()
        {
            Name = NameEntry.Text,
            IP = IPEntry.Text,
            Port = port,
            MAC = MacEntry.Text
        };

        Close(device);
    }
}