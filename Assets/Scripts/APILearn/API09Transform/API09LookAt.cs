using UnityEngine;

public class API09LookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }
        transform.LookAt(target);
    }
}
