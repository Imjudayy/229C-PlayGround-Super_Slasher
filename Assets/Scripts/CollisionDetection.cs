using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameManager gameManager;
    private bool hasTriggered = false;
    public AudioSource gameAudioSource;
    

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            if (other.CompareTag("Player1"))
            {
                gameManager.PlayerDestroyed("Player1");
            }
            else if (other.CompareTag("Player2"))
            {
                gameManager.PlayerDestroyed("Player2");
            }
            hasTriggered = true;
            Destroy(other.gameObject);

            
            if (gameAudioSource != null)
            {
                gameAudioSource.Stop();
            }

            
            Time.timeScale = 0; 
        }
    }
}
