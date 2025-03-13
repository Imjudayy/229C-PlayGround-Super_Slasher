using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameManager gameManager; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player1"))
        {
            gameManager.PlayerDestroyed("Player1"); 
        }
        else if (other.CompareTag("Player2"))
        {
            gameManager.PlayerDestroyed("Player2"); 
        }

        Destroy(other.gameObject); 
    }
}
