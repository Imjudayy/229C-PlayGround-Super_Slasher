using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player2") && collision.gameObject != owner)
        {
            Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
            if (targetRb != null)
            {
                targetRb.AddForce(-collision.transform.forward * force, ForceMode.Impulse);
            }
            acc += 2;

            
            PlayerInput playerInput = collision.gameObject.GetComponent<PlayerInput>();
            if (playerInput != null)
            {
                Gamepad gamepad = playerInput.devices[0] as Gamepad;
                if (gamepad != null)
                {
                    VibrateGamepad(gamepad, 0.5f, 0.5f, 1.0f);
                }
            }
        }
    }

    void VibrateGamepad(Gamepad gamepad, float duration, float lowIntensity, float highIntensity)
    {
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowIntensity, highIntensity);
            StartCoroutine(StopVibration(gamepad, duration));
        }
    }

    System.Collections.IEnumerator StopVibration(Gamepad gamepad, float duration)
    {
        yield return new WaitForSeconds(duration);
        if (gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}
