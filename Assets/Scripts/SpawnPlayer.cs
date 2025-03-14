using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        Instantiate(player1, player1.transform.position,Quaternion.identity );
        Instantiate(player2, player2.transform.position,Quaternion.identity );
    }

    
    void Update()
    {
        
    }
}
