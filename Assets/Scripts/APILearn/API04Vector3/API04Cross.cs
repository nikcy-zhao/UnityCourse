using UnityEngine;

public class API04Cross : MonoBehaviour
{
    public Transform target;
    private Vector3 axis;

    void Start()
    {
        if (target == null)
            Debug.LogError("目标未设置");
        if (target == transform)
            Debug.LogError("目标不能是自己");
    }

    void Update()
    {
        // 计算目标与当前物体正面的叉乘
        Vector3 cross = Vector3.Cross((target.position - transform.position).normalized, transform.forward);

        // 使用 `sqrMagnitude` 检查叉积是否接近零(如果共线，叉积是零向量)
        if (cross.sqrMagnitude < 0.001f)
            axis = Vector3.up;
        else
            axis = cross.normalized;

        //目标围绕cross旋转
        target.transform.RotateAround(transform.position, axis, 10f);

        //自身围绕cross旋转
        transform.Rotate(axis, 10f);

        Debug.DrawRay(transform.position, axis * 10, Color.green);
    }
}
