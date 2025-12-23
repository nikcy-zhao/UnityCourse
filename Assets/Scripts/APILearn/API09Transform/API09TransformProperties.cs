using UnityEngine;

public class API09TransformProperties : MonoBehaviour
{
    void Start()
    {
        // 让当前对象脱离父对象
        if (transform.parent != null)
            transform.parent = null;
    }
}
