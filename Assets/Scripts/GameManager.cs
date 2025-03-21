using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text winText;
    public Button resetButton;
    public Button quitButton;

    void Start()
    {
        resetButton.onClick.AddListener(ResetGame);
        resetButton.gameObject.SetActive(false);
        quitButton.onClick.AddListener(QuitGame);
        quitButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
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
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }
}