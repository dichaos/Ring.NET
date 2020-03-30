using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DlibDotNet;
using FaceDetection;
using Nito.AsyncEx;
using RingIntegration.Authentication;
using RingIntegration.Devices;
using RingIntegration.Devices.History;

namespace TestConsoleApp
{
    internal class Program
    {
        private const string keyUsername = "username";
        private const string keyPassword = "password";
        private const string keyToken = "token";
        
        private static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        private static async Task MainAsync(string[] args)
        {
            await ExtractFacesFromRingHistory();
        }

        private static async Task ExtractFacesFromRingHistory()
        {
            CreateDirectories();
            var videosPath = Path.Combine(Directory.GetCurrentDirectory(), "Videos\\");
            var facesPath = Path.Combine(Directory.GetCurrentDirectory(), "Faces\\");
            var framesPath = Path.Combine(Directory.GetCurrentDirectory(), "Frames\\");

            var a = await GetAuthenticator();
            await DownloadFiles(a, videosPath);
            
            Console.WriteLine("Extracting frames from videos...");
            new VideoControl().ExtractImagesFromVideoFolder(videosPath, framesPath);
            Console.WriteLine("DONE");
            
            Console.WriteLine("Detecting faces in frames...");
            new FaceDetection.FaceDetection().ExtractFaceImages(framesPath,facesPath);
            Console.WriteLine("Done");
        }

        private static string GetPassword()
        {
            var pass = "";
            do
            {
                var key = Console.ReadKey(true);
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
                        pass = pass.Substring(0, pass.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            Console.WriteLine();
            return pass;
        }

        private static async Task<Authenticator> GetAuthenticator()
        {
            while (true)
            {
                var a = await TrySecureStore();

                if (a == null)
                {
                    Console.Write("Username:");
                    var username = Console.ReadLine();

                    Console.Write("Password:");
                    var password = GetPassword();
                    
                    var secureStore = new SecureStore();
                    secureStore.SetKey(keyUsername, username);
                    secureStore.SetKey(keyPassword, password);

                    a = await TrySecureStore();
                }

                if (a == null)
                {
                    Console.WriteLine("Wrong username or password");
                }
                else
                {
                    return a;  
                }
            }    
        }
        
        private static async Task<Authenticator> TrySecureStore()
        {
            var secureStore = new SecureStore();
            var username = secureStore.ReadKey(keyUsername);
            var password = secureStore.ReadKey(keyPassword);
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            
            var token = secureStore.ReadKey(keyToken);

            var authenticator = new Authenticator(username, password, token);

            if (string.IsNullOrEmpty(token))
            {
                var result = await authenticator.Authenticate();

                if (result)
                {
                    Console.Write("Please type code:");
                    var code = Console.ReadLine();
                    Console.WriteLine();

                    await authenticator.TwoFactorAuthentication(code);

                    secureStore.SetKey(keyToken, authenticator.AccessToken);

                    return authenticator;
                }

                secureStore.SetKey(keyUsername, "");
                secureStore.SetKey(keyPassword, "");
                return null;
            }

            try
            {
                var d = new DeviceManager(authenticator);

                var deviceList = await d.GetDevices();

                if (deviceList == null && !string.IsNullOrEmpty(token))
                {
                    secureStore.SetKey(keyToken, string.Empty);
                    return await TrySecureStore();
                }
                
                if (deviceList != null)
                    return authenticator;
            }
            catch
            {
                return null;
            }

            return null;
        }

        private static void CreateDirectories()
        {
            var videosPath = Path.Combine(Directory.GetCurrentDirectory(), "Videos");
            var facesPath = Path.Combine(Directory.GetCurrentDirectory(), "Faces");
            var framesPath = Path.Combine(Directory.GetCurrentDirectory(), "Frames");

            if (!Directory.Exists(videosPath))
                Directory.CreateDirectory(videosPath);
            
            if (!Directory.Exists(facesPath))
                Directory.CreateDirectory(framesPath);
        }

        private static async Task DownloadFiles(Authenticator a, string videosPath)
        {
            var h = new HistoryManager(a);
            var history = await h.GetHistory(100);
            
            for (var i =0 ; i< history.Length; i++)
            {
                Console.WriteLine($"Downloading {i}/{history.Length}");
                var byteVideo = await h.GetRecording(history[i]);
                File.WriteAllBytes(Path.Combine(videosPath, history[i].created_at.ToString("yyyy MM dd -- HH-mm-ss")+".mp4"), byteVideo);
            }
        }
    }
}