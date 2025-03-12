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
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            if (!collision.transform.IsChildOf(transform.parent))
            {
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                if (targetRb != null)
                {
                    targetRb.AddForce(-collision.transform.forward * force, ForceMode.Impulse);
                }
                acc += 2;
            }
        }
    }
}
