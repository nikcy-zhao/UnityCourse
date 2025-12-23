using UnityEngine;

public class API04Set : MonoBehaviour
{
    void Start()
    {
        Vector3 pos = Vector3.zero;
        pos.Set(0, 0, 1);
        transform.position = pos;
    }
}
