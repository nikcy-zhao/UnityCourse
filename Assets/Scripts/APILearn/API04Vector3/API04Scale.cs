using UnityEngine;

public class API04Scale : MonoBehaviour
{
    void Start()
    {
        if (transform.position == Vector3.zero)
        {
            transform.position = new Vector3(1f, 1f, 1f);
            transform.position = Vector3.Scale(transform.position, new Vector3(2f, 2f, 2f));
        }
    }
}
