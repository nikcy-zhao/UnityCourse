using UnityEngine;

public class API04Reflect : MonoBehaviour
{
    // plane
    public Transform target;
    // 球的移动速度
    public float speed = 10f;
    // 是否反射
    private bool isReflected = false;

    // 入射向量
    private Vector3 vector;
    // 法线向量
    private Vector3 normal;
    // 反射向量
    private Vector3 reflected;

    void Start()
    {
        // 计算反射向量，并保持不变
        vector = target.position - transform.position;
        normal = target.up;
        reflected = Vector3.Reflect(vector, normal);
    }

    void Update()
    {
        Debug.DrawRay(transform.position, vector, Color.green);
        Debug.DrawRay(target.position, normal * 10, Color.blue);
        Debug.DrawRay(target.position, reflected, Color.red);

        // 沿着入射方向移动
        if (!isReflected)
        {
            transform.Translate(vector.normalized * speed * Time.deltaTime);
        }

        // 到达反射点
        if (Vector3.Distance(transform.position, target.position) < 0.01f && !isReflected)
        {
            isReflected = true;
        }

        // 沿着反射方向移动
        if (isReflected)
        {
            transform.Translate(reflected.normalized * speed * Time.deltaTime);
        }
    }
}
