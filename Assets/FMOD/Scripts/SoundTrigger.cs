using FMOD.Studio;
using FMODUnity;

public static class SoundTrigger
{

    public static bool PlayCustomAudioEvent(ESFXType sfxSound)
    {
                                                    // A accidental Change from our friend ;)
        EventInstance sfx = RuntimeManager.CreateInstance("event:/sfxt/" + SoundBank.GetID(sfxSound));
        sfx.start();
        return sfx.release().HasFlag(FMOD.RESULT.OK);
    }

}