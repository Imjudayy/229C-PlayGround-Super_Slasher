using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Coin3 : MonoBehaviour
{
    public float speed;
    private float delay = 1;

    Rigidbody rb_P1;
    Rigidbody rb_P2;

    public PlayerController1 player1;
    public PlayerController1 player2;

    void Start()
    {
        GameObject p1 = GameObject.Find("Player1");
        rb_P1 = p1.GetComponent<Rigidbody>();
        player1 = p1.GetComponent<PlayerController1>();


        GameObject p2 = GameObject.Find("Player2");
        rb_P2 = p2.GetComponent<Rigidbody>();
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
            rb_P1.mass +=1;
            player1.moveSpeed += 10;
            player1.jumpForce += 5;
        }
        else if (other.CompareTag("Player2") || other.CompareTag("Hamer"))
        {
            rb_P2.mass += 1;
            player2.moveSpeed += 10;
            player2.jumpForce += 5;
        }

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
