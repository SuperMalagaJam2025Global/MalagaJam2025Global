using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class SoundExtensions
{
    public static bool PlaySFX(this GameObject gameObject, ESFXType sfxSound) =>
        PlayCustomAudioEvent(gameObject, GetID(sfxSound));

    public static bool PlayCustomAudioEvent(this GameObject originSound, string eventName)
    {
        EventInstance sfx = RuntimeManager.CreateInstance("event:/" + eventName);
        //heal.setParameterByID(fullHealthParameterId, restoreAll ? 1.0f : 0.0f);
        sfx.set3DAttributes(RuntimeUtils.To3DAttributes(originSound));
        sfx.start();
        return sfx.release().HasFlag(FMOD.RESULT.OK);
    }

    private static string GetID(ESFXType sfxSound) =>
    sfxSound switch
    {
        ESFXType.Back => "Back",
        ESFXType.Press => "aceptar",
        ESFXType.Dead => "muerte con voz (gato)",
        ESFXType.BubblesMate => "burbujas (mate)2",
        ESFXType.step1 =>"paso1",
        ESFXType.step2 =>"paso2",
        ESFXType.step3 =>"paso3",
        _ => "",
    };

}