using UnityEngine;

public class Sword : MonoBehaviour
{
    public float force, mass, acc;

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
        Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
        if (targetRb != null)
        {
           // targetRb.AddForce(transform.forward * force, ForceMode.Impulse); // chek form transfrom wepon
            targetRb.AddForce(-collision.transform.forward * force, ForceMode.Impulse);
        }
        acc += 2;
    }
}
