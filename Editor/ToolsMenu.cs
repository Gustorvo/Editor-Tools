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

        [MenuItem("Tools/Load Meta Ready Manifest")]
        static async void LoadMetaReadyManifest()
        {
            var url = Packages.GetGistURL("ba8c1ab508075ab5ea7c01069c299e62");
            var contents = await Packages.GetContent(url);
            Packages.ReplacePackageFile(contents);
        }
    }
    
}