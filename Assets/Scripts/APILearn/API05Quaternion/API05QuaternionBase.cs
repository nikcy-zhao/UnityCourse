using UnityEngine;

public class API05QuaternionBase : MonoBehaviour
{
    public Vector3 eulerAngles = new Vector3(0, 90, 0);
    public Vector3 axis = new Vector3(45, 0, 0);
    private Quaternion rotation;

    void Start()
    {
        // 使用欧拉角创建一个四元数
        rotation = Quaternion.Euler(eulerAngles) * Quaternion.Euler(axis);
    }

    void Update()
    {
        // 将四元数应用于物体的旋转
        transform.rotation *= rotation;
    }
}
