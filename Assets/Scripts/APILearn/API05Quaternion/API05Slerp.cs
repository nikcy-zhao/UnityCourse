using UnityEngine;

public class API05Slerp : MonoBehaviour
{
    public Transform target;
    [Range(0.01f, 10f)]
    public float rotationSpeed = 2f;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }

        // 计算指向目标的方向
        Vector3 direction = target.position - transform.position;

        // 确保方向向量不为零
        if (direction.magnitude < 0.001f)
            return;

        // 计算目标旋转
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 以每秒rotationSpeed度数的速度旋转物体
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.Lerp(
        //     transform.rotation,
        //     targetRotation,
        //     rotationSpeed * Time.deltaTime);
    }
}
