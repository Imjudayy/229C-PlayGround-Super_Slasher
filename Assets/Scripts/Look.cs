using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform target;

    private void Awake()
    {
        //transform.LookAt(target);
    }

    private void Update()
    {
        transform.LookAt(target);
    }
}
