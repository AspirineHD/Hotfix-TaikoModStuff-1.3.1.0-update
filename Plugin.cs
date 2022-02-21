using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using BepInEx.Configuration;

namespace TaikoUncap
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Taiko no Tatsujin.exe")]
    public class Plugin : BasePlugin
    {
        public static ConfigEntry<int> configCustomFramerate;
        public static ConfigEntry<bool> configToggleVSync;

        public override void Load()
        {
            configCustomFramerate = Config.Bind("General.Framerate",
                                                "CustomFramerate",
                                                60,
                                                "Custom framerate. Use with caution");

            configToggleVSync = Config.Bind("General.Graphics",
                                             "EnableVSync",
                                             true,
                                             "Enable VSync.");

            var instance = new Harmony(PluginInfo.PLUGIN_NAME);
            instance.PatchAll(typeof(ForceFramerate));

            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
