using UnityEngine;

public class API02TimeScale : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
