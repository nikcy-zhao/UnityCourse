using UnityEngine;

public class API09SetParent : MonoBehaviour
{
    public Transform parent;
    void Start()
    {
        if (parent == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }
        transform.SetParent(parent);
    }
}
