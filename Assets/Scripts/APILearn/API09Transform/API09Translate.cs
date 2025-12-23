using UnityEngine;

public class API09Translate : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
