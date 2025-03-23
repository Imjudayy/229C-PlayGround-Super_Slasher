using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public Text winText;
    public Button resetButton;
    public Button quitButton;
    public Button playCreditsButton; 
    public VideoPlayer videoPlayer; 
    public GameObject videoPanel;   

    void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
        resetButton.gameObject.SetActive(false); 
        quitButton.onClick.AddListener(QuitGame);
        quitButton.gameObject.SetActive(false);  
        playCreditsButton.onClick.AddListener(PlayCredits);
        playCreditsButton.gameObject.SetActive(false); 
        winText.gameObject.SetActive(false);

        videoPanel.SetActive(false); 
        videoPlayer.loopPointReached += EndVideo; 
    }

    public void PlayerDestroyed(string player)
    {
        
        if (player == "Player1")
        {
            winText.text = "Player 2 Wins!";
        }
        else if (player == "Player2")
        {
            winText.text = "Player 1 Wins!";
        }

       
        winText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        playCreditsButton.gameObject.SetActive(true);
    }

    void PlayCredits()
    {
        
        resetButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        playCreditsButton.gameObject.SetActive(false);

        videoPanel.SetActive(true); 
        videoPlayer.Play(); 
    }

    void EndVideo(VideoPlayer vp)
    {
        
        videoPanel.SetActive(false);
        resetButton.gameObject.SetActive(true); 
        quitButton.gameObject.SetActive(true);  
    }

    void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}
