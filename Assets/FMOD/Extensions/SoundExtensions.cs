using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class SoundExtensions
{
    public static bool PlaySFX(this GameObject gameObject, ESFXType sfxSound) =>
        PlayCustomAudioEvent(gameObject, SoundBank.GetID(sfxSound));

    public static bool PlayCustomAudioEvent(this GameObject originSound, string eventName)
    {
        EventInstance sfx = RuntimeManager.CreateInstance("event:/" + eventName);
        //heal.setParameterByID(fullHealthParameterId, restoreAll ? 1.0f : 0.0f);
        sfx.set3DAttributes(RuntimeUtils.To3DAttributes(originSound));
        sfx.start();
        return sfx.release().HasFlag(FMOD.RESULT.OK);
    }
}