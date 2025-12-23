using UnityEngine;

public class API09Find : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        // 通过名称查找对象
        target = transform.Find("Cube");
        if (target == null)
        {
            Debug.Log("未找到目标");
        }
    }

    void Update()
    {
        target.Rotate(Vector3.up, 30f * Time.deltaTime);
    }
}
