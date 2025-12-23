using UnityEngine;

public class API09DetachChild : MonoBehaviour
{
    void Start()
    {
        if (transform.childCount == 0)
        {
            Debug.LogWarning("没有子对象");
            return;
        }

        // 获取第一个子对象并将其从父对象中分离
        transform.DetachChildren();

        // 销毁当前对象
        Destroy(gameObject);
    }
}
