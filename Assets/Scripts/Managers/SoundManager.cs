using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

// This is class is thought for BGM or another Background/Continous noises manipulations
// For using SFX, just use the SoundExtensions with a GameObject .
public class SoundManager : MonoBehaviour
{
    private EventInstance audioVideo;
    private PLAYBACK_STATE status;

    public bool PlayAudioFromVideo(string filename, GameObject originSound)
    {
        //Debug.Log("Calling with file:"+ filename);
        if (!StopAudioFromVideo())
        {
            Debug.Log("FAILED To Stop");
        }

        audioVideo = RuntimeManager.CreateInstance("event:/" + filename.Split(".")[0]);
        //heal.setParameterByID(fullHealthParameterId, restoreAll ? 1.0f : 0.0f);
        audioVideo.set3DAttributes(RuntimeUtils.To3DAttributes(originSound));
        audioVideo.start();
        return audioVideo.release().HasFlag(FMOD.RESULT.OK);

    }

    public bool StopAudioFromVideo()
    {
        audioVideo.getPlaybackState(out status);
        switch (status)
        {
            case PLAYBACK_STATE.STARTING:
            case PLAYBACK_STATE.PLAYING:
            case PLAYBACK_STATE.SUSTAINING:
                audioVideo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
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
