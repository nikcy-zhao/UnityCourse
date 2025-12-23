using UnityEngine;

public class API03Properties : MonoBehaviour
{
    // 作为旋转的中心点
    public GameObject centerSphere;

    // 旋转的物体
    public GameObject kineticSphere;

    // 旋转速度
    public float rotateSpeed = 10f;

    // 累计旋转的角度
    private float totalDegrees = 0f;

    // 旋转半径
    public float rotateRadius = 5f;

    void Awake()
    {
        if (centerSphere == null || kineticSphere == null)
        {
            Debug.LogError("centerSphere or kineticSphere is not assigned");
        }
    }

    void Update()
    {
        // 限制旋转角度在 0 ~ 360 之间
        if (totalDegrees >= 360f)
            totalDegrees -= 360f;

        // 计算累计旋转的角度
        totalDegrees += rotateSpeed * Time.deltaTime;

        // 转化角度为弧度
        float radians = Mathf.Deg2Rad * totalDegrees;

        // 计算旋转后的坐标
        float x = centerSphere.transform.position.x + rotateRadius * Mathf.Cos(radians);
        float y = centerSphere.transform.position.y;
        float z = centerSphere.transform.position.z + rotateRadius * Mathf.Sin(radians);

        // 设置旋转物体的位置
        kineticSphere.transform.position = new Vector3(x, y, z);
    }
}
