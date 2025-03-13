using UnityEngine;

public class Hamer : MonoBehaviour
{
    public float force, mass, acc;
    public GameObject owner;

    void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
    }

    void Update()
    {
        force = mass * acc;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") && collision.gameObject != owner)
        {
            Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                targetRb.AddForce(-collision.transform.forward * force, ForceMode.Impulse);
            }
            acc += 5;
        }
    }
}
