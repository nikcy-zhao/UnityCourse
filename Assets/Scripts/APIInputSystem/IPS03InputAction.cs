using UnityEngine;
using UnityEngine.InputSystem;

public class IPS03InputAction : MonoBehaviour
{
    // 定义 InputActionAsset，用于存储输入系统文件
    public InputActionAsset inputActionAsset;
    // 定义 InputAction，用于存储动作
    private InputAction moveAction;
    // 定义移动向量
    private Vector2 moveVector = Vector2.zero;
    // 定义旋转速度
    public float rotationSpeed = 10f;
    // 定义移动速度
    public float moveSpeed = 3f;
    // 定义转向阈值
    [Range(0.1f, 1f)]
    public float rotationThreshold = 0.95f;

    // 目标方向
    private Vector3 targetDirection;
    // 是否正在转向
    private bool isRotating = false;
    // 是否应该移动
    private bool shouldMove = false;

    void Start()
    {
        if (inputActionAsset == null)
        {
            Debug.LogError("InputActionAsset is null");
            return;
        }

        // 查找名为Move的动作
        moveAction = inputActionAsset.FindAction("Player/Move");
    }

    void Update()
    {
        // 读取输入值
        moveVector = moveAction.ReadValue<Vector2>();
        Move();
    }

    void Move()
    {
        // 有输入时
        if (moveVector != Vector2.zero)
        {
            // 计算目标方向
            targetDirection = new Vector3(moveVector.x, 0, moveVector.y).normalized;

            // 计算目标旋转
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // 检查当前朝向与目标方向的夹角
            float dotProduct = Vector3.Dot(transform.forward, targetDirection);

            // dot<1，说明两个方向不一致，需要旋转
            if (dotProduct < rotationThreshold)
            {
                // 需要转向，停止移动
                isRotating = true;
                shouldMove = false;

                // 平滑转向
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime);
            }
            else
            {
                // 转向完成，可以移动
                isRotating = false;
                shouldMove = true;
            }

            // 只有在转向完成后才移动
            if (shouldMove && !isRotating)
            {
                // 按照当前朝向移动（世界坐标系）
                transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            // 没有输入时重置状态
            isRotating = false;
            shouldMove = false;
        }

    }

}
