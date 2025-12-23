using UnityEngine;

public class API04Distance : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        Debug.Log("Distance: " + distance);
    }
}
