using UnityEngine;

public class API04Slerp : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, 3f * Time.deltaTime);
    }
}
