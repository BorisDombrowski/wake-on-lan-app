using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using WakeOnLan.Devices;

namespace WakeOnLan.Devices;

public partial class DeviceOperationPopup : Popup
{
    private Devices.Device _currentDevice;

    public DeviceOperationPopup()
	{
		InitializeComponent();

        _currentDevice = new Devices.Device();
        Content.BindingContext = _currentDevice;        
	}

    public DeviceOperationPopup(Devices.Device device)
    {
        if(device == null) 
        {
            throw new ArgumentNullException(nameof(device), "Editable device can't be null");
        }

        InitializeComponent();

        _currentDevice = new Devices.Device(device.Guid)
        {
            Name = device.Name,
            IP = device.IP,
            Port = device.Port,
            MAC = device.MAC
        };
        Content.BindingContext = _currentDevice;        
    }
	
    private void MaskedEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;
		entry.CursorPosition = entry.Text.Length;
    }

    private void ConfirmClicked(object sender, EventArgs e)
    {
        var a = NameEntry.Parent.BindingContext;

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
}