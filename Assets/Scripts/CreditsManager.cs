using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public GameObject creditsPanel; 
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(PlayCredits);
        videoPlayer.loopPointReached += EndCredits; 
    }

    void PlayCredits()
    {
        creditsPanel.SetActive(true); 
        videoPlayer.Play();
    }

    void EndCredits(VideoPlayer vp)
    {
        creditsPanel.SetActive(false); 
    }
}
