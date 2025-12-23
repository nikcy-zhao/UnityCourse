using UnityEngine;

public class API07Destroy : MonoBehaviour
{
    void Start()
    {
        // 销毁脚本
        Destroy(FindFirstObjectByType<API07Instantiate>(), 5);

        // 销毁对象
        Destroy(gameObject, 10);
    }
}
