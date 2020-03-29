using System.IO;
using NeoSmart.SecureStore;

namespace TestConsoleApp
{
    public interface ISecureStore
    {
        string ReadKey(string key);
        void SetKey(string key, string value);
        bool CheckKey(string key);
    }

    public class SecureStore : ISecureStore
    {
        private readonly string keyFile;
        private readonly string storeFile;

        public SecureStore(string filePath = "secure")
        {
            keyFile = string.Concat(filePath, ".key");
            storeFile = string.Concat(filePath, ".store");

            if (File.Exists(storeFile)) return;
            
            using var sman = SecretsManager.CreateStore();
            sman.GenerateKey();
            sman.ExportKey(keyFile);
            sman.SaveStore(storeFile);
        }

        public string ReadKey(string key)
        {
            using var sman = SecretsManager.LoadStore(storeFile);
            sman.LoadKeyFromFile(keyFile);
            return !sman.TryGetValue(key, out string value) ? "" : value;
        }

        public void SetKey(string key, string value)
        {
            using var sman = SecretsManager.LoadStore(storeFile);
            sman.LoadKeyFromFile(keyFile);
            sman.Set(key, value);
            sman.SaveStore(storeFile);
        }

        public bool CheckKey(string key)
        {
            using var sman = SecretsManager.LoadStore(storeFile);
            sman.LoadKeyFromFile(keyFile);
            return sman.TryGetValue(key, out string value);
        }
    }
}