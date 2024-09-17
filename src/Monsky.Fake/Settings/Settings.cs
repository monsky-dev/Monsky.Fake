using System.Reflection;
using System.Text.Json;

namespace Monsky.Fake
{
    internal static class Settings
    {
        public static string Domain { internal get; set; }

        internal static List<string> LoadStringListFromJsonFile(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fullResourceName = $"Monsky.Fake.Data.{resourceName}";

            using Stream? stream = assembly.GetManifestResourceStream(fullResourceName);
            if (stream == null)
                throw new FileNotFoundException($"Embedded resource '{fullResourceName}' not found.");

            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<string>>(json) ?? throw new ArgumentNullException("No strings were loaded.");
            }
        }
    }
}
