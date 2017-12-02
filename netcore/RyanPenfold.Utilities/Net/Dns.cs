/*
namespace RyanPenfold.Utilities.Net
{
    using System.Linq;

    public class Dns
    {
        public static string GetPrimaryDnsServerIpAddress()
        {
            var adapter = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.GetIPProperties().UnicastAddresses
                .Any(t => string.Equals(t.Address.ToString(), IpAddress.GetLocalIpAddress(), System.StringComparison.OrdinalIgnoreCase)));

            var adapterProperties = adapter?.GetIPProperties();
            return adapterProperties?.DnsAddresses?.FirstOrDefault()?.ToString();
        }
    }
}
*/