using UnityEngine;

public class Coin1 : MonoBehaviour
{
    public float speed;
    private float delay = 1;

    public Sword sword;
    public Hamer hamer;

    void Start()
    {
        GameObject p1 = GameObject.Find("sword");
        sword = p1.GetComponent<Sword>();

        GameObject p2 = GameObject.Find("hamer");
        hamer = p2.GetComponent<Hamer>();
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
            sword.acc *= 2;
        }
        else if (other.CompareTag("Player2") || other.CompareTag("Hamer"))
        {
            hamer.acc *= 2;
        }

    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
