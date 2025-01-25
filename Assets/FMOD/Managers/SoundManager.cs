using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;

// This is class is thought for BGM or another Background/Continous noises manipulations
// For using SFX, just use the SoundExtensions with a GameObject .
public static class SoundManager
{
    private static EventInstance bgmEvent;
    private static PLAYBACK_STATE status;

    private static PARAMETER_DESCRIPTION parameterSample;
    public static void Start()
    {
        RuntimeManager.StudioSystem.getParameterDescriptionByName("ParamName", out parameterSample);
    }

    public static bool StartBGM()
    {
        bgmEvent = RuntimeManager.CreateInstance("event:/music 2");
        bgmEvent.start();
        return bgmEvent.release().HasFlag(FMOD.RESULT.OK);
    }

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
