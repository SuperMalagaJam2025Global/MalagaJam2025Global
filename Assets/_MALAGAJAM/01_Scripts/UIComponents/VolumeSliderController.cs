using UnityEngine;
using UnityEngine.UI;
using FMOD;

public class VolumeManager : MonoBehaviour
{
    
    public Slider s_Master;
    public Slider s_BGM;
    public Slider s_Sfx;
    public Slider s_Video;

    float tmpVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        //s_Master = GameObject.Find("Slider_Master").GetComponent<Slider>();
        //s_BGM = GameObject.Find("Slider_BGM").GetComponent<Slider>();
        //s_Sfx = GameObject.Find("Slider_SFX").GetComponent<Slider>();
        //s_Video = GameObject.Find("Slider_Video").GetComponent<Slider>();

        RefreshVolumesStatus();

        s_Master.onValueChanged.AddListener(delegate{SetVolume("Master");});
        s_BGM.onValueChanged.AddListener(delegate{SetVolume("BGM");});
        s_Sfx.onValueChanged.AddListener(delegate{SetVolume("SFX");});
        s_Video.onValueChanged.AddListener(delegate{SetVolume("Videos");});
    }

    void SetVolume(string volumetype)
    {
        Slider sliderToSet = null;
        switch(volumetype)
        {
            case "Master": sliderToSet = s_Master; break;
            case "BGM": sliderToSet = s_BGM; break;
            case "SFX": sliderToSet = s_Sfx; break;
       //   case "Video": sliderToSet = s_Video; break;
            default: UnityEngine.Debug.Log("It shouldn't happen this"); return;
        }
        
        if(volumetype == "Master")
        {
            FMODUnity.RuntimeManager.GetBus("bus:/").setVolume(sliderToSet.normalizedValue);
        }else{
            FMODUnity.RuntimeManager.GetVCA("vca:/"+volumetype).setVolume(sliderToSet.normalizedValue);
        }

        RefreshVolumesStatus();
    }

    void RefreshVolumesStatus()
    {
        string prefix = "vca:/";
        FMODUnity.RuntimeManager.GetBus("bus:/").getVolume(out tmpVolume);

        s_Master.SetValueWithoutNotify(tmpVolume);

        FMODUnity.RuntimeManager.GetVCA(prefix + "SFX").getVolume(out tmpVolume);
        s_Sfx.SetValueWithoutNotify(tmpVolume);
        FMODUnity.RuntimeManager.GetVCA(prefix + "BGM").getVolume(out tmpVolume);
        s_BGM.SetValueWithoutNotify(tmpVolume);
       // FMODUnity.RuntimeManager.GetVCA(prefix + "Videos").getVolume(out tmpVolume);
       // s_Video.SetValueWithoutNotify(tmpVolume);
    }

}