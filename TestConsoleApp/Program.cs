using System;
using System.Threading.Tasks;
using RingIntegration;
using RingIntegration.Authentication;
using RingIntegration.Devices;
using Nito.AsyncEx;
using RingIntegration.Devices.Doorbell;


namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }
        
        static async Task MainAsync(string[] args)
        {
            Console.Write("Username:");
            var username = Console.ReadLine();
            
            Console.Write("Password:");
            var password = GetPassword();
            
            var a = new Authenticator();
            await a.Authenticate(username, password);
            
            Console.Write("Please type code:");
            var code = Console.ReadLine();
            Console.WriteLine();

            await a.TwoFactorAuthentication(code);

            var d = new DeviceManager(a);

            var deviceList = await d.GetDevices();

            var b = new Doorbell(a, deviceList.Doorbots[0]);

            await b.GetHistory(30);
        }

        static string GetPassword()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if(key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            return pass;
        }
    }
}