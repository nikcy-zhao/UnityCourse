using UnityEngine;

public class API09GetChild : MonoBehaviour
{
    private Transform child;
    void Start()
    {
        if (transform.childCount == 0)
        {
            Debug.LogWarning("没有子对象");
            return;
        }

        child = transform.GetChild(0);
        child.parent = null;
        Destroy(gameObject);
    }
}
