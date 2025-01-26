using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.StartBGM(BGMType.MainMenu);
    }

    // TODO: Please check this, Teresa
    //SoundTrigger.PlayCustomAudioEvent(ESFXType.Press);

    // SoundTrigger.PlayCustomAudioEvent(ESFXType.Back);
}
