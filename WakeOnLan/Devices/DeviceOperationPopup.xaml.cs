using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

namespace WakeOnLan.Devices;

public partial class DeviceOperationPopup : Popup
{
    private readonly Device _currentDevice;

    public DeviceOperationPopup()
	{
		InitializeComponent();

        _currentDevice = new Device();
        Content.BindingContext = _currentDevice;
	}

    public DeviceOperationPopup(Device device)
    {
        if(device == null) 
        {
            throw new ArgumentNullException(nameof(device), "Editable device can't be null");
        }

        InitializeComponent();

        _currentDevice = new Device(device.Guid)
        {
            Name = device.Name,
            IP = device.IP,
            Port = device.Port,
            MAC = device.MAC
        };
        Content.BindingContext = _currentDevice;        
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        if(!DeviceParamsValidator.IsValidName(_currentDevice.Name))
        {
            Toast.Make("Enter device name").Show();
            return;
        }

        if(!DeviceParamsValidator.IsValidIP(_currentDevice.IP))
        {
            Toast.Make("Incorrect IP").Show();
            return;
        }

        if(!DeviceParamsValidator.IsValidPort(_currentDevice.Port))
        {
            Toast.Make("Incorrect port").Show();
            return;
        }

        if (!DeviceParamsValidator.IsValidMac(_currentDevice.MAC))
        {
            Toast.Make("Incorrect MAC").Show();
            return;
        }

        _currentDevice.MAC = _currentDevice.MAC.ToUpper();

        Close(_currentDevice);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void NameEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        RestrictEntryLength(20, sender, e);
    }

    private void PortEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        RestrictEntryLength(5, sender, e);
    }

    private static void RestrictEntryLength(int maxSize, object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > maxSize)
        {
            var entry = sender as Entry;
            entry.Text = e.OldTextValue;
        }
    }

    private void MaskedEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
        entry.CursorPosition = entry.Text.Length;
    }
}