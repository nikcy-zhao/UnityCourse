using UnityEngine;

public class API04SmoothDamp : MonoBehaviour
{
    public Transform target;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    void Start()
    {
        if (target == null)
            Debug.LogError("目标未设置");
        if (target == transform)
            Debug.LogError("目标不能是自己");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.01f) return;

        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }
}
