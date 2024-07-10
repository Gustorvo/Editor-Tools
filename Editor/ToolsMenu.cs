using UnityEditor;
using static UnityEditor.AssetDatabase;

namespace Gustorvo.Tools
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Packages.CreateDirectoriesInRoot("_Project", "Scripts", "Art", "Scenes", "Prefabs");
            Refresh();
        }

        [MenuItem("Tools/Load Meta Ready Manifest (URP)")]
        static async void LoadMetaReadyManifestURP()
        {
            var url = Packages.GetGistURL("ba8c1ab508075ab5ea7c01069c299e62");
            var contents = await Packages.GetContent(url);
            Packages.ReplacePackageFile(contents);
        }
        
        [MenuItem("Tools/Load Meta Ready Manifest (Built-in)")]
        static async void LoadMetaReadyManifestBuintIn()
        {
            var url = Packages.GetGistURL("a3502b5613d3bdff6d993417b6aaa730");
            var contents = await Packages.GetContent(url);
            Packages.ReplacePackageFile(contents);
        }
    }
    
}