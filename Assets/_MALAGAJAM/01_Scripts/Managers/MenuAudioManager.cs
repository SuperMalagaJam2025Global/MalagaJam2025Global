using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    private void Start()
    {
        SoundManager.StartBGM(BGMType.MainMenu);
    }

    // TODO: Please check this, Teresa
    //this.gameObject.PlaySFX(ESFXType.Press);

    // this.gameObject.PlaySFX(ESFXType.Back);
}
