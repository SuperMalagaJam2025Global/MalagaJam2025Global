using FMOD.Studio;
using FMODUnity;

public static class SoundTrigger
{

    public static bool PlayCustomAudioEvent(ESFXType sfxSound)
    {
        EventInstance sfx = RuntimeManager.CreateInstance("event:/" + GetID(sfxSound));
        sfx.start();
        return sfx.release().HasFlag(FMOD.RESULT.OK);
    }


    private static string GetID(ESFXType sfxSound) => 
    sfxSound switch
    {
        ESFXType.BrokenGlass => "BrokenGlass",
        ESFXType.Carry => "Carry",
        ESFXType.Jump => "Jump",
        ESFXType.Like => "Like",
        _ => "",
    };

}