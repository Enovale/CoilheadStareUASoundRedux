using System.IO;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LCSoundTool;
using UnityEngine;

namespace CoilheadStareUASoundRedux
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("LCSoundTool")]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new(PluginInfo.PLUGIN_GUID);

        public AudioClip audioClip;

        public static Plugin Instance { get; set; }

        public static ManualLogSource Log => Instance.Logger;

        public Plugin()
        {
            Instance = this;
        }

        private void Awake()
        {
            audioClip = SoundTool.GetAudioClip(Path.GetDirectoryName(Info.Location), "zelensky.wav");
            Log.LogInfo("Applying patches...");
            ApplyPluginPatch();
            Log.LogInfo("Patches applied");
        }

        private void ApplyPluginPatch()
        {
            _harmony.PatchAll(typeof(CoilHeadStarePatch));
        }
    }
}