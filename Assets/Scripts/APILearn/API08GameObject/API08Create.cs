using UnityEngine;

public class API08Create : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        // 创建一个空的 GameObject
        GameObject myObject = new GameObject("MyObject");

        // 克隆一个游戏对象
        if (target != null)
        {
            GameObject clone = Instantiate(target);
        }

        // 创建一个立方体
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // 销毁当前对象
        Destroy(gameObject);
    }
}
