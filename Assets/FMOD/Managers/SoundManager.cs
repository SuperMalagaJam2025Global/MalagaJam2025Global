using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using Unity.VisualScripting;

// This is class is thought for BGM or another Background/Continous noises manipulations
// For using SFX, just use the SoundExtensions with a GameObject .
public class SoundManager : MonoBehaviour
{
    private EventInstance bgmEvent;
    private PLAYBACK_STATE status;

    PARAMETER_DESCRIPTION parameterSample;
    public void Start()
    {
        RuntimeManager.StudioSystem.getParameterDescriptionByName("ParamName", out parameterSample);
    }

    public bool StartBGM()
    {
      
        bgmEvent = RuntimeManager.CreateInstance("event:/" + "StandardBGM");
        //audioVideo.set3DAttributes(RuntimeUtils.To3DAttributes(originSound));
        bgmEvent.start();
        return bgmEvent.release().HasFlag(FMOD.RESULT.OK);

    }

    public bool SetFloatProperty(float value)
    {
        return bgmEvent.setParameterByName("",value).HasFlag(FMOD.RESULT.OK);
    }

    public bool StopBGM()
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

    // This not make sense but...
    public bool PlaySFX(ESFXType sfxSound) =>
        gameObject.PlaySFX(sfxSound);
}
