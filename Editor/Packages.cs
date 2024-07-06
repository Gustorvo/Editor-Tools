using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace Gustorvo.Tools
{
    public static class Packages
    {
        public static void CreateDirectoriesInRoot(string root, params string[] directories)
        {
            var fullPath = Path.Combine(Application.dataPath, root);
            foreach (var newDirectory in directories)
            {
                Directory.CreateDirectory(Path.Combine(fullPath, newDirectory));
            }
        }

        public static string GetGistURL(string gistID, string user = "Gustorvo") =>
            $"https://gist.github.com/{user}/{gistID}/raw";

        public static async Task<string> GetContent(string url)
        {
            using var webClient = new HttpClient();
            var response = await webClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static void ReplacePackageFile(string contents)
        {
            var existingFile = Path.Combine(UnityEngine.Device.Application.dataPath, "../Packages/manifest.json");
            System.IO.File.WriteAllText(existingFile, contents);
            UnityEditor.PackageManager.Client.Resolve();
        }
    }
}