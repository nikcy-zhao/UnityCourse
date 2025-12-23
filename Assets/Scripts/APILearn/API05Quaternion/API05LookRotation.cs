using UnityEngine;

public class API05LookRotation : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        // transform.rotation = rotation;
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }
}
