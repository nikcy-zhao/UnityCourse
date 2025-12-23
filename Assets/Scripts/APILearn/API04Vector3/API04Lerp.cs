using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}

