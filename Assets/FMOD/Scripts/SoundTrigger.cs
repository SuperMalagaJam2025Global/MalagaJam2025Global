using FMOD.Studio;
using FMODUnity;

public static class SoundTrigger
{

    public static bool PlayCustomAudioEvent(ESFXType sfxSound)
    {
        EventInstance sfx = RuntimeManager.CreateInstance("event:/sfx/" + GetID(sfxSound));
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