using UnityEngine;

public class Coin2 : MonoBehaviour
{
    public float speed;
    private float delay = 1;

    public PlayerController1 player1;
    public PlayerController1 player2;

    public AudioClip getCoinSfx;
    public AudioSource playerAudio;

    void Start()
    {
        GameObject p1 = GameObject.Find("Player1");
        player1 = p1.GetComponent<PlayerController1>();

        GameObject p2 = GameObject.Find("Player2");
        player2 = p2.GetComponent<PlayerController1>();
    }


    void Update()
    {
        transform.Rotate(0, speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().AddForce(0, 20, 0);
        Invoke("DestroySelf", delay);
        speed = 3;

        if (other.CompareTag("Player1") || other.CompareTag("Sword"))
        {
            player1.maxJumps = 3;
            playerAudio.PlayOneShot(getCoinSfx);
        }
        else if (other.CompareTag("Player2") || other.CompareTag("Hamer"))
        {
            player2.maxJumps = 3;
            playerAudio.PlayOneShot(getCoinSfx);
        }

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
