using UnityEngine;

public class API04RorateTowards : MonoBehaviour
{
    public Transform target;
    public float Speed = 30f;
    public float maxMagnitude = 0f;

    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        transform.forward = Vector3.RotateTowards(transform.forward, targetDirection, Speed * Mathf.Deg2Rad * Time.deltaTime, maxMagnitude);
    }
}
