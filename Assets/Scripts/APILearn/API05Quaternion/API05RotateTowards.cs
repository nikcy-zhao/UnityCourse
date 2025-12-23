using UnityEngine;

public class API05RotationTowards : MonoBehaviour
{

    public Transform target;
    [Range(0, 180f)]
    public float rotationSpeed = 60f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("目标未指定");
            return;
        }
    }

    void Update()
    {
        // 计算指向目标的方向
        Vector3 direction = target.position - transform.position;

        // 确保方向向量不为零
        if (direction.magnitude < 0.001f)
            return;

        // 计算目标旋转
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 以每秒rotationSpeed度数的速度旋转物体
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);
    }
}
