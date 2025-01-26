using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;

public enum BGMType
{
    MainMenu,
    MainGame,
    Win
}

// This is class is thought for BGM or another Background/Continous noises manipulations
// For using SFX, just use the SoundExtensions with a GameObject .
public static class SoundManager
{
    private static EventInstance bgmEvent;
    private static PLAYBACK_STATE status;

    private static PARAMETER_DESCRIPTION parameterSample;
    public static void Start()
    {
    }

    public static bool StartBGM(BGMType eSFXBGM)
    {
        StopBGM();
        
        bgmEvent = RuntimeManager.CreateInstance("event:/" + GetID(eSFXBGM));
        bgmEvent.start();
        return bgmEvent.release().HasFlag(FMOD.RESULT.OK);
    }

    private static string GetID(BGMType sfxSound) =>
    sfxSound switch
    {
        BGMType.MainGame => "music 2",
        BGMType.MainMenu => "main menu definitivo",
        BGMType.Win => "win",
        _ => "",
    };

    public static bool SetFloatProperty(EBGMStatus value)
    {
        // Not my Fault
        return bgmEvent.setParameterByName("Parameter 2", (float)value).HasFlag(FMOD.RESULT.OK);
    }

    public static bool StopBGM()
    {
        bgmEvent.getPlaybackState(out status);
        switch (status)
        {
            case PLAYBACK_STATE.STARTING:
            case PLAYBACK_STATE.PLAYING:
            case PLAYBACK_STATE.SUSTAINING:
                bgmEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                //    Debug.Log("It's playing a audio video, Force Stopping ");
                break;
            default: break;
        }

        return status == PLAYBACK_STATE.STOPPED || status == PLAYBACK_STATE.STOPPED;
    }
}
