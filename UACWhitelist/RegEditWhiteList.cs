using System.Linq;
using Microsoft.Win32;

public class RegEditWhiteList
{
    public string keyName { get; set; }
    private readonly string root = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers";
    private readonly string keyValue = "~ RunAsInvoker";

    public RegEditWhiteList(string keyName)
    {
        this.keyName = keyName;
    }

    public void SendRegedit()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(root, true);
        key.SetValue(keyName, keyValue,RegistryValueKind.String);
        key.Close();
    }
}