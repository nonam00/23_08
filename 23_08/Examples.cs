using System.Net.NetworkInformation;

namespace _23_08
{
    public static class Examples 
    {
        public static void NetworkInterfaces()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in nics)
            {
                  IPInterfaceProperties properties = adapter.GetIPProperties();
                  Console.WriteLine();
                  Console.WriteLine(adapter.Description);
                  Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
                  Console.WriteLine("  Interface type .......................... : {0}",
                      adapter.NetworkInterfaceType);
                  Console.WriteLine("  Physical Address ........................ : {0}",
                      adapter.GetPhysicalAddress().ToString());
                  Console.WriteLine("  Operational status ...................... : {0}",
                          adapter.OperationalStatus);
                  string versions = "";
                  if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                  {
                      versions = "IPv4";
                  }
                  if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                  {
                      if (versions.Length > 0)
                      {
                          versions += " ";
                      }
                      versions += "IPv6";
                  }
                  Console.WriteLine("  IP version .............................. : {0}", versions);
                  //
                  // The following information is not useful for loopback adapters.
                  if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                  {
                      continue;
                  }
                  Console.WriteLine("  DNS suffix .............................. : {0}",
                      properties.DnsSuffix);

                  if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                  {
                      IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                      Console.WriteLine("  MTU...................................... : {0}", ipv4.Mtu);
                  }

                  Console.WriteLine("  Receive Only ............................ : {0}",
                      adapter.IsReceiveOnly);
                  Console.WriteLine("  Multicast ............................... : {0}",
                      adapter.SupportsMulticast);

                  Console.WriteLine();
            }
        }

        public static void IpStat()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();

            Console.WriteLine("  Inbound Packet Data:");

            Console.WriteLine("      Received ............................ : {0}",
                ipstat.ReceivedPackets);
            Console.WriteLine("      Forwarded ........................... : {0}",
                ipstat.ReceivedPacketsForwarded);
            Console.WriteLine("      Delivered ........................... : {0}",
                ipstat.ReceivedPacketsDelivered);
            Console.WriteLine("      Discarded ........................... : {0}",
                ipstat.ReceivedPacketsDiscarded);
        } 
    }
}
