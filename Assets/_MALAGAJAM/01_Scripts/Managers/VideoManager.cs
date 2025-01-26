using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    private bool isVideoOver;

    private void Update() { CheckVideoPlayer(); }

    private void CheckVideoPlayer()
    {
        if (!videoPlayer.isPlaying && videoPlayer.frame > 0) { SceneManager.LoadScene(0); }   // return to the main menu after the video ends
    }
}