using UnityEngine;

public class API05Angle : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        float angle = Quaternion.Angle(transform.rotation, targetRotation);
        Debug.Log("angle: " + angle);
    }
}
