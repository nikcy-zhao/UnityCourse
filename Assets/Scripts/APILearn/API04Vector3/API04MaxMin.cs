using UnityEngine;

public class API04MaxMin : MonoBehaviour
{
    public Vector3 a = new Vector3(10, 2, 38);
    public Vector3 b = new Vector3(3, 25, 33);

    void Start()
    {
        Debug.Log("Max:" + Vector3.Max(a, b));
        Debug.Log("Min:" + Vector3.Min(a, b));
    }
}
