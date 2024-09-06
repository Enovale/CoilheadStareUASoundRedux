using GameNetcodeStuff;
using HarmonyLib;
using TDP.CoilHeadStare.Patch;

namespace CoilheadStareUASoundRedux
{
    [HarmonyPatch(typeof(Stare))]
    public class CoilHeadStarePatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void UpdatePlaySound(PlayerControllerB ___stareTarget, bool ___isTurningHead, SpringManAI ___coilHeadInstance)
        {
            if (___isTurningHead && ___stareTarget != null && ___coilHeadInstance != null && !___coilHeadInstance.creatureVoice.isPlaying)
            {
                ___coilHeadInstance.creatureVoice.clip = Plugin.Instance.audioClip;
                ___coilHeadInstance.creatureVoice.Play();
            }
            else if (!___isTurningHead && ___coilHeadInstance != null && ___coilHeadInstance.creatureVoice.isPlaying)
            {
                ___coilHeadInstance.creatureVoice.Stop();
            }
        }
    }
}