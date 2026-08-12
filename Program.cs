using System.Net;
using System.Net.Sockets;

const int firstPort = 3000;
const int portsToFind = 10;

var availablePorts = new List<int>();

for (int port = firstPort; availablePorts.Count < portsToFind; port++)
{
    if (IsPortAvailable(port))
    {
        availablePorts.Add(port);
    }
}

Console.WriteLine();
Console.WriteLine("┌────────┬───────────┐");
Console.WriteLine("│ Port   │ Status    │");
Console.WriteLine("├────────┼───────────┤");

foreach (var port in availablePorts)
{
    Console.WriteLine($"│ {port,-6} │ Available │");
}

Console.WriteLine("└────────┴───────────┘");

static bool IsPortAvailable(int port)
{
    try
    {
        using var listener = new TcpListener(IPAddress.Loopback, port);

        listener.Start();
        listener.Stop();

        return true;
    }
    catch (SocketException)
    {
        return false;
    }
}